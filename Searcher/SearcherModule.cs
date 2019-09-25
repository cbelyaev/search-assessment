// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher
{
    using System.Collections.Generic;
    using AutoMapper;
    using Core;
    using Mapping;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Represents a class with services and mapping profiles for Web API module.
    /// </summary>
    internal class SearcherModule : IModule
    {
        public void Register(IServiceCollection services, IList<Profile> mappingProfiles)
        {
            mappingProfiles.Add(new UserMappingProfile());
        }
    }
}