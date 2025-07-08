// <copyright file="Rights.cs" company="TheBIADevCompany">
// Copyright (c) TheBIADevCompany. All rights reserved.
// </copyright>

namespace TheBIADevCompany.BIATemplate.Crosscutting.Common
{
    /// <summary>
    /// The list of all rights.
    /// </summary>
    public static class Rights
    {
        /// <summary>
        /// The sites rights.
        /// </summary>
        public static class Sites
        {
            /// <summary>
            /// The right to access to the list of sites.
            /// </summary>
            public const string ListAccess = "Site_List_Access";

            /// <summary>
            /// The right to create sites.
            /// </summary>
            public const string Create = "Site_Create";

            /// <summary>
            /// The right to read sites.
            /// </summary>
            public const string Read = "Site_Read";

            /// <summary>
            /// The right to update sites.
            /// </summary>
            public const string Update = "Site_Update";

            /// <summary>
            /// The right to delete sites.
            /// </summary>
            public const string Delete = "Site_Delete";

            /// <summary>
            /// The right to save sites.
            /// </summary>
            public const string Save = "Site_Save";

            /// <summary>
            /// The right to access to the list of sites (options only).
            /// </summary>
            public const string Options = "Site_Options";
        }

        // BIAToolKit - Begin Rights
        // BIAToolKit - End Rights

        // BIAToolKit - Begin RightsForOption
        // BIAToolKit - End RightsForOption
    }
}
