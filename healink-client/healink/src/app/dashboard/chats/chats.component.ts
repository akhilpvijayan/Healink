import { AfterViewInit, Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UsersDialogComponent } from './users-dialog/users-dialog.component';
import { ChatService } from 'src/app/services/chat.service';
import { UserService } from 'src/app/services/user.service';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { SignalRService } from 'src/app/shared/signaal-r.service';
import { ToastrService } from 'ngx-toastr';
import { ChatDetailsComponent } from './chat-details/chat-details.component';

@Component({
  selector: 'app-chats',
  templateUrl: './chats.component.html',
  styleUrls: ['./chats.component.scss']
})
export class ChatsComponent implements OnInit{
  showDetails = false;
  chats: any = [];
  targetUser: any;
  chatId: any;
  userId: any;
  skip = 0;
  take = 10;

  constructor(private dialog: MatDialog,
    private chatService: ChatService,
    private userService: UserService,
    private imgConverter: ImageConversionService,
    private signalRService: SignalRService,
    private toastr: ToastrService){}

  ngOnInit(): void {
    this.userId = this.userService.getUserId();
    this.getAllChats();
    this.signalRService.addReceiveMessageListener((user: number, message: string, targetUser: number) => {
      this.chats.forEach((item: any, index: number) => {
        if ((item.receiverId === user && item.senderId == targetUser) || (item.receiverId === targetUser && item.senderId == user)) {
            item.messageContent = message;
            item.isRead= false;
            //Moving it to top of list
            const editedArray = this.chats.splice(index, 1)[0];
            this.chats.unshift(editedArray);
            if(targetUser === this.userId && this.targetUser !== user){
              this.toastr.success(item.firstName + item.lastName +" send you a message.");
            }
        }
    });    
    });
    
  }

  getAllChats(){
    this.chatService.getAllChats(this.skip, this.take, this.userService.getUserId()).subscribe((res: any)=>{
      if(res){
        const promises = res.map((user: any) => {
          const imageConversionPromise = user.profileImage != null ? 
            this.imgConverter.convertImageToDataURL(user.profileImage).then((dataUrl: any) => {
              user.profileImage = dataUrl;
            }) : Promise.resolve();
  
          const isSentByMePromise = user.senderId == this.userId ? user.sentByMe = true : Promise.resolve();
          return Promise.all([imageConversionPromise, isSentByMePromise]);
        });
  
        Promise.all(promises)
          .then(() => {
            this.chats = res;
          })
          .catch(error => {
            console.error('Error converting images:', error);
          });
      }
      else{
        //this.spinner.hide();
      }
    });
  }

  toggleChatDetails(receiverId: number, chatId: number) {
    this.targetUser = receiverId;
    this.chatId = chatId;
    this.showDetails = !this.showDetails;
  }

  receiveValue(value: boolean) {
    if(value){
      this.showDetails = false;
      this.targetUser = null;
      this.chatId = null;
      this.ngOnInit();
    }
  }

  startMessage(){
    const dialogRef = this.dialog.open(UsersDialogComponent,{
      width:'800px',
      height:'90%',
      hasBackdrop: true,
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
      panelClass: 'custom-dialog-container'
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.targetUser = result;
        this.showDetails = !this.showDetails;
      }
    });
  }
}
