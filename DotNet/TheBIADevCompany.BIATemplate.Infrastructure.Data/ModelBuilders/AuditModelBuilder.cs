// <copyright file="AuditModelBuilder.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.ModelBuilders
{
    using BIA.Net.Core.Infrastructure.Data.ModelBuilders;
    using Microsoft.EntityFrameworkCore;
#if BIA_FRONT_FEATURE
    using TheBIADevCompany.BIATemplate.Domain.User.Entities;
#endif

    /// <summary>
    /// Class used to update the model builder for audits.
    /// </summary>
    public class AuditModelBuilder : BaseAuditModelBuilder
    {
        /// <inheritdoc/>
        public override void CreateModel(ModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);
#if BIA_FRONT_FEATURE
            this.CreateUserAuditModel<UserAudit, User>(modelBuilder);
#endif

            // Add here the project specific audit model creation.
        }
    }
}
