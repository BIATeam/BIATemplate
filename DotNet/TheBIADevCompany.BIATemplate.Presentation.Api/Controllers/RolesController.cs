// <copyright file="RolesController.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Presentation.Api.Controllers
{
    using System.Linq;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using BIA.Net.Core.Common;
    using BIA.Net.Core.Domain.Authentication;
    using BIA.Net.Presentation.Api.Controllers.Base;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TheBIADevCompany.BIATemplate.Application.User;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common;

    /// <summary>
    /// The API controller used to manage roles.
    /// </summary>
    public class RolesController : BiaControllerBase
    {
        /// <summary>
        /// The service role.
        /// </summary>
        private readonly IRoleAppService roleService;

        /// <summary>
        /// The claims principal.
        /// </summary>
        private readonly BIAClaimsPrincipal principal;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolesController"/> class.
        /// </summary>
        /// <param name="roleService">The role service.</param>
        /// <param name="principal">The claims principal.</param>
        public RolesController(IRoleAppService roleService, IPrincipal principal)
        {
            this.roleService = roleService;
            this.principal = principal as BIAClaimsPrincipal;
        }

        /// <summary>
        /// Gets all option that I can see.
        /// </summary>
        /// /// <returns>The list of production sites.</returns>
        [HttpGet("allOptions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = Rights.Roles.Options)]
        public async Task<IActionResult> GetAllOptions()
        {
            var results = await this.roleService.GetAllOptionsAsync();
            return this.Ok(results);
        }
    }
}