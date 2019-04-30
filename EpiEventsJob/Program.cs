using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using Microsoft.Azure.WebJobs;

namespace ConsoleSdkJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        private static InitializationEngine _engine;

        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var config = new JobHostConfiguration();
            config.UseTimers();
            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            Console.WriteLine("Starting WebJob");
            _engine = new InitializationEngine((IEnumerable<IInitializableModule>)null, HostType.WebApplication, new AssemblyList(true).AllowedAssemblies);
            Console.WriteLine("Episerver Initialization");
            _engine.Initialize();

            var cancellationToken = new WebJobsShutdownWatcher().Token;
            cancellationToken.Register(() =>
            {
                Console.WriteLine("Episerver Uninitialization");
                _engine.Uninitialize();
            });

            var host = new JobHost(config);
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
    }
}
