// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace UserModule.Service
{
    using System.Collections.Immutable;
    using System.Linq;
    using System.Threading.Tasks;
    using Core.Util;
    using Items;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    ///     Represents an user service.
    /// </summary>
    internal class UserService : IUserService
    {
        private readonly IPasswordHasher<User> _hasher;
        private readonly ImmutableList<User> _users;

        public UserService(IPasswordHasher<User> hasher)
        {
            _hasher = Check.NotNull(hasher, nameof(hasher));

            var user = new User
            {
                Id = 1,
                Login = "user",
            };
            user.PasswordHash = _hasher.HashPassword(user, "qwerty");
            _users = new[] { user }.ToImmutableList();
        }

        public Task<User> LoginAsync(string login, string password)
        {
            return Task.FromResult(Login(login, password));
        }

        private User Login(string login, string password)
        {
            var user = _users.FirstOrDefault(u => string.CompareOrdinal(u.Login, login) == 0);
            if (user == null)
            {
                return null;
            }

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Failed ? null : user;
        }
    }
}