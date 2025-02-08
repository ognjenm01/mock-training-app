import { AuthGuard } from './guards/auth.guard';
import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { RegisterComponent } from './components/register/register.component';
import { TrainingInputComponent } from './components/training-input/training-input.component';
import { TrainingOverviewComponent } from './components/training-overview/training-overview.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: '', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'logout', component: LogoutComponent },
  { path: 'training/new', component: TrainingInputComponent, canActivate: [AuthGuard] },
  { path: 'training/overview', component: TrainingOverviewComponent, canActivate: [AuthGuard] },
];

export default routes;