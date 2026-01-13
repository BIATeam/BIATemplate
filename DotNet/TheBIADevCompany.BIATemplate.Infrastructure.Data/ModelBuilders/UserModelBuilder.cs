// <copyright file="UserModelBuilder.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.ModelBuilders
{
    using BIA.Net.Core.Common.Enum;
    using BIA.Net.Core.Domain.User.Entities;
    using BIA.Net.Core.Infrastructure.Data.ModelBuilders;
    using Microsoft.EntityFrameworkCore;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common.Enum;
    using TheBIADevCompany.BIATemplate.Domain.User.Entities;

    /// <summary>
    /// Class used to update the model builder for user domain.
    /// </summary>
    public class UserModelBuilder : BaseUserModelBuilder
    {
        /// <summary>
        /// Create the model for users.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void CreateUserModel(ModelBuilder modelBuilder)
        {
            base.CreateUserModel(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Email).HasMaxLength(256);
#if BIA_USER_CUSTOM_FIELDS_BACK
                entity.Property(u => u.DistinguishedName).IsRequired().HasMaxLength(250);
                entity.Property(u => u.IsEmployee);
                entity.Property(u => u.IsExternal);
                entity.Property(u => u.ExternalCompany).HasMaxLength(50);
                entity.Property(u => u.Company).HasMaxLength(50);
                entity.Property(u => u.Site).HasMaxLength(50);
                entity.Property(u => u.Manager).HasMaxLength(250);
                entity.Property(u => u.Department).HasMaxLength(50);
                entity.Property(u => u.SubDepartment).HasMaxLength(50);
                entity.Property(u => u.Office).HasMaxLength(20);
                entity.Property(u => u.Country).HasMaxLength(10);
#endif
            });
        }

        /// <summary>
        /// Create the model for teams.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void CreateTeamTypeModel(ModelBuilder modelBuilder)
        {
            base.CreateTeamTypeModel(modelBuilder);

            modelBuilder.Entity<TeamType>().HasData(new TeamType { Id = (int)TeamTypeId.Site, Name = "Site" });

            // BIAToolKit - Begin TeamTypeModelBuilder
            // BIAToolKit - End TeamTypeModelBuilder
        }

        /// <summary>
        /// Create the model for roles.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void CreateRoleModel(ModelBuilder modelBuilder)
        {
            base.CreateRoleModel(modelBuilder);

            modelBuilder.Entity<Role>().HasData(new Role { Id = (int)BiaRoleId.Admin, Code = "Admin", Label = "Administrator" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = (int)BiaRoleId.BackAdmin, Code = "Back_Admin", Label = "Background task administrator" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = (int)BiaRoleId.BackReadOnly, Code = "Back_Read_Only", Label = "Visualization of background tasks" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = (int)RoleId.SiteAdmin, Code = "Site_Admin", Label = "Site administrator" });

            // BIAToolKit - Begin RoleModelBuilder
            // BIAToolKit - End RoleModelBuilder
        }

        /// <summary>
        /// Create the model for member roles.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void CreateTeamTypeRoleModel(ModelBuilder modelBuilder)
        {
            base.CreateTeamTypeRoleModel(modelBuilder);

            modelBuilder.Entity<Role>()
                .HasMany(p => p.TeamTypes)
                .WithMany(r => r.Roles)
                .UsingEntity(rt =>
                {
                    rt.ToTable("RoleTeamTypes");
                    rt.HasData(new { TeamTypesId = (int)BiaTeamTypeId.Root, RolesId = (int)BiaRoleId.Admin });
                    rt.HasData(new { TeamTypesId = (int)BiaTeamTypeId.Root, RolesId = (int)BiaRoleId.BackAdmin });
                    rt.HasData(new { TeamTypesId = (int)BiaTeamTypeId.Root, RolesId = (int)BiaRoleId.BackReadOnly });
                    rt.HasData(new { TeamTypesId = (int)TeamTypeId.Site, RolesId = (int)RoleId.SiteAdmin });

                    // BIAToolKit - Begin TeamTypeRoleModelBuilder
                    // BIAToolKit - End TeamTypeRoleModelBuilder
                });
        }
    }
}
