import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AdminGuard } from '../../shared/guards/admin.guard';
import { AuthenticationService } from '../../shared/services/authentication.service';
import { userTaskDto } from '../../_interfaces/user/userTaskDto';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  private baseUrl: string;
  private IsUserAdmin: boolean;
  private tasks: userTaskDto[];

  statuses: any = ['ReadyForDevelopment', 'InProgress', 'ReadyForDevelopment', 'ReadyForTesting']


  statusChangeForm = this.fb.group({
    status: ['', [Validators.required]]
  })
  public changeStatus(e) {
    console.log(e.target.value)

  }
  get status() {
    return this.statusChangeForm.get('statuses');
  }
  constructor(public fb: FormBuilder,private authenticationService: AuthenticationService, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    if (authenticationService.getUserRole() === "Administrator") {
      this.IsUserAdmin = true;
    } else {
      this.IsUserAdmin = false;
    }
  }
  ngOnInit() {
    this.http.get<Array<userTaskDto>>(this.baseUrl + 'api/action/GetTasks').subscribe(data => {
      this.tasks = data;
    })
  }

}
