import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TasksComponent } from './tasks/tasks.component';
import { RouterModule } from '@angular/router';
import { AddTaskComponent } from './add-task/add-task.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [TasksComponent, AddTaskComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: '', component: TasksComponent },
      { path: 'addTask', component: AddTaskComponent },
    ])
  ]
})
export class TaskModule { }
