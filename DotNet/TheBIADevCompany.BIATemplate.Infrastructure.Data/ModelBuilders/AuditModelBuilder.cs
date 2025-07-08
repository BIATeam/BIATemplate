// <copyright file="AuditModelBuilder.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.ModelBuilders
{
    using System.Diagnostics;
    using BIA.Net.Core.Infrastructure.Data.ModelBuilders;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class used to update the model builder for user domain.
    /// </summary>
    public class AuditModelBuilder : BaseAuditModelBuilder
    {
        /// <summary>
        /// Create the user model.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public override void CreateModel(ModelBuilder modelBuilder)
        {
            Debug.Assert(modelBuilder != null, "Line to avoid warning empty method");
            base.CreateModel(modelBuilder);

            // Add here the project specific audit model creation.
        }
    }
}
