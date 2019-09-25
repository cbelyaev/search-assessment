// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Represents a search query options.
    /// </summary>
    public class SearchQueryDto
    {
        /// <summary>
        ///     Get or sets the query.
        /// </summary>
        [Required]
        public string Query { get; set; }

        /// <summary>
        ///     Gets or sets the sequence of markets to filter results.
        /// </summary>
        public IEnumerable<string> Markets { get; set; }

        /// <summary>
        ///     Gets or sets the max number of search results.
        /// </summary>
        public int? MaxResults { get; set; }
    }
}