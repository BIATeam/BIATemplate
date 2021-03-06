// <copyright file="SiteAppService.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Application.Site
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using BIA.Net.Core.Domain.Authentication;
    using BIA.Net.Core.Domain.Dto.User;
    using BIA.Net.Core.Domain.RepoContract;
    using BIA.Net.Core.Domain.Service;
    using BIA.Net.Core.Domain.Specification;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common.Enum;
    using TheBIADevCompany.BIATemplate.Domain.Dto.Site;
    using TheBIADevCompany.BIATemplate.Domain.SiteModule.Aggregate;

    /// <summary>
    /// The application service used for site.
    /// </summary>
    public class SiteAppService : CrudAppServiceBase<SiteDto, Site, int, SiteFilterDto, SiteMapper>, ISiteAppService
    {
        /// <summary>
        /// The claims principal.
        /// </summary>
        private readonly BIAClaimsPrincipal principal;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteAppService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="principal">The claims principal.</param>
        public SiteAppService(ITGenericRepository<Site, int> repository, IPrincipal principal)
            : base(repository)
        {
            this.principal = principal as BIAClaimsPrincipal;
        }

        /// <inheritdoc cref="ISiteAppService.GetAllWithMembersAsync"/>
        public async Task<(IEnumerable<SiteInfoDto> Sites, int Total)> GetAllWithMembersAsync(SiteFilterDto filters)
        {
            UserDataDto userData = this.principal.GetUserData<UserDataDto>();
            IEnumerable<string> currentUserPermissions = this.principal.GetUserPermissions();
            int siteId = currentUserPermissions?.Any(x => x == Rights.Teams.AccessAll) == true ? default : userData.GetCurrentTeamId((int)TeamTypeId.Site);

            return await this.GetRangeAsync<SiteInfoDto, SiteInfoMapper, SiteFilterDto>(filters: filters, specification: SiteSpecification.SearchGetAll(filters, siteId));
        }

        /// <inheritdoc cref="ISiteAppService.GetAllAsync"/>
        public async Task<IEnumerable<SiteDto>> GetAllAsync(int userId = 0, IEnumerable<string> userPermissions = null)
        {
            userPermissions = userPermissions != null ? userPermissions : this.principal.GetUserPermissions();
            userId = userId > 0 ? userId : this.principal.GetUserId();

            SiteMapper mapper = this.InitMapper<SiteDto, SiteMapper>();
            if (userPermissions?.Any(x => x == Rights.Teams.AccessAll) == true)
            {
                return await this.Repository.GetAllResultAsync(mapper.EntityToDto(userId));
            }
            else
            {
                return await this.Repository.GetAllResultAsync(mapper.EntityToDto(userId), specification: new DirectSpecification<Site>(site => site.Members.Any(member => member.UserId == userId)));
            }
        }
    }
}