import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(
    private httpClient: HttpClient) { }

    getAllCountries() {
      return this.httpClient.get<any>(`${environment.apiUrl}country`);
    }
}
