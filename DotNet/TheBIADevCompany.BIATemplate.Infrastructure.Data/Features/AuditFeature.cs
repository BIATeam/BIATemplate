// <copyright file="AuditFeature.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.Features
{
    using System;
    using BIA.Net.Core.Common.Configuration.CommonFeature;
    using BIA.Net.Core.Infrastructure.Data.Features;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// The Audit Feature.
    /// </summary>
    public class AuditFeature(IConfiguration configuration, IOptions<CommonFeatures> commonFeaturesConfigurationOptions, IServiceProvider serviceProvider) : BaseAuditFeature(configuration, commonFeaturesConfigurationOptions, serviceProvider)
    {
        /// <summary>
        /// Audits the type mapper.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The type of the Audit entity.</returns>
        protected override Type AuditTypeMapper(Type type)
        {
            switch (type.Name)
            {
                default:
                    return base.AuditTypeMapper(type);
            }
        }
    }
}
