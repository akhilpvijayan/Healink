import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  userDetails !: any[];
  constructor(
    private httpClient: HttpClient) { }

    getUserDetail(userId: any) {
      return this.httpClient.get<any>(`${environment.apiUrl}users/`+userId);
    }
}
