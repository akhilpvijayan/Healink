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

  public addLikesListener = (callback: (user: number, postId: number, likeCount: number) => void) => {
    this.hubConnection.on('Likes', callback);
  }

  public likePost = (user: number, postId: number, targetUser: number, isRemoveLike: boolean) => {
    this.hubConnection.invoke('LikePost', user, postId, targetUser, isRemoveLike)
      .catch(err => console.error(err));
  }

  public addCommentsListener = (callback: (isDelete: boolean, comment: any, isUpdate: boolean) => void) => {
    this.hubConnection.on('Comments', callback);
  }

  public postComment = (user: number, postId: number, targetUser: number, commentContent: string, isDelete: boolean, commentId: number) => {
    this.hubConnection.invoke('PostComment', user, postId, targetUser, commentContent, isDelete, commentId)
      .catch(err => console.error(err));
  }

  public connectionListner = (callback: (connection: any) => void) => {
    this.hubConnection.on('Connection', callback);
  }

  public connectionRequest = (senderId: number, receiverId: number, isFromTargetUser: boolean, connection: number | null) => {
    this.hubConnection.invoke('ConnectionRequest', senderId, receiverId, isFromTargetUser, connection)
      .catch(err => console.error(err));
  }
}
