import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  @Input() valuesFromHome: any;
  @Output() CancelRegister = new EventEmitter();
  model: any = {};
  constructor() { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
  }

  // tslint:disable-next-line: typedef
  register(){
    console.log(this.model);
  }

  // tslint:disable-next-line: typedef
  cancel(){
    this.CancelRegister.emit(false);
    console.log('akcja zostala anulowana');
  }

}
