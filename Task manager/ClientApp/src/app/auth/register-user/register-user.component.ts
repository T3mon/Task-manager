import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormArray, FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { UseruFullDto } from '../../_interfaces/user/userForRegistrationDto.model';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {

  roles: any = ['Administrator', 'TeamManager', 'Developer']

  registrationApplicationForm: FormGroup = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required],
    passwordConfirm: ['', Validators.required],
    role: new FormControl(this.roles)
  })

  private baseUrl: string;

  constructor(private formBuilder: FormBuilder, private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }


  public isControlInvalid(controlName: string): boolean {
    return this.registrationApplicationForm.controls[controlName].invalid && this.registrationApplicationForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.registrationApplicationForm.controls[controlName].hasError(errorName)
  }

  public onSubmit(registerFormValue) {

    const formValues = { ...registerFormValue };


    if (formValues.password == formValues.passwordConfirm) {
      const user: UseruFullDto = {
        email: formValues.email,
        password: formValues.password,
        confirmPassword: formValues.passwordConfirm,
        role: formValues.role
      };
      this.http.post(this.baseUrl + 'api/accounts/RegisterUser', user).subscribe(
        result => {
          console.log("Successful registration");

          this.router.navigate(['/home']);
        },
        error => {
          console.log(error.error.errors);
        }
      );
    }
    else {
      alert("passwords dont match");
    }

  }

  ngOnInit() {
  }

}
