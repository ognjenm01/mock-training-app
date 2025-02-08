import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, Observable, tap, throwError } from 'rxjs';
import { LoginRequest } from '../models/login-request.model';
import { environment } from '../../enviroment';
import { Jwt } from '../models/jwt.model';
import { RegisterRequest } from '../models/register-request.model';
import { SnackbarService } from './snackbar.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private isLoggedInSubject = new BehaviorSubject<boolean>(this.hasToken());
  
  constructor(private http: HttpClient, private snackBarService: SnackbarService) {}

  login(loginRequest: LoginRequest) {
    this.http.post<Jwt>(`${environment.apiUrl}/login`, loginRequest).subscribe({
      next: (response: Jwt) => {
        localStorage.setItem("jwt", response.token);
        this.snackBarService.showSuccess("Successfully logged in!");
        this.isLoggedInSubject.next(true);
      },

      error: (error) => {
        console.log(error);
        this.snackBarService.showError("Failed to login!");
      }
    })
  }

  register(registerRequest: RegisterRequest) {
    this.http.post<Jwt>(`${environment.apiUrl}/register`, registerRequest).subscribe({
      next: (response: Jwt) => {
        localStorage.setItem("jwt", response.token);
        this.snackBarService.showSuccess("Successfully logged in!");
        this.isLoggedInSubject.next(true);
      },

      error: (error) => {
        console.log(error);
        this.snackBarService.showError("Failed to login!");
      }
    })
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem('jwt');
    return token !== null;
  }

  logout(): void {
    localStorage.removeItem('jwt');
    this.isLoggedInSubject.next(false);
  }

  get isLoggedIn$(): Observable<boolean> {
    return this.isLoggedInSubject.asObservable();
  }

  private hasToken(): boolean {
    return !!localStorage.getItem("jwt");
  }
}
