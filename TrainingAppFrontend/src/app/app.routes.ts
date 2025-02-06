import { AuthGuard } from './guards/auth.guard';
import { WeatherForecastComponent } from './components/weather-forecast/weather-forecast.component';
import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { RegisterComponent } from './components/register/register.component';

const routes: Routes = [
  //{ path: '', component: HomeComponent },
  { path: 'weather-forecast', component: WeatherForecastComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'logout', component: LogoutComponent },
];

export default routes;