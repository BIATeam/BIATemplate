// <copyright file="NotificationListItemMapper.cs" company="TheBIADevCompany">
//  Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.Notification.Mappers
{
    using BIA.Net.Core.Domain.Notification.Mappers;
    using BIA.Net.Core.Domain.Service;
    using TheBIADevCompany.BIATemplate.Domain.Dto.Notification;
    using TheBIADevCompany.BIATemplate.Domain.Notification.Entities;

    /// <summary>
    /// Notification List Item Mapper.
    /// </summary>
    public class NotificationListItemMapper(UserContext userContext) :
        BaseNotificationListItemMapper<NotificationListItemDto, Notification>(userContext)
    {
    }
}
