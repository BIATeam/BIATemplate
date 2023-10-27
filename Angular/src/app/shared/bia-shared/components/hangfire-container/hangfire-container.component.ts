import { Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from "@angular/core";
import { Subscription } from "rxjs";
import { AuthService } from "src/app/core/bia-core/services/auth.service";

@Component({
    selector: 'bia-hangfire-container',
    templateUrl: './hangfire-container.component.html'
  })
  export class HangfireContainerComponent implements OnInit, OnDestroy {
    @Input() url: string = "";

    // @ViewChild('iFrame2', { static: false }) iFrame2: ElementRef;
    @ViewChild('hangfireForm', { static: false }) hangfireForm: ElementRef;
    
    private sub = new Subscription();
    public token = ""

    constructor(private authService: AuthService) {
    }

    ngOnInit() {
      this.sub.add(
        this.authService.getLightToken().subscribe(authinfo => {
          this.token = authinfo.token;
          setTimeout(() => this.hangfireForm.nativeElement.submit());
        })
      );
    }

    ngOnDestroy() {
      // remove cookie HangFireCookie
      document.cookie = 'HangFireCookie=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;'
      if (this.sub) {
        this.sub.unsubscribe();
      }
    }
  }