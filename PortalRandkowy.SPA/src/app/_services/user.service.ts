import { Injectable } from '@angular/core';
import {environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, from } from 'rxjs';
// tslint:disable-next-line: import-spacing
import {user} from '../_models/user';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUsers(): Observable<user[]>{
    return this.http.get<user[]>(this.baseUrl + 'users');

  }
  getUser(id: number): Observable<user>{
    return this.http.get<user>(this.baseUrl + 'users/' + id);
  }
}
