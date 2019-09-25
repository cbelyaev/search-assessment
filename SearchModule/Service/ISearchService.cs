// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace SearchModule.Service
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Threading.Tasks;
    using Items;

    /// <summary>
    ///     Provides methods for searching.
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        ///     Searches the items.
        /// </summary>
        /// <param name="query">The query to search items.</param>
        /// <param name="markets">The collection of markets to search in.</param>
        /// <param name="maxResults">The maximum numbers of search results.</param>
        /// <returns>The sequence of <see cref="FoundItem"/>.</returns>
        Task<IEnumerable<FoundItem>> Search(string query, IImmutableList<string> markets, int maxResults);
    }
}