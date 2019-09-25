// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Represents a class for user authentication request.
    /// </summary>
    public class UserLoginDto
    {
        /// <summary>
        ///     Gets or sets the user login.
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        ///     Gets or sets the user password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}