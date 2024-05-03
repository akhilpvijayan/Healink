import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(
    private httpClient: HttpClient) { }

    getTopPersonalUsersInSearch(query : string, skip: number, take: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}search/users/`+query+`?skip=${skip}&take=${take}`);
    }

    getAllPersonalUsersInSearch(query : string, skip: number, take: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}search/users/all/`+query+`?skip=${skip}&take=${take}`);
    }

    getTopOrganizationalUsersInSearch(query : string, skip: number, take: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}search/orgs/`+query+`?skip=${skip}&take=${take}`);
    }

    getAllOrganizationalUsersInSearch(query : string, skip: number, take: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}search/orgs/all/`+query+`?skip=${skip}&take=${take}`);
    }

    getAllPostsInSearch(query : string, skip: number, take: number, userId: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}search/posts/`+query+`?skip=${skip}&take=${take}&userId=${userId}`);
    }
}
