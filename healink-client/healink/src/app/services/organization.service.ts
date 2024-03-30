import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrganizationService {
  constructor(
    private httpClient: HttpClient) { }

    getOrganizationForSignup() {
      return this.httpClient.get<any>(`${environment.apiUrl}organizations/signup/`);
    }

    getEducationalOrganizations() {
      return this.httpClient.get<any>(`${environment.apiUrl}organizations/education/`);
    }
}
