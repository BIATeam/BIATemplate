// <copyright file="ITeamAppService.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Application.User
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BIA.Net.Core.Domain.Dto.User;
    using BIA.Net.Core.Domain.Service;
    using TheBIADevCompany.BIATemplate.Domain.UserModule.Aggregate;

    /// <summary>
    /// The interface defining the application service for team.
    /// </summary>
    public interface ITeamAppService : IFilteredServiceBase<Team, int>
    {
        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userPermissions">The user rights.</param>
        /// <returns>all teams.</returns>
        Task<IEnumerable<TeamDto>> GetAllAsync(int userId = 0, IEnumerable<string> userPermissions = null);
    }
}