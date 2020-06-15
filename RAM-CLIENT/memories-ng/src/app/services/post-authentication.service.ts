import { Injectable } from '@angular/core';
import { LoginResponse } from '@ram/models';

@Injectable({
  providedIn: 'root'
})
export class PostAuthenticationService {

  constructor() { }

  setUser(user: LoginResponse) {
    localStorage.setItem('token', user.accessToken.token);
    localStorage.setItem('expires', user.accessToken.expiresIn.toString());
    localStorage.setItem('refreshToken', user.refreshToken);
  }

  logOut() {
    localStorage.removeItem('token');
    localStorage.removeItem('expires');
    localStorage.removeItem('refreshToken');
  }

  isLoggedIn() {
    const user = localStorage.getItem('token');
    return (user === null || user === 'null') ? false : true;
}
}
