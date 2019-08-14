import { NgModule } from "@angular/core";
import { StoreModule } from '@ngrx/store';
import { authenticationModule } from './authentication.state/authentication.reducer';
import { AppSelectors } from 'src/app/app.state/app.selectors';
import { RouterModule } from '@angular/router';
import { AuthenticationRoutes } from './authentication.routing';

@NgModule(
    {
        imports: [
            RouterModule.forChild(AuthenticationRoutes),
            StoreModule.forFeature('authenticationModule', authenticationModule)
        ],
        declarations: [

        ],
        providers: [
            AppSelectors
        ],
        exports: [

        ]
    }
)
export class AuthenticationModule{

}