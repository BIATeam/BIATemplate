import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, Subscription } from 'rxjs';
import { getCurrentNotification } from '../../store/notification.state';
import { Notification } from '../../model/notification';
import { AppState } from 'src/app/store/state';
import { ActivatedRoute } from '@angular/router';
import { NotificationService } from '../../services/notification.service';
import { BiaClassicLayoutService } from 'src/app/shared/bia-shared/components/layout/classic-layout/bia-classic-layout.service';
import { first } from 'rxjs/operators';
import { BiaTranslationService } from 'src/app/core/bia-core/services/bia-translation.service';

@Component({
  selector: 'bia-notifications-item',
  templateUrl: './notification-item.component.html',
  styleUrls: ['./notification-item.component.scss'],
})
export class NotificationItemComponent implements OnInit, OnDestroy {
  notification$: Observable<Notification>;
  protected sub = new Subscription();

  constructor(
    protected store: Store<AppState>,
    protected route: ActivatedRoute,
    public notificationService: NotificationService,
    protected layoutService: BiaClassicLayoutService,
    protected biaTranslationService: BiaTranslationService
  ) {}

  ngOnInit() {
    this.sub.add(
      this.biaTranslationService.currentCulture$.subscribe(() => {
        this.notificationService.currentNotificationId =
          this.route.snapshot.params.notificationId;
      })
    );

    this.sub.add(
      this.store.select(getCurrentNotification).subscribe(notification => {
        if (notification?.title) {
          this.route.data.pipe(first()).subscribe(routeData => {
            (routeData as any)['breadcrumb'] = notification.title;
          });
          this.layoutService.refreshBreadcrumb();
        }
      })
    );
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }
}
