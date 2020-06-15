import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegistrationModel, RegistrationResponse, LoginModel,
  LoginResponse, RefreshTokenModel } from '@ram/models';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  apiUrl = 'https://localhost:5001/api/';
  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*'
    });

  constructor(private http: HttpClient) { }

  registerUser(user: RegistrationModel): Observable<RegistrationResponse> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
      });
    const url = `${this.apiUrl}user/auth/register`;
    return this.http.post<RegistrationResponse>(url, user, { headers,
      withCredentials: true
    });
  }

  loginUser(user: LoginModel): Observable<LoginResponse> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
      });
    const url = `${this.apiUrl}user/auth/login`;
    return this.http.post<LoginResponse>(url, user, { headers,
      withCredentials: true
    });
  }

  refreshUserToken(tokenModel: RefreshTokenModel): Observable<LoginResponse> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
      });
    const url = `${this.apiUrl}user/auth/refreshtoken`;
    return this.http.post<LoginResponse>(url, tokenModel, { headers,
      withCredentials: true
    });
  }
}
