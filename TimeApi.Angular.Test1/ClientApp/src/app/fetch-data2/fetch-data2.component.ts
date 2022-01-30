import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data2.component.html'
})
export class FetchDataComponent2 {  // FIXME:
  //public forecasts: WeatherForecast[] = [];
  public spicavalues: Spica[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    /*
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
    */
    http.get<Spica[]>(baseUrl + 'spica').subscribe(result => {
      this.spicavalues = result;
    }, error => console.error(error));

  }
}
/*
interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
*/

interface Spica {
  value1: string;
  value2: string;
}
