import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { from } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

constructor(private http: HttpClient) { }

// tslint:disable-next-line: typedef
login( model: any){
  return this.http.post(this.baseUrl + 'login', model)
    .pipe(map((response: any) => {
      const user = response;
      if (user) {
         localStorage.setItem('token', user.token);
         this.decodedToken = this.jwtHelper.decodeToken(user.token);
         console.log(this.decodedToken);
      }
}));

}
// tslint:disable-next-line: typedef
register(model: any)
{
  // tslint:disable-next-line: no-unused-expression
  return this.http.post(this.baseUrl + 'register' , model);
}
loggedIn()
{
  const token = localStorage.getItem('token');
  return !this.jwtHelper.isTokenExpired(token);


}

}
