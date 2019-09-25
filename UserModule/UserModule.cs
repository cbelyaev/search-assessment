// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace UserModule
{
    using System.Collections.Generic;
    using AutoMapper;
    using Core;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Service;
    using Items;

    /// <summary>
    ///     Represents a module for user service.
    /// </summary>
    public class UserModule : IModule
    {
        public void Register(IServiceCollection services, IList<Profile> mappingProfiles)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        }
    }
}