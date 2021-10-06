// <copyright file="NotificationPermission.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.NotificationModule.Aggregate
{
    using System;
    using BIA.Net.Core.Domain;
    using TheBIADevCompany.BIATemplate.Domain.UserModule.Aggregate;

    /// <summary>
    /// The NotificationUser entity.
    /// </summary>
    public class NotificationPermission : VersionedTable
    {
        /// <summary>
        /// Gets or sets the notification identifier.
        /// </summary>
        public int NotificationId { get; set; }

        /// <summary>
        /// Gets or sets the notification.
        /// </summary>
        public virtual Notification Notification { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user.
        /// </summary>
        public int PermissionId { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public virtual Permission Permission { get; set; }
    }
}