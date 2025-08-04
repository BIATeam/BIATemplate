// <copyright file="NotificationQueryCustomizer.cs" company="TheBIADevCompany">
//  Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.Repositories.QueryCustomizer
{
    using BIA.Net.Core.Infrastructure.Data.Repositories.QueryCustomizer;
    using TheBIADevCompany.BIATemplate.Domain.Notification.Entities;
    using TheBIADevCompany.BIATemplate.Domain.RepoContract.QueryCustomizer;

    /// <summary>
    /// Notification Query Customizer.
    /// </summary>
    public class NotificationQueryCustomizer : BaseNotificationQueryCustomizer<Notification>, INotificationQueryCustomizer
    {
    }
}
