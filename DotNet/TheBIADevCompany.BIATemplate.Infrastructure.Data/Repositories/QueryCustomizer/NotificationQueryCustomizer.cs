// <copyright file="NotificationQueryCustomizer.cs" company="Safran">
//     Copyright (c) Safran. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Infrastructure.Data.Repositories.QueryCustomizer
{
    using System.Linq;
    using BIA.Net.Core.Domain.RepoContract.QueryCustomizer;
    using Microsoft.EntityFrameworkCore;
    using TheBIADevCompany.BIATemplate.Domain.NotificationModule.Aggregate;
    using TheBIADevCompany.BIATemplate.Domain.RepoContract;

    /// <summary>
    /// Class use to customize the EF request on Member entity.
    /// </summary>
    public class NotificationQueryCustomizer : TQueryCustomizer<Notification>, INotificationQueryCustomizer
    {
        /// <inheritdoc/>
        public override IQueryable<Notification> CustomizeAfter(IQueryable<Notification> objectSet, string queryMode)
        {
            if (queryMode == QueryMode.Update)
            {
                return objectSet
                    .Include(n => n.NotifiedPermissions).ThenInclude(n => n.Permission)
                    .Include(n => n.NotifiedUsers)
                    .Include(n => n.NotificationTranslations);
            }

            return objectSet;
        }
    }
}
