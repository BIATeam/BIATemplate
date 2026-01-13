// <copyright file="NotificationMapper.cs" company="TheBIADevCompany">
//  Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.Notification.Mappers
{
    using BIA.Net.Core.Domain.Notification.Mappers;
    using BIA.Net.Core.Domain.Service;
    using TheBIADevCompany.BIATemplate.Domain.Dto.Notification;
    using TheBIADevCompany.BIATemplate.Domain.Notification.Entities;

    /// <summary>
    /// Notification Mapper.
    /// </summary>
    /// <param name="userContext">The user context.</param>
    public class NotificationMapper(UserContext userContext) :
        BaseNotificationMapper<NotificationDto, Notification>(userContext)
    {
    }
}
