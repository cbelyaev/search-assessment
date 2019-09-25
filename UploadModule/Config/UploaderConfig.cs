// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace UploadModule.Config
{
    using System;
    using Core.Util;
    using Microsoft.Extensions.Configuration;
    using Service;

    /// <summary>
    ///     Represents a configuration for <see cref="IUploader"/>
    /// </summary>
    internal sealed class UploaderConfig : IUploaderConfig
    {
        private const string AuthSection = "auth";
        private const string LimitsSection = "limits";
        private const string FilesSection = "files";

        private const string AccessKeyIdValueKey = "awsAccessKeyId";
        private const string SecretAccessKeyValueKey = "awsSecretAccessKey";
        private const string ServiceUrlKey = "serviceURL";
        private const string BatchSizeKey = "batchSize";
        private const string TimeoutKey = "batchSize";
        private const string BuildingsKey = "buildingsFilePath";
        private const string CompaniesKey = "companiesFilePath";

        private const int DefaultBatchSize = 5 * 1024 * 1024;
        private const int DefaultTimeout = 5000;

        private readonly IConfiguration _configuration;

        public UploaderConfig(IConfiguration configuration)
        {
            _configuration = Check.NotNull(configuration, nameof(configuration));
        }

        public string KeyId => _configuration.GetSection(AuthSection)?[AccessKeyIdValueKey];

        public string SecretKey => _configuration.GetSection(AuthSection)?[SecretAccessKeyValueKey];

        public string ServiceUrl => _configuration.GetSection(AuthSection)?[ServiceUrlKey];

        public int BatchSize
        {
            get
            {
                var text = _configuration.GetSection(LimitsSection)?[BatchSizeKey];
                return int.TryParse(text, out var batchSize) ? batchSize : DefaultBatchSize;
            }
        }

        public TimeSpan Timeout
        {
            get
            {
                var text = _configuration.GetSection(LimitsSection)?[TimeoutKey];
                var milis = int.TryParse(text, out var timeout) ? timeout : DefaultTimeout;
                return TimeSpan.FromMilliseconds(milis);
            }
        }

        public string BuildingsFilePath => _configuration.GetSection(FilesSection)?[BuildingsKey];

        public string CompaniesFilePath => _configuration.GetSection(FilesSection)?[CompaniesKey];
    }
}