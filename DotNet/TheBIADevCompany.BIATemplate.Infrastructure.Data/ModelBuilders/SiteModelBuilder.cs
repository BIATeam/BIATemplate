// <copyright file="SiteModelBuilder.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.ModelBuilders
{
    using Microsoft.EntityFrameworkCore;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common.Enum;
    using TheBIADevCompany.BIATemplate.Domain.Site.Entities;

    /// <summary>
    /// Class used to update the model builder for site domain.
    /// </summary>
    public static class SiteModelBuilder
    {
        /// <summary>
        /// Create the model for sites.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void CreateSiteModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>().ToTable("Sites");
        }
    }
}