// <copyright file="TeamViewDto.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.Dto.View
{
    using TheBIADevCompany.BIATemplate.Domain.Dto.View;

    /// <summary>
    /// The DTO used to represent a siteView.
    /// </summary>
    public class TeamViewDto : ViewDto
    {
        /// <summary>
        /// Gets or sets the site identifier.
        /// </summary>
        public int TeamId { get; set; }
    }
}