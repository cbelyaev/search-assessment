// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Mapping
{
    using Models;
    using AutoMapper;
    using UserModule.Items;

    /// <summary>
    ///     Represents a mapping for user item.
    /// </summary>
    internal class UserMappingProfile: Profile
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UserMappingProfile" /> class.
        /// </summary>
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, LoginResultDto>();
        }
    }
}