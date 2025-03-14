import { DOCUMENT } from '@angular/common';
import { Inject, Injectable, NgZone, OnDestroy } from '@angular/core';
import { Observable, Subject, Subscription, fromEvent } from 'rxjs';
import {
  buffer,
  debounceTime,
  exhaustMap,
  filter,
  map,
  startWith,
  take,
} from 'rxjs/operators';

export const MIN_SIZE = 3;
export const MAX_DELAY_BETWEEN_KEYS_MS = 40;
export type BiaBarcodeMatcher<T> = (barcode: string) => T;

@Injectable({
  providedIn: 'root',
})
export class BiaBarcodeScannerService implements OnDestroy {
  protected rawBarcodeScan = new Subject<string>();
  protected noMatchScan = new Subject<string>();

  rawBarcodeScan$ = this.rawBarcodeScan.asObservable();
  noMatchScan$ = this.noMatchScan.asObservable();

  protected sub: Subscription;
  protected matchers: [BiaBarcodeMatcher<any>, Subject<any>][] = [];

  constructor(@Inject(DOCUMENT) document: any, zone: NgZone) {
    const keyDownUniq$ = fromEvent<KeyboardEvent>(document, 'keydown').pipe(
      filter(evt => !evt.repeat)
    );
    const barcodeScan$ = keyDownUniq$.pipe(
      exhaustMap(e =>
        keyDownUniq$.pipe(
          startWith(e),
          buffer(
            keyDownUniq$.pipe(
              startWith(undefined),
              debounceTime(MAX_DELAY_BETWEEN_KEYS_MS)
            )
          ),
          take(1)
        )
      ),
      map(events =>
        // We could filter at the beginning, but it may interfere with debounceTime
        events.filter(evt => {
          const code = evt.key;
          return ['Shift', 'Control', 'Alt'].indexOf(code) === -1;
        })
      ),
      filter(events => events.length >= MIN_SIZE),
      map(events => this.processEventsToCode(events))
    );
    // Avoid global angular tick every keydown
    zone.runOutsideAngular(() => {
      this.sub = barcodeScan$.subscribe(barcode => {
        zone.run(() => {
          this.rawBarcodeScan.next(barcode);
          for (const [matcherFn, subject] of this.matchers) {
            const res = matcherFn(barcode);
            if (res) {
              subject.next(res);
              // Stop at first match. One scan => One match
              return;
            }
          }
          this.noMatchScan.next(barcode);
        });
      });
    });
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  onBarcodeMatch<T>(matcherFn: BiaBarcodeMatcher<T>) {
    const subject = new Subject<NonNullable<T>>();
    this.matchers.push([matcherFn, subject]);
    return new Observable<NonNullable<T>>(observer => {
      const sub = subject.subscribe(v => observer.next(v));
      return () => {
        const idx = this.matchers.findIndex(([fn]) => matcherFn === fn);
        this.matchers.splice(idx, 1);
        sub.unsubscribe();
      };
    });
  }

  protected processEventsToCode(events: KeyboardEvent[]) {
    const isKeyence = this.isKeyence(events);
    if (isKeyence) {
      // Remove keyence prefix
      events.shift();
    }
    return events.reduce((acc, evt) => {
      acc += evt.key;
      return acc;
    }, '');
  }

  protected isKeyence(events: KeyboardEvent[]) {
    return events[0].ctrlKey && events[0].key === '`';
  }
}
