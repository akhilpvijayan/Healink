import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  constructor(
    private httpClient: HttpClient) { }

    getAllPosts(skip: number, take: number, userId: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}posts/all/${userId}?skip=${skip}&take=${take}`);
    }

    getPosts(skip: number, take: number, userId: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}posts/${userId}?skip=${skip}&take=${take}`);
    }

    getPost(postId: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}post/${postId}`);
    }

    addPost(data: any){
      return this.httpClient.post<any>(`${environment.apiUrl}post/`, data);
    }

    updatePost(data: any){
      return this.httpClient.put<any>(`${environment.apiUrl}post/`, data);
    }

    deletePost(postId: number){
      return this.httpClient.delete<any>(`${environment.apiUrl}post/${postId}`);
    }

    getComments(skip: number, take: number, postId: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}comments/${postId}?skip=${skip}&take=${take}`);
    }
}
