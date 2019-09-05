import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthenticationService } from './modules/shared/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>'
})
export class AppComponent implements OnInit, OnDestroy {
  constructor(private authenticationService: AuthenticationService,
    private router: Router) {}

  ngOnInit(): void {
    //this.router.navigate(['/']);
     if(!this.authenticationService.isAuthenticated()){
        this.router.navigate(['/authentication/login']);
     }
  }

  ngOnDestroy(): void {
    throw new Error("Method not implemented.");
  }
}
