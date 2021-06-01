import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { RouterModule } from '@angular/router';
import { RegisterUserComponent } from './register-user/register-user.component';



@NgModule({
  declarations: [RegisterUserComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'register', component: RegisterUserComponent },
    ])
  ]
})
export class AuthModule { }
