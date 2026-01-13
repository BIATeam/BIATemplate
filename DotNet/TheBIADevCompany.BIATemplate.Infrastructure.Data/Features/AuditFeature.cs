// <copyright file="AuditFeature.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.Features
{
    using System;
    using BIA.Net.Core.Common.Configuration.CommonFeature;
    using BIA.Net.Core.Infrastructure.Data.Features;
    using Microsoft.Extensions.Options;

    // BIAToolKit - Begin AuditTypeMapperUsing
    // BIAToolKit - End AuditTypeMapperUsing
#if BIA_FRONT_FEATURE
    using TheBIADevCompany.BIATemplate.Domain.User.Entities;
#endif

    /// <summary>
    /// The Audit Feature.
    /// </summary>
    /// <param name="commonFeaturesConfigurationOptions">The common features configuration options.</param>
    /// <param name="serviceProvider">The service provider.</param>
    public class AuditFeature(IOptions<CommonFeatures> commonFeaturesConfigurationOptions, IServiceProvider serviceProvider) : BaseAuditFeature(commonFeaturesConfigurationOptions, serviceProvider)
    {
        /// <summary>
        /// Audits the type mapper.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The type of the Audit entity.</returns>
        public override Type AuditTypeMapper(Type type)
        {
            return type.Name switch
            {
                // BIAToolKit - Begin AuditTypeMapper
                // BIAToolKit - End AuditTypeMapper
#if BIA_FRONT_FEATURE
                nameof(User) => typeof(UserAudit),
#endif
                _ => base.AuditTypeMapper(type),
            };
        }
    }
}
