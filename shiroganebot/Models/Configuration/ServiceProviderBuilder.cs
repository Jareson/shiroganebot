using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace shiroganebot.Models.Configuration
{
    public static class ServiceProviderBuilder
    {
        public static IServiceProvider GetServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .AddUserSecrets(typeof(Program).Assembly)
                .Build();
            var services = new ServiceCollection();

            services.Configure<BotSecrets>(configuration.GetSection(typeof(BotSecrets).FullName));

            var provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
