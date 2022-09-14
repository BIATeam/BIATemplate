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
<<<<<<< HEAD
=======

        private async Task<List<string>> GetRoles(LoginParamDto loginParam, UserDataDto userData, List<string> userRolesFromUserDirectory, UserInfoDto userInfo, IEnumerable<TeamDto> allTeams)
        {
            // the main roles
            var allRoles = userRolesFromUserDirectory;

            // get user rights
            if (userRolesFromUserDirectory.Contains(Constants.Role.User) || userRolesFromUserDirectory.Contains(Constants.Role.Admin))
            {
                var userRoles = await this.roleAppService.GetUserRolesAsync(userInfo.Id);
                allRoles.AddRange(userRoles);

                if (loginParam.TeamsConfig != null)
                {
                    foreach (var teamConfig in loginParam.TeamsConfig)
                    {
                        CurrentTeamDto teamLogin = loginParam.CurrentTeamLogins?.FirstOrDefault(ct => ct.TeamTypeId == teamConfig.TeamTypeId);
                        if (teamLogin == null && teamConfig.InHeader)
                        {
                            // if it is in header we select the default one with default roles.
                            teamLogin = new CurrentTeamDto
                            {
                                TeamTypeId = teamConfig.TeamTypeId,
                                TeamId = 0,
                                UseDefaultRoles = true,
                                CurrentRoleIds = { },
                            };
                        }

                        if (teamLogin != null)
                        {
                            var teams = allTeams.Where(t => t.TeamTypeId == teamLogin.TeamTypeId);
                            var team = teams?.OrderByDescending(x => x.IsDefault).FirstOrDefault();

                            CurrentTeamDto currentTeam = new ();
                            currentTeam.TeamTypeId = teamLogin.TeamTypeId;

                            if (team != null)
                            {
                                if (teamLogin.TeamId > 0 && teams.Any(s => s.Id == teamLogin.TeamId))
                                {
                                    currentTeam.TeamId = teamLogin.TeamId;
                                    currentTeam.TeamTitle = teams.First(s => s.Id == teamLogin.TeamId).Title;
                                }
                                else
                                {
                                    currentTeam.TeamId = team.Id;
                                    currentTeam.TeamTitle = team.Title;
                                }
                            }

                            if (currentTeam.TeamId > 0)
                            {
                                var roles = await this.roleAppService.GetMemberRolesAsync(currentTeam.TeamId, userInfo.Id);
                                var roleMode = loginParam.TeamsConfig?.FirstOrDefault(r => r.TeamTypeId == currentTeam.TeamTypeId)?.RoleMode ?? RoleMode.AllRoles;

                                if (roleMode == RoleMode.AllRoles)
                                {
                                    currentTeam.CurrentRoleIds = roles.Select(r => r.Id).ToList();
                                }
                                else if (roleMode == RoleMode.SingleRole)
                                {
                                    RoleDto role = roles?.OrderByDescending(x => x.IsDefault).FirstOrDefault();
                                    if (role != null)
                                    {
                                        if (teamLogin.CurrentRoleIds != null && teamLogin.CurrentRoleIds.Count == 1 && roles.Any(s => s.Id == teamLogin.CurrentRoleIds.First()))
                                        {
                                            currentTeam.CurrentRoleIds = new List<int> { teamLogin.CurrentRoleIds.First() };
                                        }
                                        else
                                        {
                                            currentTeam.CurrentRoleIds = new List<int> { role.Id };
                                        }
                                    }
                                    else
                                    {
                                        currentTeam.CurrentRoleIds = new List<int>();
                                    }
                                }
                                else
                                {
                                    if (roles.Any())
                                    {
                                        if (!teamLogin.UseDefaultRoles)
                                        {
                                            List<int> roleIdsToSet = roles.Where(r => teamLogin.CurrentRoleIds != null && teamLogin.CurrentRoleIds.Any(tr => tr == r.Id)).Select(r => r.Id).ToList();
                                            currentTeam.CurrentRoleIds = roleIdsToSet;
                                        }
                                        else
                                        {
                                            currentTeam.CurrentRoleIds = roles.Where(x => x.IsDefault).Select(r => r.Id).ToList();
                                        }
                                    }
                                    else
                                    {
                                        currentTeam.CurrentRoleIds = new List<int>();
                                    }
                                }

                                userData.CurrentTeams.Add(currentTeam);

                                // add the sites roles (filter if singleRole mode is used)
                                allRoles.AddRange(roles.Where(r => currentTeam.CurrentRoleIds.Any(id => id == r.Id)).Select(r => r.Code).ToList());

                                // add computed roles (can be customized)
                                if (currentTeam.TeamTypeId == (int)TeamTypeId.Site)
                                {
                                    allRoles.Add(Constants.Role.SiteMember);
                                }
                            }
                        }
                    }
                }
            }

            return allRoles;
        }
>>>>>>> 488dc0a3a1d23550c8d6075947a682187d4dd6c6
    }
}
