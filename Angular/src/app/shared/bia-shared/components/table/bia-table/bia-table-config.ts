export enum PrimeNGFiltering {
  StartsWith = 'startsWith',
  Contains = 'contains',
  EndsWith = 'endsWith',
  Equals = 'equals',
  NotEquals = 'notEquals',
  In = 'in',
  Lt = 'lt',
  Lte = 'lte',
  Gt = 'gt',
  Gte = 'gte'
}

export enum PropType {
  Date = 'Date',
  DateTime = 'DateTime',
  Time = 'Time',
  TimeOnly = 'TimeOnly',
  TimeSecOnly = 'TimeSecOnly',
  Number = 'Number',
  Boolean = 'Boolean',
  String = 'String',
  OneToMany = 'OneToMany',
  ManyToMany = 'ManyToMany'
}

export interface CustomButton {
  classValue: string;
  numEvent: number;
  pTooltipValue: string;
  permission: string;
}

export class PrimeTableColumn {
  field: string;
  header: string;
  type: PropType;
  filterMode: PrimeNGFiltering;
  formatDate: string;
  isSearchable: boolean;
  isSortable: boolean;
  isEditable: boolean;
  maxlength: number;
  translateKey: string;
  searchPlaceholder: string;
  get isDate() {
    return this.type === PropType.Date || this.type === PropType.DateTime || this.type === PropType.Time;
  }
  get filterPlaceHolder() {
    if (this.searchPlaceholder !== undefined) {
      return this.searchPlaceholder;
    }
    return this.isDate === true ? 'bia.dateIso8601' : '';
  }

  constructor(field: string, header: string, maxlength = 255) {
    this.field = field;
    this.header = header;
    this.type = PropType.String;
    this.filterMode = PrimeNGFiltering.Contains;
    this.formatDate = '';
    this.isSearchable = true;
    this.isSortable = true;
    this.isEditable = true;
    this.maxlength = maxlength;
  }
}

export interface BiaListConfig {
  columns: PrimeTableColumn[];
}
