import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/modules/shared/services/authentication.service';
import { LoginModel } from 'src/app/modules/shared/models/login.model';

@Component({
  selector: 'app-guest',
  templateUrl: './guest.component.html',
  styleUrls: ['./guest.component.scss']
})
export class GuestComponent implements OnInit {

  constructor(private authService: AuthenticationService) { }

  ngOnInit() {
  }

  username: string;
  password: string;

  login(){
    var loginModel = new LoginModel();
    loginModel.username = this.username;
    loginModel.password = this.password;
    this.authService.generateToken(loginModel).subscribe(
      data =>{
        this.authService.setToken(data.token);
      }
    );
  }
}
