// <copyright file="BIATemplateWebApiRepository.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Service.Repositories
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using BIA.Net.Core.Infrastructure.Service.Repositories;
    using BIA.Net.Core.Infrastructure.Service.Repositories.Helper;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using TheBIADevCompany.BIATemplate.Domain.RepoContract;

    /// <summary>
    /// WorkInstruction Repository.
    /// </summary>
    /// <seealso cref="TheBIADevCompany.BIATemplate.Domain.RepoContract.IWorkInstructionRepository" />
#pragma warning disable S101 // Types should be named in PascalCase
    public class BIATemplateWebApiRepository : WebApiRepository, IBIATemplateWebApiRepository
#pragma warning restore S101 // Types should be named in PascalCase
    {
        private readonly string baseAddress;
        private readonly string urlWakeUp;

        /// <summary>
        /// Initializes a new instance of the <see cref="BIATemplateWebApiRepository"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="distributedCache">The distributed cache.</param>
        public BIATemplateWebApiRepository(HttpClient httpClient, IConfiguration configuration, ILogger<WebApiRepository> logger, IBiaDistributedCache distributedCache)
             : base(httpClient, logger, distributedCache)
        {
            this.baseAddress = configuration["BIATemplateWebApi:baseAddress"];
            this.urlWakeUp = configuration["BIATemplateWebApi:urlWakeUp"];
        }

        /// <inheritdoc/>
        public virtual async Task<(bool IsSuccessStatusCode, string ReasonPhrase)> WakeUp()
        {
            if (string.IsNullOrWhiteSpace(this.baseAddress))
            {
                return (false, "Base adresse not set.");
            }

            var result = await this.GetAsync<string>(this.baseAddress + this.urlWakeUp);
            return (result.IsSuccessStatusCode, result.ReasonPhrase);
        }
    }
}
