// <copyright file="Worker.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.WorkerService
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using BIA.Net.Core.WorkerService;
    using Hangfire;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using TheBIADevCompany.BIATemplate.WorkerService.Job;

    /// <summary>
    /// Worker class.
    /// </summary>
    public class Worker : BackgroundService
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<Worker> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Worker"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public Worker(
            IConfiguration configuration,
            ILogger<Worker> logger)
        {
            this.Configuration = configuration;
            this.logger = logger;
            string projectName = configuration["Project:Name"];

            try
            {
                // RecuringJobsHelper.CleanHangfireServerQueue()
                RecurringJob.AddOrUpdate<WakeUpTask>($"{projectName}.{typeof(WakeUpTask).Name}", t => t.Run(), configuration["Tasks:WakeUp:CRON"]);
                RecurringJob.AddOrUpdate<SynchronizeUserTask>($"{projectName}.{typeof(SynchronizeUserTask).Name}", t => t.Run(), configuration["Tasks:SynchronizeUser:CRON"]);
            }
            catch (Exception)
            {
                this.logger.LogWarning("Cannot create reccuring job... Probably database is read only...");
            }
        }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        private IConfiguration Configuration { get; set; }

        /// <summary>
        /// This method is called when the <see cref="T:Microsoft.Extensions.Hosting.IHostedService" /> starts. The implementation should return a task that represents
        /// the lifetime of the long running operation(s) being performed.
        /// </summary>
        /// <param name="stoppingToken">Triggered when <see cref="M:Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)" /> is called.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ": BIATemplate Server started.");
        }
    }
}
