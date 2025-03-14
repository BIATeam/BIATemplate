import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import { TableLazyLoadEvent } from 'primeng/table';
import { Site } from '../model/site';
import { FeatureSitesActions } from './sites-actions';

// This adapter will allow is to manipulate sites (mostly CRUD operations)
export const sitesAdapter = createEntityAdapter<Site>({
  selectId: (site: Site) => site.id,
  sortComparer: false,
});

// -----------------------------------------
// The shape of EntityState
// ------------------------------------------
// interface EntityState<Site> {
//   ids: string[] | number[];
//   entities: { [id: string]: Site };
// }
// -----------------------------------------
// -> ids arrays allow us to sort data easily
// -> entities map allows us to access the data quickly without iterating/filtering though an array of objects

export interface State extends EntityState<Site> {
  // additional props here
  totalCount: number;
  currentSite: Site;
  lastLazyLoadEvent: TableLazyLoadEvent;
  loadingGet: boolean;
  loadingGetAll: boolean;
}

export const INIT_STATE: State = sitesAdapter.getInitialState({
  // additional props default values here
  totalCount: 0,
  currentSite: <Site>{},
  lastLazyLoadEvent: <TableLazyLoadEvent>{},
  loadingGet: false,
  loadingGetAll: false,
});

export const siteReducers = createReducer<State>(
  INIT_STATE,
  on(FeatureSitesActions.clearAll, state => {
    const stateUpdated = sitesAdapter.removeAll(state);
    stateUpdated.totalCount = 0;
    return stateUpdated;
  }),
  on(FeatureSitesActions.clearCurrent, state => {
    return { ...state, currentSite: <Site>{} };
  }),
  on(FeatureSitesActions.loadAllByPost, state => {
    return { ...state, loadingGetAll: true };
  }),
  on(FeatureSitesActions.load, state => {
    return { ...state, loadingGet: true };
  }),
  on(FeatureSitesActions.loadAllByPostSuccess, (state, { result, event }) => {
    const stateUpdated = sitesAdapter.setAll(result.data, state);
    stateUpdated.totalCount = result.totalCount;
    stateUpdated.lastLazyLoadEvent = event;
    stateUpdated.loadingGetAll = false;
    return stateUpdated;
  }),
  on(FeatureSitesActions.loadSuccess, (state, { site }) => {
    return { ...state, currentSite: site, loadingGet: false };
  }),
  on(FeatureSitesActions.failure, state => {
    return { ...state, loadingGetAll: false, loadingGet: false };
  })
);

export const getSiteById = (id: number) => (state: State) => state.entities[id];
