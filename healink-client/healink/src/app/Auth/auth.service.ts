import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { TokenApi } from '../interfaces/token-api';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private httpClient: HttpClient,
    private router: Router) { }

  signUp(userDetails: any){
    return this.httpClient.post<any>(`${environment.apiUrl}register`, userDetails);
  }

  login(userCredentials: any){
    const headers = new HttpHeaders().set('X-Skip-Interceptor', 'true');
    return this.httpClient.post<any>(`${environment.apiUrl}login`, userCredentials,{ headers });
  }

  setToken(tokenValue: string){
    localStorage.setItem('healink-token', tokenValue);
  }

  setUser(userId: number){
    localStorage.setItem('healink-user-id', userId.toString());
  }

  getToken(){
    return localStorage.getItem('healink-token');
  }

  isLoggedIn(): boolean{
    return !!localStorage.getItem('healink-token'); //if token returns true, else false
  }

  signOut(){
    localStorage.clear();
    this.router.navigateByUrl('login');
  }

  renewToken(tokenApi: TokenApi){
    const headers = new HttpHeaders().set('X-Skip-Interceptor', 'true');
    return this.httpClient.post<any>(`${environment.apiUrl}refreshtoken`, tokenApi,{ headers });
  }

  setRefreshToken(tokenValue: string){
    localStorage.setItem('healink-refresh-token', tokenValue);
  }

  getRefreshToken(){
    return localStorage.getItem('healink-refresh-token');
  }
}
