// <copyright file="TranslationModelBuilder.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.ModelBuilders
{
    using BIA.Net.Core.Domain.TranslationModule.Aggregate;
    using Microsoft.EntityFrameworkCore;
    using TheBIADevCompany.BIATemplate.Domain.TranslationModule.Aggregate;
    using static TheBIADevCompany.BIATemplate.Crosscutting.Common.Constants;

    /// <summary>
    /// Class used to update the model builder for notification domain.
    /// </summary>
    public static class TranslationModelBuilder
    {
        /// <summary>
        /// Create the user model.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void CreateModel(ModelBuilder modelBuilder)
        {
            CreateLanguageModel(modelBuilder);
            CreateRoleTranslationModel(modelBuilder);
            CreatePermissionTranslationModel(modelBuilder);
            CreateNotificationTypeTranslationModel(modelBuilder);
            CreateNotificationTranslationModel(modelBuilder);
        }

        /// <summary>
        /// Create the model for notification.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void CreateLanguageModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasKey(m => m.Id);
            modelBuilder.Entity<Language>().Property(m => m.Code).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Language>().Property(m => m.Name).HasMaxLength(50);

            modelBuilder.Entity<Language>().HasIndex(u => new { u.Code }).IsUnique();

            modelBuilder.Entity<Language>().HasData(new Language { Id = LanguageId.English, Code = "EN", Name = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = LanguageId.French, Code = "FR", Name = "Fran�ais" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = LanguageId.Spanish, Code = "ES", Name = "Espa�ola" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = LanguageId.German, Code = "DE", Name = "Deutsch" });
        }

        /// <summary>
        /// Create the model for notification.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void CreateRoleTranslationModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleTranslation>().HasKey(r => r.Id);
            modelBuilder.Entity<RoleTranslation>().Property(r => r.RoleId).IsRequired();
            modelBuilder.Entity<RoleTranslation>().Property(r => r.LanguageId).IsRequired();

            modelBuilder.Entity<RoleTranslation>().HasIndex(u => new { u.RoleId, u.LanguageId }).IsUnique();

            modelBuilder.Entity<RoleTranslation>().Property(r => r.Label).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<RoleTranslation>().HasData(new RoleTranslation { RoleId = 1, LanguageId = LanguageId.French, Id = 101, Label = "Administrateur du site" });
            modelBuilder.Entity<RoleTranslation>().HasData(new RoleTranslation { RoleId = 1, LanguageId = LanguageId.Spanish, Id = 102, Label = "Administrador del sitio" });
            modelBuilder.Entity<RoleTranslation>().HasData(new RoleTranslation { RoleId = 1, LanguageId = LanguageId.German, Id = 103, Label = "Seitenadministrator" });
        }

        /// <summary>
        /// Create the model for notification.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void CreatePermissionTranslationModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionTranslation>().HasKey(r => r.Id);
            modelBuilder.Entity<PermissionTranslation>().Property(r => r.PermissionId).IsRequired();
            modelBuilder.Entity<PermissionTranslation>().Property(r => r.LanguageId).IsRequired();

            modelBuilder.Entity<PermissionTranslation>().HasIndex(u => new { u.PermissionId, u.LanguageId }).IsUnique();

            modelBuilder.Entity<PermissionTranslation>().Property(r => r.Label).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<PermissionTranslation>().HasData(new PermissionTranslation { PermissionId = 1, LanguageId = LanguageId.French, Id = 101, Label = "Administrateur du site" });
            modelBuilder.Entity<PermissionTranslation>().HasData(new PermissionTranslation { PermissionId = 1, LanguageId = LanguageId.Spanish, Id = 102, Label = "Administrador del sitio" });
            modelBuilder.Entity<PermissionTranslation>().HasData(new PermissionTranslation { PermissionId = 1, LanguageId = LanguageId.German, Id = 103, Label = "Seitenadministrator" });
        }

        /// <summary>
        /// Create the model for notification.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void CreateNotificationTypeTranslationModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotificationTypeTranslation>().HasKey(r => r.Id);
            modelBuilder.Entity<NotificationTypeTranslation>().Property(r => r.NotificationTypeId).IsRequired();
            modelBuilder.Entity<NotificationTypeTranslation>().Property(r => r.LanguageId).IsRequired();
            modelBuilder.Entity<NotificationTypeTranslation>().HasIndex(u => new { u.NotificationTypeId, u.LanguageId }).IsUnique();

            modelBuilder.Entity<NotificationTypeTranslation>().Property(r => r.Label).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 1, LanguageId = LanguageId.French, Id = 101, Label = "T�che" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 1, LanguageId = LanguageId.Spanish, Id = 102, Label = "Tarea" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 1, LanguageId = LanguageId.German, Id = 103, Label = "Aufgabe" });

            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 2, LanguageId = LanguageId.French, Id = 201, Label = "Information" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 2, LanguageId = LanguageId.Spanish, Id = 202, Label = "Informaci�n" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 2, LanguageId = LanguageId.German, Id = 203, Label = "Information" });

            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 3, LanguageId = LanguageId.French, Id = 301, Label = "Succ�s" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 3, LanguageId = LanguageId.Spanish, Id = 302, Label = "�xito" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 3, LanguageId = LanguageId.German, Id = 303, Label = "Erfolg" });

            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 4, LanguageId = LanguageId.French, Id = 401, Label = "Avertissement" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 4, LanguageId = LanguageId.Spanish, Id = 402, Label = "Advertencia" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 4, LanguageId = LanguageId.German, Id = 403, Label = "Erw�rmen" });

            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 5, LanguageId = LanguageId.French, Id = 501, Label = "Erreur" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 5, LanguageId = LanguageId.Spanish, Id = 502, Label = "Culpa" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = 5, LanguageId = LanguageId.German, Id = 503, Label = "Fehler" });
        }

        /// <summary>
        /// Create the model for notification.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void CreateNotificationTranslationModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotificationTranslation>().HasKey(r => r.Id);
            modelBuilder.Entity<NotificationTranslation>().Property(r => r.NotificationId).IsRequired();
            modelBuilder.Entity<NotificationTranslation>().Property(r => r.LanguageId).IsRequired();
            modelBuilder.Entity<NotificationTranslation>().HasIndex(u => new { u.NotificationId, u.LanguageId }).IsUnique();

            modelBuilder.Entity<NotificationTranslation>().Property(m => m.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<NotificationTranslation>().Property(m => m.Description).IsRequired().HasMaxLength(256);
        }
    }
}
