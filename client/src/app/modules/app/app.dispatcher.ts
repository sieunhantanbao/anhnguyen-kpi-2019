import { Injectable } from "@angular/core";
import { Store, Action } from '@ngrx/store';

@Injectable()
export class Dispatcher {
    public store: Store<any>;
    constructor(data: Store<any>){
        this.store = data;
    }

    public fire(action: Action){
        this.store.dispatch(action);
    }
}