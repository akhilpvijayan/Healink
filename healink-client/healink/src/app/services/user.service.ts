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

    async getUserDetail(userId: any) {
      try {
        const response = await this.httpClient.get<any>(`${environment.apiUrl}users/`+userId).toPromise();
        this.userDetails = response as any[];
        return this.userDetails;
      } catch (error) {
        // Handle error if needed
        console.error('Error fetching user details:', error);
        throw error; // Re-throw error to be caught by the caller if necessary
      }
    }
}
