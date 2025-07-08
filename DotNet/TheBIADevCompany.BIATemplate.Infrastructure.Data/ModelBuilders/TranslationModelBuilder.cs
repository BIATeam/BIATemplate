// <copyright file="TranslationModelBuilder.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.ModelBuilders
{
    using System.Diagnostics;
    using BIA.Net.Core.Common.Enum;
    using BIA.Net.Core.Domain.Translation.Entities;
    using BIA.Net.Core.Infrastructure.Data.ModelBuilders;
    using Microsoft.EntityFrameworkCore;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common.Enum;
    using static TheBIADevCompany.BIATemplate.Crosscutting.Common.Constants;

    /// <summary>
    /// Class used to update the model builder for notification domain.
    /// </summary>
    public class TranslationModelBuilder : BaseTranslationModelBuilder
    {
        /// <summary>
        /// Create the user model.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public override void CreateModel(ModelBuilder modelBuilder)
        {
            Debug.Assert(modelBuilder != null, "Line to avoid warning empty method");
            base.CreateModel(modelBuilder);

            // Add here the project specific translation model creation.
        }

        /// <summary>
        /// Create the model for notification.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void CreateLanguageModel(ModelBuilder modelBuilder)
        {
            base.CreateLanguageModel(modelBuilder);
            modelBuilder.Entity<Language>().HasData(new Language { Id = LanguageId.English, Code = "EN", Name = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = LanguageId.French, Code = "FR", Name = "Français" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = LanguageId.Spanish, Code = "ES", Name = "Española" });
        }

        /// <summary>
        /// Create the model for notification.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void CreateRoleTranslationModel(ModelBuilder modelBuilder)
        {
            base.CreateRoleTranslationModel(modelBuilder);

            modelBuilder.Entity<RoleTranslation>().HasData(new RoleTranslation { RoleId = (int)BiaRoleId.Admin, LanguageId = LanguageId.French, Id = 1000101, Label = "Administrateur" });
            modelBuilder.Entity<RoleTranslation>().HasData(new RoleTranslation { RoleId = (int)BiaRoleId.Admin, LanguageId = LanguageId.Spanish, Id = 1000102, Label = "Administrador" });
            modelBuilder.Entity<RoleTranslation>().HasData(new RoleTranslation { RoleId = (int)BiaRoleId.BackAdmin, LanguageId = LanguageId.French, Id = 1000201, Label = "Administrateur des tâches en arrière-plan" });
            modelBuilder.Entity<RoleTranslation>().HasData(new RoleTranslation { RoleId = (int)BiaRoleId.BackAdmin, LanguageId = LanguageId.Spanish, Id = 1000202, Label = "Administrador de tareas en segundo plano" });
            modelBuilder.Entity<RoleTranslation>().HasData(new RoleTranslation { RoleId = (int)BiaRoleId.BackReadOnly, LanguageId = LanguageId.French, Id = 1000301, Label = "Visualisation des tâches en arrière-plan" });
            modelBuilder.Entity<RoleTranslation>().HasData(new RoleTranslation { RoleId = (int)BiaRoleId.BackReadOnly, LanguageId = LanguageId.Spanish, Id = 1000302, Label = "Visualización de tareas en segundo plano" });
            modelBuilder.Entity<RoleTranslation>().HasData(new RoleTranslation { RoleId = (int)RoleId.SiteAdmin, LanguageId = LanguageId.French, Id = 101, Label = "Administrateur du site" });
            modelBuilder.Entity<RoleTranslation>().HasData(new RoleTranslation { RoleId = (int)RoleId.SiteAdmin, LanguageId = LanguageId.Spanish, Id = 102, Label = "Administrador del sitio" });
        }

        /// <summary>
        /// Create the model for notification.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void CreateNotificationTypeTranslationModel(ModelBuilder modelBuilder)
        {
            base.CreateNotificationTypeTranslationModel(modelBuilder);

            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = (int)BiaNotificationTypeId.Task, LanguageId = LanguageId.French, Id = 101, Label = "Tâche" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = (int)BiaNotificationTypeId.Task, LanguageId = LanguageId.Spanish, Id = 102, Label = "Tarea" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = (int)BiaNotificationTypeId.Info, LanguageId = LanguageId.French, Id = 201, Label = "Information" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = (int)BiaNotificationTypeId.Info, LanguageId = LanguageId.Spanish, Id = 202, Label = "Información" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = (int)BiaNotificationTypeId.Success, LanguageId = LanguageId.French, Id = 301, Label = "Succès" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = (int)BiaNotificationTypeId.Success, LanguageId = LanguageId.Spanish, Id = 302, Label = "Éxito" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = (int)BiaNotificationTypeId.Warning, LanguageId = LanguageId.French, Id = 401, Label = "Avertissement" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = (int)BiaNotificationTypeId.Warning, LanguageId = LanguageId.Spanish, Id = 402, Label = "Advertencia" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = (int)BiaNotificationTypeId.Error, LanguageId = LanguageId.French, Id = 501, Label = "Erreur" });
            modelBuilder.Entity<NotificationTypeTranslation>().HasData(new NotificationTypeTranslation { NotificationTypeId = (int)BiaNotificationTypeId.Error, LanguageId = LanguageId.Spanish, Id = 502, Label = "Culpa" });
        }
    }
}
