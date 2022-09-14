// <copyright file="AuthController.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Presentation.Api.Controllers.User
{
    using System;
    using System.Threading.Tasks;
    using BIA.Net.Core.Common.Configuration;
    using BIA.Net.Core.Common.Enum;
    using BIA.Net.Core.Common.Exceptions;
    using BIA.Net.Core.Domain.Dto.User;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using TheBIADevCompany.BIATemplate.Application.User;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common.Enum;
    using TheBIADevCompany.BIATemplate.Presentation.Api.Controllers.Base;

    /// <summary>
    /// The API controller used to authenticate users.
    /// </summary>
    public class AuthController : AuthControllerBase
    {
        /// <summary>
        /// The authentication service.
        /// </summary>
        private readonly IAuthAppService authService;

        /// <summary>
        /// The configuration of the BiaNet section.
        /// </summary>
        private readonly BiaNetSection configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">The authentication service.</param>
        /// <param name="configuration">The configuration.</param>
        public AuthController(IAuthAppService authService, IOptions<BiaNetSection> configuration)
        {
            this.authService = authService;
            this.configuration = configuration.Value;
        }

        /// <summary>
        /// The login action.
        /// </summary>
        /// <returns>The JWT if authenticated.</returns>
        [HttpGet("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login()
        {
            // used only by swagger.
            LoginParamDto loginParam = new LoginParamDto
            {
                TeamsConfig = new TeamConfigDto[]
                {
                    // this config is requerierd to simulate default site with swagger.
                    // it should correspond to the Front config (allEnvironments.Teams)
                    new TeamConfigDto { TeamTypeId = (int)TeamTypeId.Site, RoleMode = RoleMode.AllRoles, InHeader = true },
                },
                CurrentTeamLogins = null,
                LightToken = false,
            };

            return await this.LoginOnTeams(loginParam);
        }

        /// <summary>
        /// The login action.
        /// </summary>
        /// <param name="loginParam">The parameters for login.</param>
        /// <returns>
        /// The JWT if authenticated.
        /// </returns>
        [HttpPost("loginAndTeams")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LoginOnTeams(LoginParamDto loginParam)
        {
            try
            {
                AuthInfoDTO<UserDataDto, AdditionalInfoDto> authInfo = default;

                if (this.configuration?.Authentication?.Keycloak?.IsActive == true)
                {
                    authInfo = await this.authService.LoginOnTeamsAsync(this.User.Identity, loginParam);
                }
                else
                {
                    authInfo = await this.authService.LoginOnTeamsAsync((System.Security.Principal.WindowsIdentity)this.User.Identity, loginParam);
                }

                return this.Ok(authInfo);
            }
            catch (UnauthorizedException ex)
            {
                return this.Unauthorized(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return this.BadRequest(ex.Message);
            }
            catch (ForbiddenException ex)
            {
                return this.Forbid(ex.Message);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets the front end version.
        /// </summary>
        /// <returns>The front end version.</returns>
        [HttpGet("frontEndVersion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetFrontEndVersion()
        {
            return this.Ok(Constants.Application.FrontEndVersion);
        }
    }
}
