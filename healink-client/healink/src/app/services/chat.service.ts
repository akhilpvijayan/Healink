import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(
    private httpClient: HttpClient) { }

    getAllChats(skip: number, take: number, userId: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}chats/`+userId);
    }

    getAllMessages(skip: number, take: number, chatId: number, userId: number) {
      return this.httpClient.get<any[]>(`${environment.apiUrl}messages/${chatId}/${userId}?skip=${skip}&take=${take}`);
    }
}
