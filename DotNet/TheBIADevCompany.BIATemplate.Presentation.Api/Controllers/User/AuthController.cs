// <copyright file="AuthController.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Presentation.Api.Controllers.User
{
    using System.Threading.Tasks;
    using BIA.Net.Core.Common.Enum;
    using BIA.Net.Core.Common.Exceptions;
    using BIA.Net.Core.Domain.Dto.User;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
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
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">The authentication service.</param>
        public AuthController(IAuthAppService authService)
        {
            this.authService = authService;
        }
#if BIA_FRONT_FEATURE

        /// <summary>
        /// The login action.
        /// </summary>
        /// <param name="lightToken">If true return a token without team permission.</param>
        /// <returns>The JWT if authenticated.</returns>
        [HttpGet("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(bool lightToken = true)
        {
            // used only by swagger.
            LoginParamDto loginParam = new LoginParamDto
            {
                TeamsConfig = new TeamConfigDto[]
                {
                    // this config is required to simulate default site with swagger.
                    // it should correspond to the Front config (allEnvironments.Teams)
                    new TeamConfigDto { TeamTypeId = (int)TeamTypeId.Site, RoleMode = RoleMode.AllRoles, InHeader = true },

                    // BIAToolKit - Begin AuthController
                    // BIAToolKit - End AuthController
                },
                CurrentTeamLogins = null,
                LightToken = lightToken,
                FineGrainedPermission = !lightToken,
                AdditionalInfos = !lightToken,
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
                AuthInfoDto<AdditionalInfoDto> authInfo = await this.authService.LoginOnTeamsAsync(loginParam);

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
        }

        /// <summary>
        /// Gets the front end version.
        /// </summary>
        /// <returns>The front end version.</returns>
        [HttpGet("frontEndVersion")]
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        public IActionResult GetFrontEndVersion()
        {
            return this.Ok(Constants.Application.FrontEndVersion);
        }
#endif
#if BIA_BACK_TO_BACK_AUTH

        /// <summary>
        /// The login action.
        /// </summary>
        /// <returns>The JWT if authenticated.</returns>
        [HttpGet("token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetToken()
        {
            try
            {
                string token = await this.authService.LoginAsync();
                return this.Ok(token);
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
        }
#endif
    }
}
