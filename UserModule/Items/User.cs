// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace UserModule.Items
{
    /// <summary>
    ///     Represents the user entity.
    /// </summary>
    public class User
    {
        /// <summary>
        ///     Gets or sets the user identificator.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the user login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        ///     Gets or sets the user password hash.
        /// </summary>
        public string PasswordHash { get; set; }
    }
}