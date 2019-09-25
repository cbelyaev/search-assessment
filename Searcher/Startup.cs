// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher
{
    using System;
    using System.IO;
    using System.Reflection;
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Config;
    using Core;
    using Infrastructure;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using SearchModule;
    using Swashbuckle.AspNetCore.Swagger;
    using UserModule;

    /// <summary>
    ///     Represents a class for starting up the API.
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     Gets the configuraton for the application.
        /// </summary>
        public static IConfiguration Configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true)
            .Build();

        /// <summary>
        ///     Configures services for the application.
        /// </summary>
        /// <remarks>
        ///     This method gets called by the runtime. Use this method to add services to the container.
        /// </remarks>
        /// <param name="services">The collection of services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOptions();

            // JWT
            var jwtConfig = Configuration.ConfigAndGet<JwtConfig>(services, Constants.JwtSectionKey);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtConfig.Issuer,
                        ValidAudience = jwtConfig.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(jwtConfig.KeyBytes)
                    };
                });

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Constants.ApiVersion,
                    new Info
                    {
                        Title = Constants.ApiName,
                        Version = Constants.ApiVersion,
                        Description = Constants.ApiDescription,
                    });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var registrar = new ModuleRegistrar().Register<UserModule>()
                                                 .Register<SearchModule>()
                                                 .Register<SearcherModule>();
            registrar.CopyServicesTo(services);
            
            // AutoMapper
            var mapper = new MapperConfiguration(mc => registrar.MappingProfiles.ForEach(mc.AddProfile)).CreateMapper();
            services.AddSingleton(mapper);

            // configuration
            services.AddSingleton(Configuration);
        }

        /// <summary>
        ///     Configures the HTTP request pipeline.
        /// </summary>
        /// <remarks>
        ///     This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </remarks>
        /// <param name="app">The builder of an application's request pipeline.</param>
        /// <param name="env">The web hosting environment an application is running in.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Top-level exception handling. Catches any unhandled exception and returns 500
            app.UseErrorHandlingMiddleware();

            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Constants.ApiUrl, $"{Constants.ApiName} {Constants.ApiVersion}");
            });
        }
    }
}