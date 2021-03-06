// <copyright file="INotificationDomainService.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.NotificationModule.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BIA.Net.Core.Domain.Dto.Base;
    using BIA.Net.Core.Domain.Dto.Notification;
    using BIA.Net.Core.Domain.Service;
    using TheBIADevCompany.BIATemplate.Domain.NotificationModule.Aggregate;

    /// <summary>
    /// The interface defining the notification application service.
    /// </summary>
    public interface INotificationDomainService : ICrudAppServiceListAndItemBase<NotificationDto, NotificationListItemDto, Notification, int, LazyLoadDto>
    {
        /// <summary>
        /// Set the notification as read.
        /// </summary>
        /// <param name="id">The notification identifier.</param>
        /// <returns>A task.</returns>
        Task SetAsRead(int id);

        /// <summary>
        /// Return the list of unreadIds.
        /// </summary>
        /// <param name="userId">the user Id.</param>
        /// <returns>The list of int.</returns>
        Task<List<int>> GetUnreadIds(int userId);
    }
}