// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Config
{
    /// <summary>
    ///     Provides constants.
    /// </summary>
    internal static class Constants
    {
        public const string ApiName = "Searcher API";
        public const string ApiVersion = "v1";
        public const string ApiDescription = "Web API for Searcher Assessment project.";
        public const string ApiUrl = "/swagger/" + ApiVersion + "/swagger.json";

        public const string JwtSectionKey = "Jwt";
        public const string JwtClaim = "user";

        public const string JsonContentType = "application/json";

        public const int MaxResults = 25;
    }
}