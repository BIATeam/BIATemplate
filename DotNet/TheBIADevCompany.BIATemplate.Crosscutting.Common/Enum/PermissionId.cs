// <copyright file="PermissionId.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Crosscutting.Common.Enum
{
    /// <summary>
    /// Permission identifiers for project.
    /// </summary>
    public enum PermissionId
    {
#if BIA_FRONT_FEATURE
        /// <summary>
        /// Site Create.
        /// </summary>
        Site_Create,

        /// <summary>
        /// Site Delete.
        /// </summary>
        Site_Delete,

        /// <summary>
        /// Site List Access.
        /// </summary>
        Site_List_Access,

        /// <summary>
        /// Site Read.
        /// </summary>
        Site_Read,

        /// <summary>
        /// Site Save.
        /// </summary>
        Site_Save,

        /// <summary>
        /// Site Update.
        /// </summary>
        Site_Update,

        /// <summary>
        /// Site Member Create.
        /// </summary>
        Site_Member_Create,

        /// <summary>
        /// Site Member Delete.
        /// </summary>
        Site_Member_Delete,

        /// <summary>
        /// Site Member List Access.
        /// </summary>
        Site_Member_List_Access,

        /// <summary>
        /// Site Member Read.
        /// </summary>
        Site_Member_Read,

        /// <summary>
        /// Site Member Update.
        /// </summary>
        Site_Member_Update,

        /// <summary>
        /// Site Member Save.
        /// </summary>
        Site_Member_Save,

        /// <summary>
        /// Site View Add Team View.
        /// </summary>
        Site_View_Add_TeamView,

        /// <summary>
        /// Site View Update Team View.
        /// </summary>
        Site_View_Update_TeamView,

        /// <summary>
        /// Site View Set Default Team View.
        /// </summary>
        Site_View_Set_Default_TeamView,

        /// <summary>
        /// Site View Assign To Team.
        /// </summary>
        Site_View_Assign_To_Team,

        /// <summary>
        /// Site Access All.
        /// </summary>
        Site_Access_All,

        /// <summary>
        /// Site Options.
        /// </summary>
        Site_Options,
#endif

        // BIAToolKit - Begin PermissionId
        // BIAToolKit - End PermissionId

        // BIAToolKit - Begin PermissionIdForOption
        // BIAToolKit - End PermissionIdForOption
    }
}
