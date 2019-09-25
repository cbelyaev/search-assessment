// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace SearcherClient
{
    using System;
    using System.Collections.Immutable;
    using System.Text;
    using System.Threading.Tasks;
    using Core;
    using Core.Util;
    using Microsoft.Extensions.DependencyInjection;
    using NLog;
    using NLog.Config;
    using NLog.Targets;
    using SearchModule;
    using SearchModule.Service;

    internal class Program
    {
        private const int DefaultSize = 25;

        private static async Task Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine($"Usage: {nameof(SearcherClient)} \"query\" [\"Market1[,Market2[,...]]\" [size]] ");
                return;
            }

            // parse arguments
            var query = args[0];
            var markets = args.Length > 1 ? args[1].ParseMarkets().ToImmutableList() : ImmutableList<string>.Empty;
            var size = args.Length > 2 ? ParseSize(args[2]) : DefaultSize;

            // setup logging
            SetupLogging();

            // setup DI
            var serviceProvider = new ModuleRegistrar().Register<ConfigurationModule>()
                                                       .Register<SearchModule>()
                                                       .Build();

            // run
            var results = await serviceProvider.GetService<ISearchService>().Search(query, markets, size);
            foreach (var item in results)
            {
                var sb = new StringBuilder($"{item.Id} ({item.ItemType}): {item.Name}");
                if (!string.IsNullOrEmpty(item.FormerName))
                {
                    sb.Append($" ({item.FormerName})");
                }

                sb.Append($" {item.Address}");
                Console.WriteLine(sb.ToString());
            }
        }

        private static void SetupLogging()
        {
            var loggingConfig = new LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget("consoleTarget")
            {
                Layout = @"[${longdate}] ${level} ${logger}: ${message} ${exception}"
            };
            loggingConfig.AddRuleForAllLevels(consoleTarget);
            LogManager.Configuration = loggingConfig;
            loggingConfig.AddTarget(consoleTarget);
        }

        private static int ParseSize(string text)
        {
            return int.TryParse(text, out var size) ? size : DefaultSize;
        }
    }
}