import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-users-dialog',
  templateUrl: './users-dialog.component.html',
  styleUrls: ['./users-dialog.component.scss']
})
export class UsersDialogComponent implements OnInit{
  activeButton: number = 1;
  connectedUsers: any;
  users: any;
  userId: any;
  constructor(private dialogRef: MatDialogRef<UsersDialogComponent>,
    private userService: UserService,
    private imgConverter: ImageConversionService){}

  ngOnInit(): void {
    this.userId = this.userService.getUserId();
    this.userService.getPersonalUsers(this.userId).subscribe((res: any) =>{
      if(res){
        const promises = res.map((user: any) => {
          const imageConversionPromise = user.profileImage != null ? 
            this.imgConverter.convertImageToDataURL(user.profileImage).then((dataUrl: any) => {
              user.profileImage = dataUrl;
            }) : Promise.resolve();
    
          return Promise.all([imageConversionPromise]);
        });
  
        Promise.all(promises)
          .then(() => {
            this.users = res;
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

  toggleActive(buttonNumber: number) {
    this.activeButton = buttonNumber;
  }

  closeDialog(userId: number){
    this.dialogRef.close(userId);
  }
}
