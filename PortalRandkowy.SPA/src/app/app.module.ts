import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { from } from 'rxjs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { UserService } from './_services/user.service';
import { AlertifyService } from './_services/alertify.service';
import { LikesComponent } from './likes/likes.component';
import { MessagesComponent } from './messages/messages.component';
import {appRoutes} from './routes';
import {AuthGuard} from '../app/_guards/auth.guard';


export function GetToken(){
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [		
    AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      UserListComponent,
      LikesComponent,
      MessagesComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    JwtModule.forRoot({
        config: {
          tokenGetter: GetToken,
          allowedDomains: ['localhost:5001'],
          disallowedRoutes: ['localhost:5001/api/auth'],
    }
    
  }),
  RouterModule.forRoot(appRoutes),
  BrowserAnimationsModule,
  BsDropdownModule.forRoot()
  ],
  providers: [
    AuthService,
    AlertifyService,
    UserService,
    AuthGuard

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
