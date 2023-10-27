import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HOME_ROUTES } from './features/home/home.module';
import { LayoutComponent } from './shared/bia-shared/components/layout/layout.component';
import { PageLayoutComponent } from './shared/bia-shared/components/layout/page-layout.component';

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
          {
            path: 'sites',
            data: {
              breadcrumb: 'app.sites',
              canNavigate: true
            },
            loadChildren: () => import('./features/sites/site.module').then((m) => m.SiteModule)
          },
          {
            path: 'users',
            data: {
              breadcrumb: 'app.users',
              canNavigate: true
            },
            loadChildren: () => import('./features/bia-features/users/user.module').then((m) => m.UserModule)
          },
          {
            path: 'notifications',
            data: {
              breadcrumb: 'app.notifications',
              canNavigate: true
            },
            loadChildren: () => import('./features/bia-features/notifications/notification.module').then((m) => m.NotificationModule)
          },
          {
            path: 'backgroundtask',
            data: {
              breadcrumb: 'bia.backgroundtasks',
              canNavigate: true
            },
            loadChildren: () => import('./features/bia-features/background-task/background-task.module').then((m) => m.BackgroundTaskModule)
          }
        ]
      }
    ]
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
