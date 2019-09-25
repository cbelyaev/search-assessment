// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core
{
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Represents a registrar for module's services and mapping profiles.
    /// </summary>
    public class ModuleRegistrar
    {
        /// <summary>
        ///     Registers a module.
        /// </summary>
        /// <typeparam name="T">The type of module to register.</typeparam>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public ModuleRegistrar Register<T>() where T : IModule, new()
        {
            new T().Register(Services, MappingProfiles);
            return this;
        }

        /// <summary>
        ///     Builds <see cref="ServiceProvider"/> for registered services and mapping profiles.
        /// </summary>
        /// <returns>The <see cref="ServiceProvider"/>.</returns>
        public ServiceProvider Build()
        {
            var mapper = new MapperConfiguration(mc => MappingProfiles.ForEach(mc.AddProfile)).CreateMapper();
            Services.AddSingleton(mapper);

            return Services.BuildServiceProvider();
        }

        /// <summary>
        ///     Copies registered services to another <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="destination">The <see cref="IServiceCollection"/> to copy to.</param>
        public void CopyServicesTo(IServiceCollection destination)
        {
            foreach (var service in Services)
            {
                destination.Add(service);
            }
        }

        /// <summary>
        ///     Gets the collection of registered services.
        /// </summary>
        public IServiceCollection Services { get; } = new ServiceCollection();

        /// <summary>
        ///     Gets the collection of registered mapping profiles.
        /// </summary>
        public List<Profile> MappingProfiles { get; } = new List<Profile>();
    }
}