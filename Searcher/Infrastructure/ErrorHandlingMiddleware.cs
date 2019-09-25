// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Infrastructure
{
    using System;
    using System.Threading.Tasks;
    using Config;
    using Core.Util;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using NLog;

    /// <summary>
    ///     Represents a middleware to catch and reports exceptions in the application's request pipeline.
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly RequestDelegate _next;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ErrorHandlingMiddleware" /> class.
        /// </summary>
        /// <param name="hostingEnvironment">An instance of <see cref="IHostingEnvironment" />.</param>
        /// <param name="next">The next middleware.</param>
        public ErrorHandlingMiddleware(IHostingEnvironment hostingEnvironment, RequestDelegate next)
        {
            _hostingEnvironment = hostingEnvironment;
            _next = Check.NotNull(next, nameof(next));
        }

        /// <summary>
        ///     Invokes the next middleware catching exceptions.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext"/> to use.</param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unhandled exception in application");

                if (context.Response.HasStarted)
                {
                    Logger.Warn("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }

                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = Constants.JsonContentType;

                if (_hostingEnvironment.IsDevelopment())
                {
                    var result = new
                    {
                        ex.Message,
                        Stacktrace = ex.ToString()
                    };
                    var serialized = JsonConvert.SerializeObject(result);
                    await context.Response.WriteAsync(serialized);
                }
            }
        }
    }
}