import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/modules/shared/services/authentication.service';
import { Router } from '@angular/router';
import { AuthenticationSelectors } from 'src/app/modules/authentication/authentication.state/authentication.selectors';

@Component({
  selector: 'app-top-nav-bar',
  templateUrl: './top-nav-bar.component.html',
  styleUrls: ['./top-nav-bar.component.scss']
})
export class TopNavBarComponent implements OnInit {

  constructor(private authenService: AuthenticationService,
    private router: Router) { }
  public isAuthenticated = false;
  user = null;
  ngOnInit() {
     this.isAuthenticated = this.authenService.isAuthenticated();
     this.user = this.authenService.getAuthenticatedUser();
  }

  logout(){
    this.authenService.clearToken();
    this.router.navigate(['/authentication/login']);
  }
}
