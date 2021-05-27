import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormArray, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  registrationApplication: RegistrationApplication ;
  public fb: FormBuilder;

  registrationApplicationForm: FormGroup = this.formBuilder.group({
    email: ['', Validators.required, Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$')],
    passwrod: ['', Validators.required],
  })


  constructor(private formBuilder: FormBuilder) {
  }


  public isControlInvalid(controllName: string): boolean {
    let control = this.registrationApplicationForm.get(controllName);

    return !control.value;

  }

    public onSubmit() {
      this.registrationApplicationForm = this.registrationApplicationForm.value;

      localStorage.setItem('promotionApplication', JSON.stringify(this.registrationApplication));

  }
  private populateForm() {
    this.registrationApplication = JSON.parse(localStorage.getItem('promotionApplication'));

    if (this.registrationApplication) {
      this.registrationApplicationForm.setValue(this.registrationApplication);
    }
  }
ngOnInit() {
}

}
export class RegistrationApplication {
  email: string;
  password: string;

}
