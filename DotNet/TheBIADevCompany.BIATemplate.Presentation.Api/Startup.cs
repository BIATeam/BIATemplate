// <copyright file="Startup.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Presentation.Api
{
    using System;
    using System.Security.Principal;
    using BIA.Net.Core.Common;
    using BIA.Net.Core.Common.Configuration;
    using BIA.Net.Core.Common.Configuration.CommonFeature;
    using BIA.Net.Core.Domain.Authentication;
    using BIA.Net.Core.Domain.Service;
    using BIA.Net.Core.Presentation.Api.Features;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.CookiePolicy;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using TheBIADevCompany.BIATemplate.Crosscutting.Ioc;
    using TheBIADevCompany.BIATemplate.Infrastructure.Data.Features;

    /// <summary>
    /// The startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly BiaNetSection biaNetSection;

        /// <summary>
        /// The current environment.
        /// </summary>
        private readonly IWebHostEnvironment currentEnvironment;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="env">The environment.</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.currentEnvironment = env;
            this.configuration = configuration;
            this.biaNetSection = new BiaNetSection();
            this.configuration.GetSection("BiaNet").Bind(this.biaNetSection);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The collection of services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.AddResponseCompression();

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true; // Enforce HSTS on all Sub-Domains as well
                options.MaxAge = TimeSpan.FromDays(365); // One year expiry
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.Secure = CookieSecurePolicy.Always;
                options.HttpOnly = HttpOnlyPolicy.None;
            });

            // Used to get a unique identifier for each HTTP request and track it.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(provider => new BIAClaimsPrincipal(provider.GetService<IHttpContextAccessor>().HttpContext.User));
            services.AddTransient<UserContext>(provider => new UserContext(provider.GetService<IHttpContextAccessor>().HttpContext.Request.Headers["Accept-Language"].ToString()));

            services.Configure<ClientForHubConfiguration>(
                this.configuration.GetSection("BiaNet:ApiFeatures:ClientForHub"));

            // Begin BIA Standard service
            services.AddBiaApiFeatures(this.biaNetSection.ApiFeatures, this.configuration);

            // End BIA Standard service

            // Configure IoC for classes not in the API project.
            IocContainer.ConfigureContainer(services, this.configuration);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            if (!string.IsNullOrEmpty(this.biaNetSection.Security?.Audience))
            {
                // for Front Angular Dev Do not forget to modify the file launchSettings.json to
                // enable windows authentication on IISExpress ("windowsAuthentication": true,
                // "anonymousAuthentication": true,)
                app.UseCors(x => x
                    .WithOrigins(this.biaNetSection.Security.Audience.Split(","))
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders(BIAConstants.HttpHeaders.TotalCount));
            }

            app.UseResponseCompression();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseBiaApiFeatures<AuditFeature>(this.biaNetSection.ApiFeatures);
        }
    }
}