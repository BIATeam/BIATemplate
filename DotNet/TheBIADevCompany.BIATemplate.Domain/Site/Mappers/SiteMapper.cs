// <copyright file="SiteMapper.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Domain.Site.Mappers
{
    using System.Linq.Expressions;
    using System.Security.Principal;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common.Enum;
    using TheBIADevCompany.BIATemplate.Domain.Bia.Base.Mappers;
    using TheBIADevCompany.BIATemplate.Domain.Dto.Site;
    using TheBIADevCompany.BIATemplate.Domain.Site.Entities;

    /// <summary>
    /// The mapper used for site.
    /// </summary>
    public class SiteMapper : BaseTeamMapper<SiteDto, Site>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteMapper"/> class.
        /// </summary>
        /// <param name="principal">The principal.</param>
        public SiteMapper(IPrincipal principal)
            : base(principal)
        {
        }

        /// <summary>
        /// Precise the Id of the type of team.
        /// </summary>
        public override int TeamType
        {
            get { return (int)TeamTypeId.Site; }
        }
    }
}
