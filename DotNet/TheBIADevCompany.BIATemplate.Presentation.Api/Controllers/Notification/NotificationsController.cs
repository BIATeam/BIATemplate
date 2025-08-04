// <copyright file="NotificationsController.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Presentation.Api.Controllers.Notification
{
    using BIA.Net.Core.Application.Services;
    using BIA.Net.Core.Presentation.Api.Controller.Notification;
    using TheBIADevCompany.BIATemplate.Application.Notification;
    using TheBIADevCompany.BIATemplate.Domain.Dto.Notification;
#pragma warning disable BIA001 // Forbidden reference to Domain layer in Presentation layer
    using TheBIADevCompany.BIATemplate.Domain.Notification.Entities;
#pragma warning restore BIA001 // Forbidden reference to Domain layer in Presentation layer

    /// <inheritdoc />
    public class NotificationsController : BaseNotificationsController<NotificationDto, NotificationListItemDto, Notification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsController"/> class.
        /// </summary>
        /// <param name="notificationService">The notification service.</param>
        /// <param name="biaClaimsPrincipalService">The bia claims principal service.</param>
        public NotificationsController(INotificationAppService notificationService, IBiaClaimsPrincipalService biaClaimsPrincipalService)
            : base(notificationService, biaClaimsPrincipalService)
        {
        }
    }
}
