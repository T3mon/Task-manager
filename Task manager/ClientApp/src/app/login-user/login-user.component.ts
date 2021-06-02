import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserForLoginDto } from '../_interfaces/user/userForLoginDto';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})
export class LoginUserComponent implements OnInit {


  registrationApplicationForm: FormGroup = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required],
    passwordConfirm: ['', Validators.required]
  })


  private baseUrl: string;

  constructor(private formBuilder: FormBuilder, private router: Router,
    private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;

  }

  ngOnInit() {
  }

  public isControlInvalid(controlName: string): boolean {
    return this.registrationApplicationForm.controls[controlName].invalid && this.registrationApplicationForm.controls[controlName].touched


  }
  public hasError = (controlName: string, errorName: string) => {
    return this.registrationApplicationForm.controls[controlName].hasError(errorName)
  }

  public onSubmit(loginFormValue) {

    const formValues = { ...loginFormValue };

    const user: UserForLoginDto = {
      email: formValues.email,
      password: formValues.password
    };
    this.http.post(this.baseUrl + 'api/accounts/Login', user).subscribe(
      result => {
        console.log("Successful login");

        this.router.navigate(['/home']);
      },
      error => {
        console.log(error.error.errors);
      }
    );
  }



}
