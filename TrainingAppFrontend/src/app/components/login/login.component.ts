import {ChangeDetectionStrategy, Component} from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button'
import { FormsModule } from '@angular/forms';
import { LoginRequest } from '../../models/login-request.model';
import { AuthService } from '../../services/auth.service';
import { SnackbarService } from '../../services/snackbar.service';
import { Jwt } from '../../models/jwt.model';

@Component({
  selector: 'app-login',
  imports: [MatCardModule, MatFormFieldModule, MatIconModule, MatInputModule, MatButtonModule, FormsModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
    hidePassword = true;
    loginRequest: LoginRequest = { username: '', password: '' };

    constructor(private authService: AuthService, private snackBarService: SnackbarService) {}

    login() {
      this.authService.login(this.loginRequest).subscribe({
        next: (response: Jwt) => {
          localStorage.setItem("jwt", response.token);
          this.snackBarService.showSuccess("Successfully logged in!");
        },

        error: (error) => {
          console.log(error);
          this.snackBarService.showError("Failed to login!");
        }
      })
    }
}
