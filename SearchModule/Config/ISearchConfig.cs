// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace SearchModule.Config
{
    using System.Collections.Immutable;
    using Service;

    /// <summary>
    ///     Provides a configuration for <see cref="ISearchService"/>.
    /// </summary>
    internal interface ISearchConfig
    {
        /// <summary>
        ///     Gets the autorization key for the searcher user.
        /// </summary>
        string KeyId { get; }

        /// <summary>
        ///     Gets the autorization secret key for the searcher user.
        /// </summary>
        string SecretKey { get; }

        /// <summary>
        ///     Gets the service URL for searching in the search domain.
        /// </summary>
        string ServiceUrl { get; }

        /// <summary>
        ///     Gets the search results max count.
        /// </summary>
        int MaxResults { get; }

        /// <summary>
        ///     Gets the stop words list.
        /// </summary>
        IImmutableList<string> StopWords { get; }
    }
}