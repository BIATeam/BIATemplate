// <copyright file="TeamConfig.cs" company="TheBIADevCompany">
//     Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>
namespace TheBIADevCompany.BIATemplate.Domain.UserModule.Aggregate
{
    using System.Collections.Immutable;
    using BIA.Net.Core.Common;
    using BIA.Net.Core.Common.Helpers;
    using TheBIADevCompany.BIATemplate.Crosscutting.Common.Enum;

    /// <summary>
    /// Team prefixe.
    /// </summary>
    public static class TeamConfig
    {
        /// <summary>
        /// the private mapping.
        /// </summary>
        public static readonly ImmutableList<BiaTeamConfig<Team>> Config = new ImmutableListBuilder<BiaTeamConfig<Team>>()
        {
            new BiaTeamConfig<Team>()
            {
                TeamTypeId = (int)TeamTypeId.Site,
                RightPrefix = "Site",
                AdminRoleIds = new int[] { (int)RoleId.SiteAdmin },
            },

            // BIAToolKit - Begin TeamConfig
            // BIAToolKit - End TeamConfig
        }.ToImmutable();
    }
}
