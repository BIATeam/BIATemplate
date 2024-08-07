import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import { OptionDto } from 'src/app/shared/bia-shared/model/option-dto';
import { DomainUserOptionsActions } from './user-options-actions';

// This adapter will allow is to manipulate users (mostly CRUD operations)
export const userOptionsAdapter = createEntityAdapter<OptionDto>({
  selectId: (user: OptionDto) => user.id,
  sortComparer: false,
});

// -----------------------------------------
// The shape of EntityState
// ------------------------------------------
// interface EntityState<User> {
//   ids: string[] | number[];
//   entities: { [id: string]: User };
// }
// -----------------------------------------
// -> ids arrays allow us to sort data easily
// -> entities map allows us to access the data quickly without iterating/filtering though an array of objects

export interface State extends EntityState<OptionDto> {
  // additional props here
  lastUsersAdded: OptionDto[];
}

export const INIT_STATE: State = userOptionsAdapter.getInitialState({
  // additional props default values here
  lastUsersAdded: [],
});

export const userOptionReducers = createReducer<State>(
  INIT_STATE,
  on(DomainUserOptionsActions.loadAllSuccess, (state, { users }) =>
    userOptionsAdapter.setAll(users, state)
  ),
  // on(loadSuccess, (state, { user }) => userOptionsAdapter.upsertOne(user, state))
  on(
    DomainUserOptionsActions.userAddedInListSuccess,
    (state, { usersAdded }) => {
      return { ...state, lastUsersAdded: usersAdded };
    }
  )
);

export const getUserOptionById = (id: number) => (state: State) =>
  state.entities[id];
