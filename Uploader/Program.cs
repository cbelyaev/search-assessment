// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Uploader
{
    using Core;
    using Microsoft.Extensions.DependencyInjection;
    using NLog;
    using NLog.Config;
    using NLog.Targets;
    using UploadModule;
    using UploadModule.Service;

    internal class Program
    {
        private static void Main(string[] args)
        {
            // setup logging
            var loggingConfig = new LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget("consoleTarget")
            {
                Layout = @"[${longdate}] ${level} ${logger}: ${message} ${exception}"
            };
            loggingConfig.AddRuleForAllLevels(consoleTarget);
            LogManager.Configuration = loggingConfig;
            loggingConfig.AddTarget(consoleTarget);

            // setup DI
            var serviceProvider = new ModuleRegistrar().Register<ConfigurationModule>()
                                                       .Register<UploadModule>()
                                                       .Build();
            
            // run
            serviceProvider.GetService<IUploader>().Run();
        }
    }
}