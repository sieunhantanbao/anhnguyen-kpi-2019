import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/modules/shared/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-authenticated',
  templateUrl: './authenticated.component.html',
  styleUrls: ['./authenticated.component.scss']
})
export class AuthenticatedComponent implements OnInit {

  constructor(private authenService: AuthenticationService,
    private router: Router) { }
  ngOnInit() {
    if(!this.authenService.isAuthenticated()){
        this.router.navigate(['/authentication/login']);
    }
  }

}
