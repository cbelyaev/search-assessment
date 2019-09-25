// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace UploadModule.Config
{
    using System;
    using Service;

    /// <summary>
    ///     Represents an interface to the <see cref="IUploader"/> configuration.
    /// </summary>
    internal interface IUploaderConfig
    {
        /// <summary>
        ///     Gets the autorization key for the uploader user.
        /// </summary>
        string KeyId { get; }

        /// <summary>
        ///     Get the autorization secret key for the uploader user.
        /// </summary>
        string SecretKey { get; }

        /// <summary>
        ///     Get the service URL for uploading data to the search domain.
        /// </summary>
        string ServiceUrl { get; }

        /// <summary>
        ///     Gets the upload batch size in bytes.
        /// </summary>
        int BatchSize { get; }

        /// <summary>
        ///     Get the timeout for batch upload request in ms.
        /// </summary>
        TimeSpan Timeout { get; }

        /// <summary>
        ///     Gets the path to properties.json.
        /// </summary>
        string BuildingsFilePath { get; }

        /// <summary>
        ///     Gets the path to mgmt.json.
        /// </summary>
        string CompaniesFilePath { get; }
    }
}