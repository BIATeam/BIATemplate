// <copyright file="NotificationTypeDomainService.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.NotificationModule.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BIA.Net.Core.Domain.Dto.Option;
    using BIA.Net.Core.Domain.RepoContract;
    using BIA.Net.Core.Domain.Service;
    using TheBIADevCompany.BIATemplate.Domain.NotificationModule.Aggregate;

    /// <summary>
    /// The application service used for notification type.
    /// </summary>
    public class NotificationTypeDomainService : AppServiceBase<NotificationType>, INotificationTypeDomainService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationTypeDomainService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public NotificationTypeDomainService(ITGenericRepository<NotificationType> repository)
            : base(repository)
        {
        }

        /// <summary>
        /// Return options.
        /// </summary>
        /// <returns>List of OptionDto.</returns>
        public Task<IEnumerable<OptionDto>> GetAllOptionsAsync()
        {
            return this.Repository.GetAllResultAsync(selectResult: new NotificationTypeOptionMapper().EntityToDto());
        }
    }
}