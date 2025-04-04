import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { ReducerManager, StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { PermissionGuard } from 'src/app/core/bia-core/guards/permission.guard';
import { FullPageLayoutComponent } from 'src/app/shared/bia-shared/components/layout/fullpage-layout/fullpage-layout.component';
import { PopupLayoutComponent } from 'src/app/shared/bia-shared/components/layout/popup-layout/popup-layout.component';
import { CrudItemModule } from 'src/app/shared/bia-shared/feature-templates/crud-items/crud-item.module';
import { Permission } from 'src/app/shared/permission';
import { SharedModule } from 'src/app/shared/shared.module';
import { SiteFormComponent } from './components/site-form/site-form.component';
import { SiteTableComponent } from './components/site-table/site-table.component';
import { siteCRUDConfiguration } from './site.constants';
import { FeatureSitesStore } from './store/site.state';
import { SitesEffects } from './store/sites-effects';
import { SiteEditComponent } from './views/site-edit/site-edit.component';
import { SiteItemComponent } from './views/site-item/site-item.component';
import { SiteNewComponent } from './views/site-new/site-new.component';
import { SitesIndexComponent } from './views/sites-index/sites-index.component';

export const ROUTES: Routes = [
  {
    path: '',
    data: {
      breadcrumb: null,
      permission: Permission.Site_List_Access,
      injectComponent: SitesIndexComponent,
    },
    component: FullPageLayoutComponent,
    canActivate: [PermissionGuard],
    // [Calc] : The children are not used in calc
    children: [
      {
        path: 'create',
        data: {
          breadcrumb: 'bia.add',
          canNavigate: false,
          permission: Permission.Site_Create,
          title: 'site.add',
          injectComponent: SiteNewComponent,
          dynamicComponent: () =>
            siteCRUDConfiguration.usePopup
              ? PopupLayoutComponent
              : FullPageLayoutComponent,
        },
        component: siteCRUDConfiguration.usePopup
          ? PopupLayoutComponent
          : FullPageLayoutComponent,
        canActivate: [PermissionGuard],
      },
      {
        path: ':crudItemId',
        data: {
          breadcrumb: '',
          canNavigate: false,
        },
        component: SiteItemComponent,
        canActivate: [PermissionGuard],
        children: [
          {
            path: 'edit',
            data: {
              breadcrumb: 'bia.edit',
              canNavigate: true,
              permission: Permission.Site_Update,
              title: 'site.edit',
              injectComponent: SiteEditComponent,
              dynamicComponent: () =>
                siteCRUDConfiguration.usePopup
                  ? PopupLayoutComponent
                  : FullPageLayoutComponent,
            },
            component: siteCRUDConfiguration.usePopup
              ? PopupLayoutComponent
              : FullPageLayoutComponent,
            canActivate: [PermissionGuard],
          },
          {
            path: '',
            pathMatch: 'full',
            redirectTo: 'edit',
          },
          // Custo for teams
          {
            path: 'members',
            data: {
              breadcrumb: 'app.members',
              canNavigate: true,
              permission: Permission.Site_Member_List_Access,
            },
            loadChildren: () =>
              import('./children/members/site-member.module').then(
                m => m.SiteMemberModule
              ),
          },
        ],
      },
    ],
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  declarations: [
    SiteItemComponent,
    SitesIndexComponent,
    // [Calc] : NOT used for calc (3 lines).
    // it is possible to delete unsed commponent files (views/..-new + views/..-edit + components/...-form).
    SiteFormComponent,
    SiteNewComponent,
    SiteEditComponent,
    // [Calc] : Used only for calc it is possible to delete unsed commponent files (components/...-table)).
    SiteTableComponent,
  ],
  imports: [
    SharedModule,
    CrudItemModule,
    RouterModule.forChild(ROUTES),
    StoreModule.forFeature(
      siteCRUDConfiguration.storeKey,
      FeatureSitesStore.reducers
    ),
    EffectsModule.forFeature([SitesEffects]),
    // Domain Modules:
  ],
})
export class SiteModule {}
