import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection!: signalR.HubConnection;

  constructor() { }

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.apiUrl +'chatHub')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public addReceiveMessageListener = (callback: (user: number, message: string, targetUser: number) => void) => {
    this.hubConnection.on('ReceiveMessage', callback);
  }

  public sendMessage = (user: number, message: string, targetUser: number) => {
    this.hubConnection.invoke('SendMessage', user, message, targetUser)
      .catch(err => console.error(err));
  }
}
