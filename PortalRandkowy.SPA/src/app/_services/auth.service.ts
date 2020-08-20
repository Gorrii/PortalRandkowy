import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { from } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = 'https://localhost:5001/auth/';

constructor(private http: HttpClient) { }

// tslint:disable-next-line: typedef
login( model: any){
  return this.http.post(this.baseUrl + 'login', model)
    .pipe(map((response: any) => {
      const user = response;
      if (user) {
         localStorage.setItem('token', user.token);
      }
}));

}
// tslint:disable-next-line: typedef
register(model: any)
{
  // tslint:disable-next-line: no-unused-expression
  return this.http.post(this.baseUrl + 'register' , model);
}

}
