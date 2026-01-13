// <copyright file="Site.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.Site.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Audit.EntityFramework;
    using BIA.Net.Core.Domain.Entity.Interface;
    using BIA.Net.Core.Domain.User.Entities;

    /// <summary>
    /// The site entity.
    /// </summary>
    public class Site : BaseEntityTeam
    {
        /// <summary>
        /// Add row version timestamp in table Site.
        /// </summary>
        [Column(nameof(IEntityVersioned.RowVersion))]
        [AuditIgnore]
        public byte[] RowVersionSite { get; set; }

        /// <summary>
        /// Add row version for Postgre in table Site.
        /// </summary>
        [Column(nameof(IEntityVersioned.RowVersionXmin))]
        [AuditIgnore]
        public uint RowVersionXminSite { get; set; }
    }
}
