import { Component, OnInit } from '@angular/core';
import { LoginModel } from 'src/app/modules/shared/models/login.model';
import { AuthenticationService } from 'src/app/modules/shared/services/authentication.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SafeUnsubscriber } from 'src/app/modules/shared/utility/safe-unsubscriber';
import { Subscription } from 'rxjs';
import { Dispatcher } from '../../../app.dispatcher';
import { AuthenticationLoginAction, AuthenticationActionNames } from 'src/app/modules/authentication/authentication.state/authentication.actions';
import { AuthenticationSelectors } from 'src/app/modules/authentication/authentication.state/authentication.selectors';
import { AppActionNames } from 'src/app/app.state/app.actions';
import { AppSelectors } from 'src/app/app.state/app.selectors';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends SafeUnsubscriber implements OnInit {

  constructor(private authService: AuthenticationService,
    private fb: FormBuilder,
    private dispatcher: Dispatcher,
    private authSelector: AuthenticationSelectors,
    private appSelector: AppSelectors,
    private router: Router) { 
    super();
    this.isLoginError = false;
    this.loginErrorMessage ='';
  }

  ngOnInit() {
    if(this.authService.isAuthenticated()){
      // If already login => Navigate to Homepage
      this.router.navigate(['/']);
    }
    this.safeSubscriptions(this.registerSubscriptions());
    this.buildForm();
  }

  buildForm(){
    this.frm = this.fb.group({
      username: [null, Validators.compose([Validators.required])],
      password: [null, Validators.compose([Validators.required])]
    });
  }
  registerSubscriptions() : Subscription[]{
    return [
      this.authSelector.actionSuccessOfSubtype$(AuthenticationActionNames.LOGIN)
          .subscribe((res) => {
            // Navigate to Authenticated pag
            this.router.navigate(['/management/dashboard']);
          }),
      this.appSelector.actionSuccessOfSubtype$(AppActionNames.SAVE_TOKEN)
          .subscribe((res)=>{
              console.log("Save Token Success");
          })    
    ];
  }

  public frm: FormGroup;
  public isLoginError: boolean;
  public loginErrorMessage: string;

  onLogin(){
    this.removeLoginError();
    var loginModel = new LoginModel();
    loginModel.email = this.frm.value.username;
    loginModel.password = this.frm.value.password;
    this.dispatcher.fire(new AuthenticationLoginAction(loginModel));
  }

  isShowLoginError() {
    return (
      this.frm.get("username").hasError("loginFail") &&
      this.frm.get("password").hasError("loginFail")
    );
  }

  isDisabledLoginButton() {
    return !!!this.frm.value.username || !!!this.frm.value.password;
  }

  removeLoginError(){
    this.loginErrorMessage = '';
    this.isLoginError = false;
    this.frm.get("username").setErrors({loginFail: null});
    this.frm.get("password").setErrors({loginFail: null});
  }

}
