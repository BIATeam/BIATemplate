import {
  Component,
  OnInit,
  Output,
  EventEmitter,
  OnDestroy,
} from '@angular/core';
import { Store } from '@ngrx/store';
import { FeatureNotificationsActions } from '../../store/notifications-actions';
import { Observable, Subscription } from 'rxjs';
import { Notification, NotificationData } from '../../model/notification';
import { AppState } from 'src/app/store/state';
import { NotificationService } from '../../services/notification.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Permission } from 'src/app/shared/permission';
import { AuthService } from 'src/app/core/bia-core/services/auth.service';

@Component({
  selector: 'bia-notification-detail',
  templateUrl: './notification-detail.component.html',
  styleUrls: ['./notification-detail.component.scss'],
})
export class NotificationDetailComponent implements OnInit, OnDestroy {
  @Output() displayChange = new EventEmitter<boolean>();
  protected sub = new Subscription();
  canEdit: boolean;
  loading$: Observable<boolean>;
  notification$: Observable<Notification | undefined>;

  constructor(
    protected store: Store<AppState>,
    protected router: Router,
    protected activatedRoute: ActivatedRoute,
    protected authService: AuthService,
    public notificationService: NotificationService
  ) {}

  ngOnInit() {
    this.notification$ = this.notificationService.notification$;
    this.canEdit = this.authService.hasPermission(
      Permission.Notification_Update
    );
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  onSubmitted(notificationToUpdate: Notification) {
    this.store.dispatch(
      FeatureNotificationsActions.update({ notification: notificationToUpdate })
    );
    this.router.navigate(['../../'], { relativeTo: this.activatedRoute });
  }

  onCancelled() {
    this.router.navigate(['../../'], { relativeTo: this.activatedRoute });
  }

  onEdit() {
    this.router.navigate(['../edit'], { relativeTo: this.activatedRoute });
  }

  canAction(notification: Notification) {
    if (notification.data) {
      if (notification.data.route) {
        return true;
      }
    }
    return false;
  }

  onAction(notification: Notification) {
    if (notification.data) {
      const data: NotificationData = notification.data;
      if (data.route) {
        if (data?.teams) {
          // Auto-switch to teams related to this notification
          data.teams.forEach(team => {
            this.authService.changeCurrentTeamId(team.teamTypeId, team.team.id);
            if (team.roles) {
              this.authService.changeCurrentRoleIds(
                team.teamTypeId,
                team.team.id,
                team.roles.map(r => r.id)
              );
            }
          });
        }
        this.router.navigate(notification.data.route);
      }
    }
  }
  onSetUnread(id: number) {
    this.store.dispatch(FeatureNotificationsActions.setUnread({ id }));
  }
}
