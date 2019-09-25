// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Infrastructure
{
    using Microsoft.AspNetCore.Builder;

    /// <summary>
    ///     Provides error handling extensions for <see cref="IApplicationBuilder"/>.
    /// </summary>
    public static class ErrorHandlingMiddlewareExtensions
    {
        /// <summary>
        ///     Adds error handling middlewares to the application's request pipeline.
        /// </summary>
        /// <param name="builder">The <see cref="IApplicationBuilder" /> instance.</param>
        /// <returns>The <see cref="IApplicationBuilder" /> instance.</returns>
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>()
                          .UseMiddleware<BusinessLogicErrorHandlingMiddleware>();
        }
    }
}