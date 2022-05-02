// <copyright file="AuditModelBuilder.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.ModelBuilders
{
    using Microsoft.EntityFrameworkCore;
    using TheBIADevCompany.BIATemplate.Domain.Audit.Aggregate;
    using TheBIADevCompany.BIATemplate.Domain.PlaneModule.Aggregate;
    using TheBIADevCompany.BIATemplate.Domain.UserModule.Aggregate;

    /// <summary>
    /// Class used to update the model builder for user domain.
    /// </summary>
    public static class AuditModelBuilder
    {
        /// <summary>
        /// Create the user model.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void CreateModel(ModelBuilder modelBuilder)
        {
            CreateUserAuditModel(modelBuilder);
            CreateAuditModel(modelBuilder);
        }

        /// <summary>
        /// Create the model for users.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void CreateAuditModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>().HasKey(u => new { u.Id });
            modelBuilder.Entity<AuditLog>().Property(u => u.Table).IsRequired().HasMaxLength(50);
        }

        /// <summary>
        /// Create the model for users.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void CreateUserAuditModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAudit>().HasKey(u => new { u.AuditId });
            modelBuilder.Entity<UserAudit>().Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<UserAudit>().Property(u => u.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<UserAudit>().Property(u => u.Login).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<UserAudit>().Property(u => u.Domain).IsRequired().HasDefaultValue("--");
        }
    }
}
