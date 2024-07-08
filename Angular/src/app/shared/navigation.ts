import { BiaNavigation } from './bia-shared/model/bia-navigation';
import { Permission } from './permission';

export const NAVIGATION: BiaNavigation[] = [
  {
    labelKey: 'app.users',
    permissions: [Permission.User_List_Access],
    path: ['/users'],
  },
  {
    labelKey: 'app.sites',
    permissions: [Permission.Site_List_Access],
    path: ['/sites'],
  },
  /// BIAToolKit - Begin Navigation
  /// BIAToolKit - End Navigation
  {
    labelKey: 'bia.administration',
    permissions: [
      Permission.Background_Task_Admin,
      Permission.Background_Task_Read_Only,
    ],
    children: [
      {
        labelKey: 'bia.backgroundTaskAdmin',
        permissions: [Permission.Background_Task_Admin],
        path: ['/backgroundtask/admin'],
      },
      {
        labelKey: 'bia.backgroundTaskReadOnly',
        permissions: [Permission.Background_Task_Read_Only],
        path: ['/backgroundtask/readonly'],
      },
    ],
  },
];
