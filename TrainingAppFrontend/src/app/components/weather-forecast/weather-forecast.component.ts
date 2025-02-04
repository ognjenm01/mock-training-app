import { Component } from '@angular/core';
import { WeatherForecast } from '../../models/weather-forecast.model';
import { WeatherForecastService } from '../../services/weather-forecast.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-weather-forecast',
  imports: [CommonModule],
  templateUrl: './weather-forecast.component.html',
  styleUrl: './weather-forecast.component.css'
})
export class WeatherForecastComponent {
  weatherForecasts: WeatherForecast[] = [];

  constructor(private weatherForecastService: WeatherForecastService) {}

  ngOnInit(): void {
    this.weatherForecastService.getWeatherForecasts()
      .subscribe((data: WeatherForecast[]) => {
        this.weatherForecasts = data;
      });
  }
}
