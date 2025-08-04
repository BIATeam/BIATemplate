// <copyright file="INotificationAppService.cs" company="TheBIADevCompany">
//  Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Application.Notification
{
    using BIA.Net.Core.Application.Notification;
    using TheBIADevCompany.BIATemplate.Domain.Dto.Notification;
    using TheBIADevCompany.BIATemplate.Domain.Notification.Entities;

    /// <summary>
    /// Interface Notification Service.
    /// </summary>
    public interface INotificationAppService : IBaseNotificationAppService<NotificationDto, NotificationListItemDto, Notification>
    {
    }
}
