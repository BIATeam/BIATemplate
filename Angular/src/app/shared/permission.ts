/* eslint-disable @typescript-eslint/naming-convention */
export enum Permission {
  Background_Task_Admin = 'Background_Task_Admin',
  Background_Task_Read_Only = 'Background_Task_Read_Only',

  Home_Access = 'Home_Access',
  Notification_Create = 'Notification_Create',
  Notification_List_Access = 'Notification_List_Access',
  Notification_Delete = 'Notification_Delete',
  Notification_Read = 'Notification_Read',
  Notification_Update = 'Notification_Update',

  /// BIAToolKit - Begin Permission
  /// BIAToolKit - End Permission
  Roles_List = 'Roles_List',
  Site_Create = 'Site_Create',
  Site_Delete = 'Site_Delete',
  Site_List_Access = 'Site_List_Access',
  Site_Read = 'Site_Read',
  Site_Save = 'Site_Save',
  Site_Update = 'Site_Update',
  Site_Member_Create = 'Site_Member_Create',
  Site_Member_Delete = 'Site_Member_Delete',
  Site_Member_List_Access = 'Site_Member_List_Access',
  Site_Member_Update = 'Site_Member_Update',
  Site_Member_Save = 'Site_Member_Save',

  User_Add = 'User_Add',
  User_Delete = 'User_Delete',
  User_Save = 'User_Save',
  User_List = 'User_List',
  User_ListAD = 'User_ListAD',
  User_List_Access = 'User_List_Access',
  User_Sync = 'User_Sync',
  User_UpdateRoles = 'User_UpdateRoles',

  LdapDomains_List = 'LdapDomains_List',
  View_List = 'View_List',
  View_AddUserView = 'View_Add_UserView',
  View_AddTeamViewSuffix = '_View_Add_TeamView',
  View_UpdateUserView = 'View_Update_UserView',
  View_UpdateTeamViewSuffix = '_View_Update_TeamView',
  View_DeleteUserView = 'View_Delete_UserView',
  View_DeleteTeamView = 'View_Delete_TeamView',
  View_SetDefaultUserView = 'View_Set_Default_UserView',
  View_SetDefaultTeamViewSuffix = '_View_Set_Default_TeamView',
  View_AssignToTeamSuffix = '_View_Assign_To_Team',
}
