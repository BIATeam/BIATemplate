// <copyright file="TranslationModelBuilder.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.ModelBuilders
{
    using BIA.Net.Core.Common.Enum;
    using BIA.Net.Core.Domain.Translation.Entities;
    using BIA.Net.Core.Infrastructure.Data.ModelBuilders;
    using Microsoft.EntityFrameworkCore;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common.Enum;
    using static TheBIADevCompany.BIATemplate.Crosscutting.Common.Constants;

    /// <summary>
    /// Class used to update the model builder for notification domain.
    /// </summary>
    public partial class TranslationModelBuilder : BaseTranslationModelBuilder
    {
        /// <inheritdoc />
        public override void CreateModel(ModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateLanguageModel(ModelBuilder modelBuilder)
        {
            base.CreateLanguageModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateLanguageModelData(ModelBuilder modelBuilder)
        {
            base.CreateLanguageModelData(modelBuilder);
            BiaCreateLanguageModelData(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateRoleTranslationModel(ModelBuilder modelBuilder)
        {
            base.CreateRoleTranslationModel(modelBuilder);
        }

        /// <inheritdoc />
        protected override void CreateRoleTranslationModelData(ModelBuilder modelBuilder)
        {
            base.CreateRoleTranslationModelData(modelBuilder);
            BiaCreateRoleTranslationModelData(modelBuilder);
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
        }

        /// <summary>
        /// Create the model for notification.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void CreateNotificationTypeTranslationModelData(ModelBuilder modelBuilder)
        {
            base.CreateNotificationTypeTranslationModelData(modelBuilder);
            BiaCreateNotificationTypeTranslationModelData(modelBuilder);
        }

        /// <summary>
        /// Create the model for notification.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void CreateNotificationTranslationModel(ModelBuilder modelBuilder)
        {
            base.CreateNotificationTranslationModel(modelBuilder);
        }

        /// <summary>
        /// Create the model data for notification translation.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void CreateNotificationTranslationModelData(ModelBuilder modelBuilder)
        {
            base.CreateNotificationTranslationModelData(modelBuilder);
        }

        /// <summary>
        /// Create the model for announcement type translation.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void CreateAnnouncementTypeTranslationModel(ModelBuilder modelBuilder)
        {
            base.CreateAnnouncementTypeTranslationModel(modelBuilder);
        }

        /// <summary>
        /// Create the model for announcement type translation.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void CreateAnnouncementTypeTranslationModelData(ModelBuilder modelBuilder)
        {
            base.CreateAnnouncementTypeTranslationModelData(modelBuilder);
            BiaCreateAnnouncementTypeTranslationModelData(modelBuilder);
        }
    }
}
