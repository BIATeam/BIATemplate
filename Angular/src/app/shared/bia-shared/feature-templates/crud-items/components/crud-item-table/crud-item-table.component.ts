import { Component, OnChanges } from '@angular/core';
import { UntypedFormBuilder, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from 'src/app/core/bia-core/services/auth.service';
import { BiaMessageService } from 'src/app/core/bia-core/services/bia-message.service';
import { BiaOptionService } from 'src/app/core/bia-core/services/bia-option.service';
import { BiaCalcTableComponent } from 'src/app/shared/bia-shared/components/table/bia-calc-table/bia-calc-table.component';
import { BaseDto } from 'src/app/shared/bia-shared/model/base-dto';
import { PropType } from 'src/app/shared/bia-shared/model/bia-field-config';
import { DtoState } from 'src/app/shared/bia-shared/model/dto-state.enum';
import { OptionDto } from 'src/app/shared/bia-shared/model/option-dto';

@Component({
  selector: 'bia-crud-item-table',
  templateUrl:
    '../../../../components/table/bia-calc-table/bia-calc-table.component.html',
  styleUrls: [
    '../../../../components/table/bia-calc-table/bia-calc-table.component.scss',
  ],
})
export class CrudItemTableComponent<CrudItem extends BaseDto>
  extends BiaCalcTableComponent<CrudItem>
  implements OnChanges
{
  constructor(
    public formBuilder: UntypedFormBuilder,
    public authService: AuthService,
    public biaMessageService: BiaMessageService,
    public translateService: TranslateService
  ) {
    super(formBuilder, authService, biaMessageService, translateService);
  }

  public initForm() {
    this.form = this.formBuilder.group(this.formFields());
    if (this.configuration.formValidators) {
      this.form.addValidators(this.configuration.formValidators);
    }
  }
  protected formFields() {
    const fields: { [key: string]: any } = { id: [this.element.id] };
    for (const col of this.configuration.columns) {
      if (col.validators && col.validators.length > 0) {
        fields[col.field.toString()] = [
          this.element[col.field],
          col.validators,
        ];
      } else if (col.isRequired) {
        fields[col.field.toString()] = [
          this.element[col.field],
          Validators.required,
        ];
      } else {
        fields[col.field.toString()] = [this.element[col.field]];
      }
    }
    return fields;
  }

  onSubmit() {
    if (this.form.valid) {
      const crudItem: CrudItem = <CrudItem>this.form.value;
      crudItem.id = crudItem.id ?? 0;
      for (const col of this.configuration.columns) {
        switch (col.type) {
          case PropType.Boolean:
            Reflect.set(
              crudItem,
              col.field,
              crudItem[col.field] ? crudItem[col.field] : false
            );
            break;
          case PropType.ManyToMany:
            Reflect.set(
              crudItem,
              col.field,
              BiaOptionService.differential(
                Reflect.get(crudItem, col.field) as BaseDto[],
                (this.element
                  ? (Reflect.get(this.element, col.field) ?? [])
                  : []) as BaseDto[]
              )
            );
            break;
          case PropType.OneToMany:
            if (
              col.isEditableChoice &&
              typeof crudItem[col.field as keyof CrudItem] === 'string'
            ) {
              Reflect.set(
                crudItem,
                col.field,
                new OptionDto(
                  0,
                  crudItem[col.field as keyof CrudItem] as string,
                  DtoState.AddedNewChoice
                )
              );
            } else {
              Reflect.set(
                crudItem,
                col.field,
                BiaOptionService.clone(crudItem[col.field as keyof CrudItem])
              );
            }
            break;
        }
      }

      this.save.emit(crudItem);
      this.form.reset();
    }
  }
}
