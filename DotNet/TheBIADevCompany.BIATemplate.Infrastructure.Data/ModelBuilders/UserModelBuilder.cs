// <copyright file="UserModelBuilder.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.ModelBuilders
{
    using BIA.Net.Core.Domain.User.Entities;
    using BIA.Net.Core.Infrastructure.Data.ModelBuilders;
    using Microsoft.EntityFrameworkCore;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common.Enum;

    /// <summary>
    /// Class used to update the model builder for user domain.
    /// </summary>
    public partial class UserModelBuilder : BaseUserModelBuilder
    {
        /// <inheritdoc />
        public override void CreateModel(ModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateUserModel(ModelBuilder modelBuilder)
        {
            base.CreateUserModel(modelBuilder);
            BiaCreateUserModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateUserModelData(ModelBuilder modelBuilder)
        {
            base.CreateUserModelData(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateRoleModel(ModelBuilder modelBuilder)
        {
            base.CreateRoleModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateRoleModelData(ModelBuilder modelBuilder)
        {
            base.CreateRoleModelData(modelBuilder);
                BiaCreateRoleModelData(modelBuilder);

            // BIAToolKit - Begin RoleModelBuilder
            // BIAToolKit - End RoleModelBuilder
        }

        /// <inheritdoc />
        protected override void CreateUserRoleModel(ModelBuilder modelBuilder)
        {
            base.CreateUserRoleModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateUserRoleModelData(ModelBuilder modelBuilder)
        {
            base.CreateUserRoleModelData(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateTeamTypeModel(ModelBuilder modelBuilder)
        {
            base.CreateTeamTypeModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateTeamTypeModelData(ModelBuilder modelBuilder)
        {
            base.CreateTeamTypeModelData(modelBuilder);
            BiaCreateTeamTypeModelData(modelBuilder);

            // BIAToolKit - Begin TeamTypeModelBuilder
            // BIAToolKit - End TeamTypeModelBuilder
        }

        /// <inheritdoc />
        protected override void CreateTeamTypeRoleModel(ModelBuilder modelBuilder)
        {
            base.CreateTeamTypeRoleModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateTeamTypeRoleModelData(ModelBuilder modelBuilder)
        {
            base.CreateTeamTypeRoleModelData(modelBuilder);
            BiaCreateTeamTypeRoleModelData(modelBuilder);

            modelBuilder.Entity<Role>()
                .HasMany(p => p.TeamTypes)
                .WithMany(r => r.Roles)
                .UsingEntity(rt =>
                {

                    // BIAToolKit - Begin TeamTypeRoleModelBuilder
                    // BIAToolKit - End TeamTypeRoleModelBuilder
                });
        }

        /// <inheritdoc />
        protected override void CreateMemberRoleModel(ModelBuilder modelBuilder)
        {
            base.CreateMemberRoleModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateMemberRoleModelData(ModelBuilder modelBuilder)
        {
            base.CreateMemberRoleModelData(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateTeamModel(ModelBuilder modelBuilder)
        {
            base.CreateTeamModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateTeamModelData(ModelBuilder modelBuilder)
        {
            base.CreateTeamModelData(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateUserDefaultTeamModel(ModelBuilder modelBuilder)
        {
            base.CreateUserDefaultTeamModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateUserDefaultTeamModelData(ModelBuilder modelBuilder)
        {
            base.CreateUserDefaultTeamModelData(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateMemberModel(ModelBuilder modelBuilder)
        {
            base.CreateMemberModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateMemberModelData(ModelBuilder modelBuilder)
        {
            base.CreateMemberModelData(modelBuilder);
        }
    }
}
