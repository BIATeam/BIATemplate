// <copyright file="INotificationQueryCustomizer.cs" company="Safran">
//     Copyright (c) Safran. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.RepoContract
{
    using BIA.Net.Core.Domain.RepoContract.QueryCustomizer;
    using TheBIADevCompany.BIATemplate.Domain.NotificationModule.Aggregate;

    /// <summary>
    /// interface use to customize the request on Member entity.
    /// </summary>
    public interface INotificationQueryCustomizer : IQueryCustomizer<Notification>
    {
    }
}
