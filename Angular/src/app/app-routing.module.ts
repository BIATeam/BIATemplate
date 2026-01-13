import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent, PageLayoutComponent } from '@bia-team/bia-ng/shared';
import { HOME_ROUTES } from './features/home/home.module';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      ...HOME_ROUTES,
      {
        path: '',
        component: PageLayoutComponent,
        children: [
          // BIAToolKit - Begin RoutingDomain
          // BIAToolKit - End RoutingDomain

          // BIAToolKit - Begin Routing
          // BIAToolKit - End Routing
          {
            path: 'sites',
            data: {
              breadcrumb: 'app.sites',
              canNavigate: true,
            },
            loadChildren: () =>
              import('./features/sites/site.module').then(m => m.SiteModule),
          },
          {
            path: 'users',
            data: {
              breadcrumb: 'app.users',
              canNavigate: true,
            },
            loadChildren: () =>
              import('./features/bia-features/users/user.module').then(
                m => m.UserModule
              ),
          },
          {
            path: 'notifications',
            data: {
              breadcrumb: 'app.notifications',
              canNavigate: true,
            },
            loadChildren: () =>
              import(
                './features/bia-features/notifications/notification.module'
              ).then(m => m.NotificationModule),
          },
          {
            path: 'backgroundtask',
            data: {
              breadcrumb: 'bia.backgroundtasks',
              canNavigate: true,
              noMargin: true,
              noPadding: true,
            },
            loadChildren: () =>
              import(
                './features/bia-features/background-task/background-task.module'
              ).then(m => m.BackgroundTaskModule),
          },
          {
            path: 'announcements',
            data: {
              breadcrumb: 'bia.announcements',
              canNavigate: true,
            },
            loadChildren: () =>
              import(
                './features/bia-features/announcements/announcement.module'
              ).then(m => m.AnnouncementModule),
          },
        ],
      },
    ],
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
