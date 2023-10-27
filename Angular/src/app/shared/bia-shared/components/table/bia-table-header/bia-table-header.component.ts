import { Component, Input, Output, EventEmitter, OnChanges, ChangeDetectionStrategy, TemplateRef, ContentChildren, QueryList, AfterContentInit } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { ConfirmationService, Confirmation, PrimeTemplate } from 'primeng/api';
import { BiaDialogService } from 'src/app/core/bia-core/services/bia-dialog.service';

@Component({
  selector: 'bia-table-header',
  templateUrl: './bia-table-header.component.html',
  styleUrls: ['./bia-table-header.component.scss'],
  providers: [ConfirmationService],
  changeDetection: ChangeDetectionStrategy.Default
})
export class BiaTableHeaderComponent implements OnChanges, AfterContentInit {
  @Input() hasFilter = false;
  @Input() showFilter = false;
  @Input() showBtnFilter = false;
  @Input() canAdd = true;
  @Input() canDelete = true;
  @Input() canBack = false;
  @Input() canExportCSV = false;
  @Input() headerTitle: string;
  @Input() selectedElements: any[];
  @Output() create = new EventEmitter<void>();
  @Output() delete = new EventEmitter<void>();
  @Output() openFilter = new EventEmitter<void>();
  @Output() exportCSV = new EventEmitter<void>();


  @ContentChildren(PrimeTemplate) templates: QueryList<any>;
  actionOnSelectedTemplate: TemplateRef<any>;
  actionOnListTemplate: TemplateRef<any>;
  customControlTemplate: TemplateRef<any>;
  
  nbSelectedElements = 0;

  constructor(
    protected location: Location,
    protected router: Router,
    private confirmationService: ConfirmationService,
    private biaDialogService: BiaDialogService
  ) {}


  ngAfterContentInit() {
    this.templates.forEach((item) => {
        switch(item.getType()) {
          case 'actionOnSelected':
            this.actionOnSelectedTemplate = item.template;
          break;
          case 'actionOnList':
            this.actionOnListTemplate = item.template;
          break;
          case 'customControl':
            this.customControlTemplate = item.template;
          break;
        }
    });
  }

  ngOnChanges() {
    if (this.selectedElements) {
      this.nbSelectedElements = this.selectedElements.length;
    } else {
      this.nbSelectedElements = 0;
    }
  }

  onBack() {
    window.history.length > 1 ? this.location.back() : this.router.navigate(['/']);
  }

  onCreate() {
    this.create.next();
  }

  onDelete() {
    const confirmation: Confirmation = {
      ...this.biaDialogService.getDeleteConfirmation(),
      accept: () => {
        this.delete.next();
      }
    };
    this.confirmationService.confirm(confirmation);
  }

  toggleFilter() {
    this.showFilter = !this.showFilter;
    if (this.showFilter === true) {
      this.openFilter.emit();
    }
  }
}
