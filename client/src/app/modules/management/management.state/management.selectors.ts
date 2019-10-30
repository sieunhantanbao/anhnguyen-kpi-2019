import { Injectable } from '@angular/core';
import { BaseSelector } from '../../shared/models/base.selector';
import { Observable } from 'rxjs';
import { ManagementSuccessAction, ManagementFailedAction, ManagementActionNames } from './management.actions';
import { Store } from '@ngrx/store';
import { Actions } from '@ngrx/effects';

@Injectable()
export class ManagementSelectors extends BaseSelector{
    public actionSuccess$: Observable<ManagementSuccessAction>;
    public actionFailed$ : Observable<ManagementFailedAction>;

    constructor(
        private store: Store<any>,
        private managementActions$: Actions
    ){
        super(managementActions$, ManagementActionNames.ACTION_SUCCESS, ManagementActionNames.ACTION_FAILED);
    }
}