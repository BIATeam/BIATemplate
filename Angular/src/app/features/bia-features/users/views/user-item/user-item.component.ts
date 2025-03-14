import { Component, Injector, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { first } from 'rxjs/operators';
import { BiaLayoutService } from 'src/app/shared/bia-shared/components/layout/services/layout.service';
import { CrudItemItemComponent } from 'src/app/shared/bia-shared/feature-templates/crud-items/views/crud-item-item/crud-item-item.component';
import { AppState } from 'src/app/store/state';
import { User } from '../../model/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'bia-users-item',
  templateUrl:
    '../../../../../shared/bia-shared/feature-templates/crud-items/views/crud-item-item/crud-item-item.component.html',
  styleUrls: [
    '../../../../../shared/bia-shared/feature-templates/crud-items/views/crud-item-item/crud-item-item.component.scss',
  ],
})
export class UserItemComponent
  extends CrudItemItemComponent<User>
  implements OnInit
{
  constructor(
    protected store: Store<AppState>,
    protected injector: Injector,
    public userService: UserService,
    protected layoutService: BiaLayoutService
  ) {
    super(injector, userService);
  }

  ngOnInit() {
    super.ngOnInit();
    this.sub.add(
      this.userService.crudItem$.subscribe(user => {
        // TODO after creation of CRUD User : set the field of the item to display in the breadcrump
        if (user?.displayName) {
          this.route.data.pipe(first()).subscribe(routeData => {
            (routeData as any)['breadcrumb'] = user.displayName;
          });
          this.layoutService.refreshBreadcrumb();
        }
      })
    );
  }
}
