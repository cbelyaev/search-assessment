// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Controllers
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Threading.Tasks;
    using Config;
    using Core.Util;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using SearchModule.Items;
    using SearchModule.Service;

    /// <summary>
    ///     Represents acontroller for searching.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SearchController" /> class.
        /// </summary>
        /// <param name="searchService">The search service.</param>
        public SearchController(ISearchService searchService)
        {
            _searchService = Check.NotNull(searchService, nameof(searchService));
        }

        /// <summary>
        ///     Searches for items.
        /// </summary>
        /// <param name="searchQueryDto">The query, markets and max results.</param>
        /// <returns>The sequence of <see cref="FoundItem"/>.</returns>
        [HttpPost("search")]
        public async Task<IEnumerable<FoundItem>> Search([FromBody]SearchQueryDto searchQueryDto)
        {
            var query = searchQueryDto.Query;
            var markets = searchQueryDto.Markets?.ToImmutableList() ?? ImmutableList<string>.Empty;
            var size = searchQueryDto.MaxResults ?? Constants.MaxResults;
            return await _searchService.Search(query, markets, size);
        }
    }
}