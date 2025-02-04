import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WeatherForecast } from '../models/weather-forecast.model';
@Injectable({
  providedIn: 'root'
})
export class WeatherForecastService {

  private apiUrl = 'https://localhost:7297/weatherforecast';

  constructor(private http: HttpClient) { }

  getWeatherForecasts(): Observable<WeatherForecast[]> {
    return this.http.get<WeatherForecast[]>(this.apiUrl);
  }
}
