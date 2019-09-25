// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace SearchModule.Config
{
    using System;
    using System.Collections.Immutable;
    using Core.Util;
    using Microsoft.Extensions.Configuration;
    using Service;

    /// <summary>
    ///     Provides a configuration for <see cref="ISearchService"/>.
    /// </summary>
    internal class SearchConfig : ISearchConfig
    {
        private const int DefaultMaxResults = 25;
        private const string AuthSection = "auth";
        private const string LimitsSection = "limits";

        private const string AccessKeyIdValueKey = "awsAccessKeyId";
        private const string SecretAccessKeyValueKey = "awsSecretAccessKey";
        private const string ServiceUrlKey = "serviceURL";
        private const string MaxResultsKey = "maxResults";
        private const string StopWordsKey = "stopWords";

        private readonly IConfiguration _configuration;

        public SearchConfig(IConfiguration configuration)
        {
            _configuration = Check.NotNull(configuration, nameof(configuration));
        }

        public string KeyId => _configuration.GetSection(AuthSection)?[AccessKeyIdValueKey];

        public string SecretKey => _configuration.GetSection(AuthSection)?[SecretAccessKeyValueKey];

        public string ServiceUrl => _configuration.GetSection(AuthSection)?[ServiceUrlKey];

        public int MaxResults
        {
            get
            {
                var text = _configuration.GetSection(LimitsSection)?[MaxResultsKey];
                return int.TryParse(text, out var maxResults) ? maxResults : DefaultMaxResults;
            }
        }

        public IImmutableList<string> StopWords
        {
            get
            {
                var text = _configuration.GetSection(LimitsSection)?[StopWordsKey] ?? string.Empty;
                var stopWords = text.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToImmutableList();
                return stopWords;
            }
        }
    }
}