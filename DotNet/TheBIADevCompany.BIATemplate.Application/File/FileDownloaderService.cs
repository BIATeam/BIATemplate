// <copyright file="FileDownloaderService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Application.File
{
    using BIA.Net.Core.Application.File;
    using BIA.Net.Core.Domain.Dto.Base;
    using Microsoft.Extensions.Logging;
    using TheBIADevCompany.BIATemplate.Application.Notification;
    using TheBIADevCompany.BIATemplate.Domain.Dto.Notification;
    using TheBIADevCompany.BIATemplate.Domain.Notification.Entities;

    /// <summary>
    /// Project-specific implementation of the file downloader service.
    /// </summary>
    public class FileDownloaderService : BiaFileDownloaderService<FileDownloaderOptions, INotificationAppService, Notification, NotificationDto, NotificationListItemDto, PagingFilterFormatDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileDownloaderService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="logger">The logger.</param>
        public FileDownloaderService(
            IServiceProvider serviceProvider,
            ILogger<FileDownloaderService> logger)
            : base(serviceProvider, logger)
        {
        }
    }
}
