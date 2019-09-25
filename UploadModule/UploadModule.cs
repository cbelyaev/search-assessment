// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace UploadModule
{
    using System.Collections.Generic;
    using AutoMapper;
    using Config;
    using Core;
    using Core.Util;
    using Mapping;
    using Microsoft.Extensions.DependencyInjection;
    using Read;
    using Service;

    /// <summary>
    ///     Represents a module for searching.
    /// </summary>
    public class UploadModule : IModule
    {
        public void Register(IServiceCollection services, IList<Profile> mappingProfiles)
        {
            Check.NotNull(services, nameof(services));
            Check.NotNull(mappingProfiles, nameof(mappingProfiles));

            // services
            services.AddSingleton<IUploaderConfig, UploaderConfig>()
                    .AddSingleton<IReadService, ReadService>()
                    .AddSingleton<IUploader, Uploader>();

            // profiles
            mappingProfiles.Add(new DocumentMappingProfile());
        }
    }
}