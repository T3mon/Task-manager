import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserFullDto } from '../../_interfaces/user/userForRegistrationDto.model';
import { userTaskDto } from '../../_interfaces/user/userTaskDto';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})

export class AddTaskComponent implements OnInit {
  private baseUrl: string;
  public users:  UserFullDto[];
  statuses: any = ['ReadyForDevelopment', 'InProgress', 'ReadyForDevelopment', 'ReadyForTesting']

  addTaskForm: FormGroup = this.formBuilder.group({
    title: ['', [Validators.required]],
    description: ['', [Validators.required]],
    status: ['', [Validators.required]],
    assignedTo: ['', Validators.required]
  })

  constructor(private formBuilder: FormBuilder, private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public isControlInvalid(controlName: string): boolean {
    return this.addTaskForm.controls[controlName].invalid && this.addTaskForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.addTaskForm.controls[controlName].hasError(errorName)
  }
  //User and Status getters
  get status() {
    return this.addTaskForm.get('statuses');
  }
  get assignedTo() {
    return this.addTaskForm.get('users');
  }

  public onSubmit(addTaskFormValue) {
    //this sends task to controller
    const formValues = { ...addTaskFormValue };

    const task: userTaskDto = {
      title: formValues.title,
      description: formValues.description,
      status: formValues.status,
      assignedTo: formValues.assignedTo.email
    };

    this.http.post(this.baseUrl + 'api/admin/AddTask', task).subscribe(
      result => {
        console.log("Successful login");

        this.router.navigate(['/task']);
      },
      error => {
        console.log(error.error.errors);
      }
    );
  }

  ngOnInit() {
    this.http.get<Array<UserFullDto>>(this.baseUrl + 'api/admin/GetUsers').subscribe(data => {
      this.users = data;
    })
  }

}
