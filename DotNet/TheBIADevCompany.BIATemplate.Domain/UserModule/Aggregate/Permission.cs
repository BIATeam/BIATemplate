// <copyright file="Permission.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.UserModule.Aggregate
{
    using System.Collections.Generic;

    using BIA.Net.Core.Domain;
    using TheBIADevCompany.BIATemplate.Domain.NotificationModule.Aggregate;

    /// <summary>
    /// The role entity.
    /// </summary>
    public class Permission : VersionedTable, IEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the collection of notifications.
        /// </summary>
        public virtual ICollection<NotificationPermission> NotificationPermissions { get; set; }
    }
}