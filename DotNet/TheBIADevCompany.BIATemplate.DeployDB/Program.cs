// <copyright file="Program.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.DeployDB
{
    using System;
    using System.Threading.Tasks;
    using BIA.Net.Core.Application.Archive;
    using BIA.Net.Core.Application.Clean;
    using Hangfire;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using NLog;
    using NLog.Extensions.Hosting;
    using NLog.Extensions.Logging;
    using TheBIADevCompany.BIATemplate.Application.Job;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common;
    using TheBIADevCompany.BIATemplate.Infrastructure.Data;

    /// <summary>
    /// The base program class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main method that start the project.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <returns>Task.</returns>
        public static async Task Main(string[] args)
        {
            await new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable(Constants.Application.Environment)}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                .ConfigureServices((hostingContext, services) =>
                {
                    IConfiguration configuration = hostingContext.Configuration;

                    services.AddDbContext<DataContext>(options =>
                    {
                        options.UseSqlServer(configuration.GetConnectionString("ProjectDatabase"));
                    });
                    services.AddHostedService<DeployDBService>();

                    // Comment those lines if you do not use hangfire
                    services.AddHangfireServer(hfOptions =>
                    {
                        hfOptions.ServerName = "DeployHangfireDB";
                        hfOptions.Queues = new string[] { "Deploy" };
                    });
                    services.AddHangfire(config =>
                    {
                        config.UseSqlServerStorage(configuration.GetConnectionString("ProjectDatabase"));

                        // Initialize here the recuring jobs
#if BIA_FRONT_FEATURE
                        string projectName = configuration["Project:Name"];
                        RecurringJob.AddOrUpdate<WakeUpTask>($"{projectName}.{typeof(WakeUpTask).Name}", t => t.Run(), configuration["Tasks:WakeUp:CRON"]);
                        RecurringJob.AddOrUpdate<SynchronizeUserTask>($"{projectName}.{typeof(SynchronizeUserTask).Name}", t => t.Run(), configuration["Tasks:SynchronizeUser:CRON"]);
#endif
                    });
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    IConfiguration configuration = hostingContext.Configuration;
                    LogManager.Configuration = new NLogLoggingConfiguration(configuration.GetSection("NLog"));
                    LogManager.GetCurrentClassLogger().Info($"{Constants.Application.Environment}: {Environment.GetEnvironmentVariable(Constants.Application.Environment)}");
                })
                .UseNLog()
                .RunConsoleAsync();
        }
    }
}
