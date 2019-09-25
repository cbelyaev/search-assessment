// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core
{
    using System.Collections.Generic;
    using System.IO;
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Util;

    /// <summary>
    ///     Represents common configuration module with configuration stored in 'appsettings.json' file.
    /// </summary>
    public class ConfigurationModule : IModule
    {
        private const string SettingsFileName = "appsettings.json";

        public void Register(IServiceCollection services, IList<Profile> mappingProfiles)
        {
            Check.NotNull(services, nameof(services));
            Check.NotNull(mappingProfiles, nameof(mappingProfiles));

            services.AddSingleton<IConfiguration>(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(SettingsFileName).Build());
        }
    }
}