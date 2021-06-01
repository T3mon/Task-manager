import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormArray, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserForRegistrationDto } from '../../_interfaces/user/userForRegistrationDto.model';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  registrationApplication: RegistrationApplication;
  public fb: FormBuilder;

  registrationApplicationForm: FormGroup = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    passwrod: ['', Validators.required],
    confirm: ['', Validators.required]
  })

  private baseUrl: string;

  constructor(private formBuilder: FormBuilder, private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }


  public isControlInvalid(controlName: string): boolean {
    //let control = this.registrationApplicationForm.get(controllName);
    //return !control.valid;
    return this.registrationApplicationForm.controls[controlName].invalid && this.registrationApplicationForm.controls[controlName].touched


  }
  public hasError = (controlName: string, errorName: string) => {
    return this.registrationApplicationForm.controls[controlName].hasError(errorName)
  }

  public onSubmit(registerFormValue) {

    const formValues = { ...registerFormValue };

    const user: UserForRegistrationDto = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm
    };

    this.http.post(this.baseUrl + 'account/Registration', user).subscribe(
      result => {
        console.log("Successful registration");

        this.router.navigate(['/home']);
      },
      error => {
        console.log(error.error.errors);
      }
    );

  }

  ngOnInit() {
  }

}
export class RegistrationApplication {
  email: string;
  password: string;

}
