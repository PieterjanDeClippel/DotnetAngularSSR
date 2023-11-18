import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  constructor(private httpClient: HttpClient) { }

  title = 'ClientApp';
  forecasts: WeatherForecast[] = [];

  ngOnInit() {
    this.httpClient.get<WeatherForecast[]>('https://localhost:7169/WeatherForecast').subscribe({
      next: (forecasts) => this.forecasts = forecasts,
      error: (error) => console.error(error)
    });
  }
}

export interface WeatherForecast {
  date: Date;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
