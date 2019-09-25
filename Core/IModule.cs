// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core
{
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Defines a method that a module's implements to register its services and mapping profiles.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        ///     Registers module's services and mapping profiles.
        /// </summary>
        /// <param name="services">The collection to add modules's services to.</param>
        /// <param name="mappingProfiles">The collection to add module's mapping profiles to.</param>
        void Register(IServiceCollection services, IList<Profile> mappingProfiles);
    }
}