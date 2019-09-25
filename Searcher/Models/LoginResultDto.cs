// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Models
{
    /// <summary>
    ///     Represents a class for the user login result.
    /// </summary>
    public class LoginResultDto
    {
        /// <summary>
        ///     Gets or sets the <see cref="UserDto"/> instance.
        /// </summary>
        public UserDto User { get; set; }

        /// <summary>
        ///     Gets or sets the security token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        ///     Gets or sets the error message.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}