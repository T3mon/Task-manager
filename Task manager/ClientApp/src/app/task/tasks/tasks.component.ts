import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { userTaskDto } from '../../_interfaces/user/userTaskDto';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  private baseUrl: string;
  private tasks: userTaskDto[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  ngOnInit() {
    this.http.get<Array<userTaskDto>>(this.baseUrl + 'api/action/GetTasks').subscribe(data => {
      this.tasks = data;
    })  
  }

}
