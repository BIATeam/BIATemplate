import { createAction, props } from '@ngrx/store';
import { LazyLoadEvent } from 'primeng/api';
import { Member, Members } from '../model/member';
import { DataResult } from 'src/app/shared/bia-shared/model/data-result';

export namespace FeatureMembersActions
{
  export const loadAllByPost = createAction('[Members] Load all by post', props<{ event: LazyLoadEvent }>());

  export const load = createAction('[Members] Load', props<{ id: number }>());

  export const create = createAction('[Members] Create', props<{ member: Member }>());

  export const createMulti = createAction('[Members] Create multi', props<{ members: Members }>());

  export const update = createAction('[Members] Update', props<{ member: Member }>());

  export const remove = createAction('[Members] Remove', props<{ id: number }>());

  export const multiRemove = createAction('[Members] Multi Remove', props<{ ids: number[] }>());

  export const loadAllByPostSuccess = createAction(
    '[Members] Load all by post success',
    props<{ result: DataResult<Member[]>; event: LazyLoadEvent }>()
  );

  export const loadSuccess = createAction('[Members] Load success', props<{ member: Member }>());

  export const failure = createAction('[Members] Failure', props<{ error: any }>());
}







