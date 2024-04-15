import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  constructor(
    private httpClient: HttpClient) { }

    getAllPosts() {
      return this.httpClient.get<any>(`${environment.apiUrl}posts/`);
    }

    getPosts(userId: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}posts/${userId}`);
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
}
