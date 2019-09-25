// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace UserModule.Service
{
    using System.Threading.Tasks;
    using Items;

    /// <summary>
    ///     Represents an interface for the user service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///     Authenticates the user with a login and password.
        /// </summary>
        /// <param name="login">The user login.</param>
        /// <param name="password">The user password.</param>
        /// <returns>The <see cref="User"/> object for successfully authenticated user. Otherwise returns null.</returns>
        Task<User> LoginAsync(string login, string password);
    }
}