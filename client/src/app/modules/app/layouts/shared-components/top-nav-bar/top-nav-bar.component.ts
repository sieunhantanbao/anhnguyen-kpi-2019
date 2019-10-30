import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/modules/shared/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-top-nav-bar',
  templateUrl: './top-nav-bar.component.html',
  styleUrls: ['./top-nav-bar.component.scss']
})
export class TopNavBarComponent implements OnInit {

  constructor(private authenService: AuthenticationService,
    private router: Router) { }
  public isAuthenticated = false;
  ngOnInit() {
     this.isAuthenticated = this.authenService.isAuthenticated();
  }

  logout(){
    this.authenService.clearToken();
    this.router.navigate(['/authentication/login']);
  }
}
