import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { LoginRequest } from '../models/login-request.model';
import { environment } from '../../enviroment';
import { Jwt } from '../models/jwt.model';
import { RegisterRequest } from '../models/register-request.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  
  constructor(private http: HttpClient) {}

  login(loginRequest: LoginRequest): Observable<Jwt> {
    return this.http.post<Jwt>(`${environment.apiUrl}/login`, loginRequest);
  }

  register(registerRequest: RegisterRequest): Observable<Jwt> {
    return this.http.post<Jwt>(`${environment.apiUrl}/register`, registerRequest);
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem('jwt');
    return token !== null;
  }

  logout(): void {
    localStorage.removeItem('jwt');
  }
}
