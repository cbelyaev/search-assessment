// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Infrastructure
{
    using System;
    using System.Threading.Tasks;
    using Config;
    using Core.Exceptions;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a middleware to catch and reports business logic exceptions in the application's request pipeline.
    /// </summary>
    public class BusinessLogicErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BusinessLogicErrorHandlingMiddleware" /> class.
        /// </summary>
        /// <param name="next">The next middleware.</param>
        public BusinessLogicErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        ///     Invokes the next middleware catching business logic exceptions.
        /// </summary>
        /// <param name="context">The <see cref="HttpContext"/> to use.</param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessLogicException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                context.Response.ContentType = Constants.JsonContentType;

                var result = new
                {
                    Message = ex.UserFriendlyMessage,
                    Data = ex.BlErrorData
                };
                var serialized = JsonConvert.SerializeObject(result);
                await context.Response.WriteAsync(serialized);
            }
        }
    }
}