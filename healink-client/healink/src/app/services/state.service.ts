import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StateService {

  constructor(
    private httpClient: HttpClient) { }

    getstateByCountryId(countryId : number) {
      return this.httpClient.get<any>(`${environment.apiUrl}state/`+countryId);
    }
}
