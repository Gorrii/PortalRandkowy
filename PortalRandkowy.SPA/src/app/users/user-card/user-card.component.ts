import { Component, OnInit, Input } from '@angular/core';
import{ user } from 'src/app/_models/user';
import { from } from 'rxjs';


@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit {

  @Input() user: user;

  constructor() { }

  ngOnInit() {
  }

}
