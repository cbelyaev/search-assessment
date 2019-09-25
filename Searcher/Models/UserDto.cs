// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Models
{
    /// <summary>
    ///     Represents a class for the user view.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        ///     Gets or sets the user identificator.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the user login.
        /// </summary>
        public string Login { get; set; }
    }
}