import { Component, OnInit } from '@angular/core';
import { user } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  user: user[];

  constructor(private userService: UserService, private alertify: AlertifyService )  { }


  ngOnInit() {
    this.loadUsers();
  }

   

    loadUsers(){

    this.userService.getUsers().subscribe((user: user[]) => {
      this.user = user;
    }, error => {
      this.alertify.error(error);
  });

  }


}
