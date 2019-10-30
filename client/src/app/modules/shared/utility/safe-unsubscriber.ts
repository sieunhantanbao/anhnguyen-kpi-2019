import { OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';

export class SafeUnsubscriber implements OnDestroy{
    private subscriptions: Subscription[] = [];

    protected onDestroyHandler = null;
    constructor(){
        const func = this.ngOnDestroy;
        this.ngOnDestroy = ()=>{
            func();
            !!this.onDestroyHandler && this.onDestroyHandler();
            this.unSubscribAll();
        }
    }
    protected safeSubscription(sub: Subscription): Subscription{
        this.subscriptions.push(sub);
        return sub;
    }
    protected safeSubscriptions(subs: Subscription[]): Subscription[]{
        this.subscriptions.push(...subs);
        return subs;
    }
    public unSubscribAll(){
        this.subscriptions.forEach(e=>!e.closed && e.unsubscribe());
    }

    ngOnDestroy() {
    }
} 