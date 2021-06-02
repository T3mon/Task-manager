import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { UserFullDto } from '../../_interfaces/user/userForRegistrationDto.model';

@Component({
  selector: 'app-users-view',
  templateUrl: './users-view.component.html',
  styleUrls: ['./users-view.component.css']
})
export class UsersViewComponent implements OnInit {
  private baseUrl: string;
  private users: UserFullDto[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
 }

  ngOnInit() {
    this.http.get<Array<UserFullDto>>(this.baseUrl + 'api/admin/GetUsers').subscribe(data => {
      this.users = data;
    })  
  }

}
