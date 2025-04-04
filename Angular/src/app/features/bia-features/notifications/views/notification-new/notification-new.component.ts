import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { BiaTranslationService } from 'src/app/core/bia-core/services/bia-translation.service';
import { AppState } from 'src/app/store/state';
import { Notification } from '../../model/notification';
import { NotificationOptionsService } from '../../services/notification-options.service';
import { FeatureNotificationsActions } from '../../store/notifications-actions';

@Component({
  selector: 'bia-notification-new',
  templateUrl: './notification-new.component.html',
  styleUrls: ['./notification-new.component.scss'],
})
export class NotificationNewComponent implements OnInit, OnDestroy {
  protected sub = new Subscription();

  constructor(
    protected store: Store<AppState>,
    protected router: Router,
    protected activatedRoute: ActivatedRoute,
    public notificationOptionsService: NotificationOptionsService,
    protected biaTranslationService: BiaTranslationService
  ) {}

  ngOnInit() {
    this.sub.add(
      this.biaTranslationService.currentCulture$.subscribe(() => {
        this.notificationOptionsService.loadAllOptions();
      })
    );
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  onSubmitted(notificationToCreate: Notification) {
    this.store.dispatch(
      FeatureNotificationsActions.create({ notification: notificationToCreate })
    );
    this.router.navigate(['../'], { relativeTo: this.activatedRoute });
  }

  onCancelled() {
    this.router.navigate(['../'], { relativeTo: this.activatedRoute });
  }
}
