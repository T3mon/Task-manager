import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TasksComponent } from './tasks/tasks.component';
import { RouterModule } from '@angular/router';
import { AddTaskComponent } from './add-task/add-task.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EditTaskComponent } from './edit-task/edit-task.component';



@NgModule({
  declarations: [TasksComponent, AddTaskComponent, EditTaskComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'tasks', component: TasksComponent },
      { path: 'addTask', component: AddTaskComponent },
      { path: 'editTask', component: EditTaskComponent },
    ])
  ]
})
export class TaskModule { }
