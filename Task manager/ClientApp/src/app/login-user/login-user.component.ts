import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../shared/services/authentication.service';
import { UserForLoginDto } from '../_interfaces/user/userForLoginDto';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})
export class LoginUserComponent implements OnInit {
  private _returnUrl: string;


  loginApplicationForm: FormGroup = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  })


  private baseUrl: string;

  constructor(private _authService: AuthenticationService, private formBuilder: FormBuilder, private router: Router, private route: ActivatedRoute,
    private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;

  }

  ngOnInit() {
    this._returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  public isControlInvalid(controlName: string): boolean {
    return this.loginApplicationForm.controls[controlName].invalid && this.loginApplicationForm.controls[controlName].touched


  }
  public hasError = (controlName: string, errorName: string) => {
    return this.loginApplicationForm.controls[controlName].hasError(errorName)
  }

  public onSubmit(loginFormValue) {

    const formValues = { ...loginFormValue };

    const user: UserForLoginDto = {
      email: formValues.email,
      password: formValues.password
    };

    this._authService.loginUser('api/accounts/Login', user).subscribe(
      result => {
        console.log("Successful login");
        localStorage.setItem("token", result.token);
        this._authService.sendAuthStateChangeNotification(result.isAuthSuccessful);
        //this.router.navigate([this._returnUrl]);

        this.router.navigate(['/task']);
      },
      error => {
        console.log(error.error.errors);
      }
    );
  }



}
