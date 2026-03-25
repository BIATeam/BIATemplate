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
        }

        /// <inheritdoc/>
        protected override void CreateAuditLogModel(ModelBuilder modelBuilder)
        {
            base.CreateAuditLogModel(modelBuilder);
        }

        /// <inheritdoc/>
        protected override void CreateUserAuditModel<TAuditUser, TUser>(ModelBuilder modelBuilder)
        {
            base.CreateUserAuditModel<TAuditUser, TUser>(modelBuilder);
        }

#if BIA_FRONT_FEATURE
#endif
    }
}
