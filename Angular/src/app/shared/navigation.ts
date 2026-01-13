import { BiaPermission } from '@bia-team/bia-ng/core';
import { BiaNavigation } from '@bia-team/bia-ng/models';
import { Permission } from './permission';

export const NAVIGATION: BiaNavigation[] = [
  {
    labelKey: 'app.users',
    permissions: [BiaPermission.User_List_Access],
    path: ['/users'],
    icon: 'pi pi-users',
  },
  {
    labelKey: 'app.sites',
    permissions: [Permission.Site_List_Access],
    path: ['/sites'],
    icon: 'pi pi-home',
  },
  // BIAToolKit - Begin NavigationDomain
  // BIAToolKit - End NavigationDomain

  // BIAToolKit - Begin Navigation
  // BIAToolKit - End Navigation
  {
    labelKey: 'bia.administration',
    icon: 'pi pi-cog',
    permissions: [
      BiaPermission.Background_Task_Admin,
      BiaPermission.Background_Task_Read_Only,
    ],
    children: [
      {
        labelKey: 'bia.backgroundTaskAdmin',
        permissions: [BiaPermission.Background_Task_Admin],
        path: ['/backgroundtask/admin'],
      },
      {
        labelKey: 'bia.backgroundTaskReadOnly',
        permissions: [BiaPermission.Background_Task_Read_Only],
        path: ['/backgroundtask/readonly'],
      },
      {
        labelKey: 'bia.announcements',
        permissions: [BiaPermission.Announcement_List_Access],
        path: ['/announcements'],
      },
    ],
  },
];
