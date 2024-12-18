import { BaseDto } from 'src/app/shared/bia-shared/model/base-dto';
import {
  BiaFieldConfig,
  BiaFieldsConfig,
  PropType,
} from 'src/app/shared/bia-shared/model/bia-field-config';
import { OptionDto } from 'src/app/shared/bia-shared/model/option-dto';

// TODO after creation of CRUD Member : adapt the model
export interface Member extends BaseDto {
  user: OptionDto;
  roles: OptionDto[];
  teamId: number;
}

export class Members {
  users: OptionDto[];
  roles: OptionDto[];
  teamId: number;
}

// TODO after creation of CRUD Member : adapt the field configuration
export const memberFieldsConfiguration: BiaFieldsConfig<Member> = {
  columns: [
    Object.assign(new BiaFieldConfig<Member>('user', 'member.user'), {
      isRequired: true,
      type: PropType.OneToMany,
      isEditableChoice: true,
    }),
    Object.assign(new BiaFieldConfig<Member>('roles', 'member.roles'), {
      type: PropType.ManyToMany,
    }),
  ],
};
