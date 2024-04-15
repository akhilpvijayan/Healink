import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(
    private httpClient: HttpClient) { }

    getAllChats(userId: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}chats/`+userId);
    }

    getAllMessages(chatId: number, userId: number) {
      return this.httpClient.get<any>(`${environment.apiUrl}messages/`+chatId+`/`+userId);
    }
}
