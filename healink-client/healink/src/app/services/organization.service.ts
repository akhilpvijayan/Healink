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

    getOrganizationTypes() {
      return this.httpClient.get<any>(`${environment.apiUrl}organizations/types/`);
    }

    getOrganizationSizes() {
      return this.httpClient.get<any>(`${environment.apiUrl}organizations/size/`);
    }

    addOrganizationr(data: any){
      return this.httpClient.post<any>(`${environment.apiUrl}organization/`, data);
    }
}
