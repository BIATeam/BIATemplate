// <copyright file="DataContextReadOnly.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data
{
    using BIA.Net.Core.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using TheBIADevCompany.BIATemplate.Domain.SiteModule.Aggregate;
    using TheBIADevCompany.BIATemplate.Domain.UserModule.Aggregate;
    using TheBIADevCompany.BIATemplate.Domain.ViewModule.Aggregate;
    using TheBIADevCompany.BIATemplate.Infrastructure.Data.ModelBuilders;

    /// <summary>
    /// The database context.
    /// </summary>
    public class DataContextReadOnly : DataContext, IQueryableUnitOfWorkReadOnly
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContextReadOnly"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="logger">The logger.</param>
        public DataContextReadOnly(DbContextOptions<DataContext> options, ILogger<DataContextReadOnly> logger)
            : base(options, logger)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
