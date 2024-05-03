import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Message } from 'src/app/models/message';
import { ChatService } from 'src/app/services/chat.service';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { UserService } from 'src/app/services/user.service';
import { SignalRService } from 'src/app/shared/signaal-r.service';

@Component({
  selector: 'app-chat-details',
  templateUrl: './chat-details.component.html',
  styleUrls: ['./chat-details.component.scss']
})
export class ChatDetailsComponent implements OnInit {
  @ViewChild('messageArea') messageArea!: ElementRef;
  @ViewChild(ChatDetailsComponent) chatsDetailsComponent!: ChatDetailsComponent;
  @Output() isReturn = new EventEmitter<boolean>();
  @Input() targetUser: any;
  @Input() chatId: any;
  messageText: string = '';
  messages: Message[] = [];
  userId: any;
  userDetails: any;
  skip = 0;
  take = 10;

  constructor(private signalRService: SignalRService,
    private userService: UserService,
    private chatService: ChatService,
    private imgConverter: ImageConversionService) { }

  ngOnInit(): void {
    this.userId = this.userService.getUserId();
    this.signalRService.addReceiveMessageListener((user: number, message: string, targetUser: number) => {
      if (this.userId == targetUser && this.targetUser == user) {
        this.messages.push({ messageContent: message, sentByMe: false, isRead: true });
        setTimeout(() => {
          this.scrollToBottom();
        }, 100);
      }
    });
    if (this.chatId != null) {
      this.setMessages(false);
    }
    else {
      this.userService.isChatExist(this.userId, this.targetUser).subscribe((res: any) => {
        if (res > 0) {
          this.chatId = res;
        }
        this.setMessages(false);
      })
    }
  }

  setMessages(isOnScroll: boolean) {
    if (this.chatId != null) {
      this.chatService.getAllMessages(this.skip, this.take, this.chatId, this.userId).subscribe((res: any) => {
        if (res) {
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
              this.messages = [...res, ...this.messages];
              if(!isOnScroll){
                setTimeout(() => {
                  this.scrollToBottom();
                }, 100);
              }
            })
            .catch(error => {
              console.error('Error converting images:', error);
            });
        }
        else {
          //this.spinner.hide();
        }
      });
    }
    else {
      this.userService.getUserDetail(this.targetUser).subscribe((res: any) => {
        if (res) {
          if (res.profileImage != null) {
            this.imgConverter.convertImageToDataURL(res.profileImage).then((dataUrl: any) => {
              res.profileImage = dataUrl;
            });
          }
          this.userDetails = res;
        }
      });
    }
  }

  sendMessage() {
    if (this.messageText.trim() !== '') {
      this.signalRService.sendMessage(this.userService.getUserId(), this.messageText, this.targetUser);
      this.messages.push({ messageContent: this.messageText, sentByMe: true, isRead: true });
      this.messageText = '';
      setTimeout(() => {
        this.scrollToBottom();
      }, 100);
    }
  }

  scrollToBottom() {
    try {
      this.messageArea.nativeElement.scrollTop = this.messageArea.nativeElement.scrollHeight + 3;
    } catch (err) { }
  }

  goBack() {
    this.isReturn.emit(true);
  }

  onWindowScroll() {
    this.skip += this.take;
    this.setMessages(true);
    }
  
    ngAfterViewInit(): void {
      // Add scroll event listener to the middlebox element
      this.messageArea.nativeElement.addEventListener('scroll', this.onScroll);
    }
    
    ngOnDestroy(): void {
      // Remove scroll event listener when the component is destroyed
      this.messageArea.nativeElement.removeEventListener('scroll', this.onScroll);
    }
    
    onScroll = (): void => {
      const middlebox = this.messageArea.nativeElement;
      const scrollPosition = middlebox.scrollTop;
      
      if (scrollPosition === 0) {
        this.onWindowScroll();
      }
    };
}
