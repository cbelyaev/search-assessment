// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Infrastructure
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Provides static methods to work with configuration.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        ///     Registers the configuration section and binds it to a new instance of type T.
        /// </summary>
        /// <typeparam name="T">The type of options being configured.</typeparam>
        /// <param name="configSection">The configuration being bound.</param>
        /// <param name="serviceCollection">The <see cref="IServiceCollection" /> to add the services to.</param>
        /// <returns></returns>
        public static T ConfigAndGet<T>(this IConfigurationSection configSection, IServiceCollection serviceCollection) 
            where T : class
        {
            serviceCollection.Configure<T>(configSection);
            return configSection.Get<T>();
        }

        /// <summary>
        ///     Gets the configuration section, registers it and binds it to a new instance of type T.
        /// </summary>
        /// <typeparam name="T">The type of options being configured.</typeparam>
        /// <param name="configuration">The configuration object.</param>
        /// <param name="serviceCollection">The <see cref="IServiceCollection" /> to add the services to.</param>
        /// <param name="sectionKey">The key of the configuration section.</param>
        /// <returns></returns>
        public static T ConfigAndGet<T>(this IConfiguration configuration, IServiceCollection serviceCollection, string sectionKey) 
            where T : class
        {
            var section = configuration.GetSection(sectionKey);
            return section.ConfigAndGet<T>(serviceCollection);
        }
    }
}