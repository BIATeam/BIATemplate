// <copyright file="TeamConfig.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>
namespace TheBIADevCompany.BIATemplate.Domain.User
{
    using System.Collections.Immutable;
    using BIA.Net.Core.Common;
    using BIA.Net.Core.Common.Helpers;
    using BIA.Net.Core.Domain.User.Entities;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common.Enum;

    /// <summary>
    /// Team prefixe.
    /// </summary>
    public static class TeamConfig
    {
        /// <summary>
        /// the private mapping.
        /// </summary>
        public static readonly ImmutableList<BiaTeamConfig<BaseEntityTeam>> Config = new ImmutableListBuilder<BiaTeamConfig<BaseEntityTeam>>()
        {
            new()
            {
                TeamTypeId = (int)TeamTypeId.Site,
                RightPrefix = "Site",
                AdminRoleIds = [(int)RoleId.SiteAdmin],
                RoleMode = BIA.Net.Core.Common.Enum.RoleMode.AllRoles,
                DisplayInHeader = true,
                Label = "site.headerLabel",
            },

            // BIAToolKit - Begin TeamConfig
            // BIAToolKit - End TeamConfig
        }.ToImmutable();
    }
}
