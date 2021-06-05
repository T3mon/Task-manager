import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
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

  constructor(private authenticationService: AuthenticationService, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
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
