import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersViewComponent } from './users-view/users-view.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [ UsersViewComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'users-view', component: UsersViewComponent },
    ])
  ]
})
export class AdminModule { }
