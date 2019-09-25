// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace SearchModule
{
    using System.Collections.Generic;
    using AutoMapper;
    using Config;
    using Core;
    using Core.Util;
    using Mapping;
    using Microsoft.Extensions.DependencyInjection;
    using Service;

    /// <summary>
    ///     Represents a module for searching.
    /// </summary>
    public class SearchModule: IModule
    {
        public void Register(IServiceCollection services, IList<Profile> mappingProfiles)
        {
            Check.NotNull(services, nameof(services));
            Check.NotNull(mappingProfiles, nameof(mappingProfiles));

            services.AddSingleton<ISearchConfig, SearchConfig>()
                    .AddScoped<ISearchService, SearchService>();

            mappingProfiles.Add(new DocumentMappingProfile());
        }
    }
}