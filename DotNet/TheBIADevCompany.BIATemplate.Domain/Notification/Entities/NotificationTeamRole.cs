// <copyright file="NotificationTeamRole.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.Notification.Entities
{
    using BIA.Net.Core.Domain;
    using TheBIADevCompany.BIATemplate.Domain.User.Entities;

    /// <summary>
    /// The NotificationRole entity.
    /// </summary>
    public class NotificationTeamRole : VersionedTable
    {
        /// <summary>
        /// Gets or sets the notification team identifier.
        /// </summary>
        public int NotificationTeamId { get; set; }

        /// <summary>
        /// Gets or sets the notification team.
        /// </summary>
        public virtual NotificationTeam NotificationTeam { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the role.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public virtual Role Role { get; set; }
    }
}