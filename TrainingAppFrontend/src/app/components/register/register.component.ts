import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { SnackbarService } from '../../services/snackbar.service';
import { CommonModule } from '@angular/common';
import { RegisterRequest } from '../../models/register-request.model';
import { AuthService } from '../../services/auth.service';
import { Jwt } from '../../models/jwt.model';

@Component({
  selector: 'app-register',
  imports: [MatCardModule, MatFormFieldModule, MatIconModule, MatInputModule, MatButtonModule, FormsModule, ReactiveFormsModule, CommonModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerForm: FormGroup;
  hidePassword = true;
  hidePasswordRepeat = true;
  request : RegisterRequest = {username: "", password: ""};

  constructor(private fb: FormBuilder, private snackBarService: SnackbarService, private authService : AuthService) {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [
        Validators.required,
        Validators.minLength(8),
        Validators.pattern(/[A-Z]/),
        Validators.pattern(/\d/),
      ]],
      repeatPassword: ['', Validators.required],
    });
  }

  get email() {
    return this.registerForm.get('email');
  }

  get password() {
    return this.registerForm.get('password');
  }

  get repeatPassword() {
    return this.registerForm.get('repeatPassword');
  }


  register() {
    if(this.password?.value != this.repeatPassword?.value)
    {
      this.snackBarService.showError("Passwords must be equal!");
    }
    else {
      this.request.username = this.email?.value;
      this.request.password = this.password?.value;

      this.authService.register(this.request).subscribe({
        next: (response: Jwt) => {
          localStorage.setItem("jwt", response.token);
          this.snackBarService.showSuccess("Successfully registered!");
          //Redirect here...
        },

        error: (err) => {
          this.snackBarService.showError("Failed to register. Username may be already taken.")
        }
      })
    }
  }
}
