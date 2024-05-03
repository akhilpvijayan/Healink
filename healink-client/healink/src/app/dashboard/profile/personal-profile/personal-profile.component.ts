import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { UserService } from 'src/app/services/user.service';
import { EditProfileDialogComponent } from '../edit-profile-dialog/edit-profile-dialog.component';
import { SignalRService } from 'src/app/shared/signaal-r.service';
import { Enums } from 'src/app/shared/enums';

@Component({
  selector: 'app-personal-profile',
  templateUrl: './personal-profile.component.html',
  styleUrls: ['./personal-profile.component.scss']
})
export class PersonalProfileComponent implements OnInit {
  @Input() userDetail: any;
  loggedInUser: any;
  userDetailClone: any;
  showEditButton: boolean = false;
  showCoverEditButton: boolean = false;
  connectionStatus!: number;
  isAcceptFromMe: boolean = false;
  connection: any;
  constructor(private userService: UserService,
    private dialog: MatDialog,
    private signalRService: SignalRService) { }


  ngOnInit(): void {
    this.loggedInUser = this.userService.getUserId();
    this.userService.getConnectionStatus(this.loggedInUser, this.userDetail.userDetailId).subscribe((res: any)=>{
      this.connectionStatus = res;
    });
    this.signalRService.connectionListner((connection: any) => {
      if(connection.receiverId == this.loggedInUser){
        this.isAcceptFromMe = true //Needs to accept the request
        this.connection = connection;
      }
    });
  }

  formatMonthYear(date: string): string {
    return this.userService.formatMonthYear(date);
  }

  calculateDuration(startDate: string, endDate: string, current: boolean): string {
    return this.userService.calculateDuration(startDate, endDate, current);
  }

  editProfile(editSectionType: number) {
    if (this.userDetail?.userId == this.loggedInUser) {
      let dialogWidth = '600px';
      let dialogHeight = '90%';

      if (editSectionType === 8) {
        dialogWidth = '600px';
        dialogHeight = '47%';
      }
      else if (editSectionType === 9) {
        dialogWidth = '600px';
        dialogHeight = '80%';
      }

      // Configure dialog
      const dialogConfig = new MatDialogConfig();
      dialogConfig.width = dialogWidth;
      dialogConfig.height = dialogHeight;
      dialogConfig.hasBackdrop = true;
      dialogConfig.panelClass = 'custom-dialog-container';
      dialogConfig.enterAnimationDuration = '300ms';
      dialogConfig.exitAnimationDuration = '300ms';
      dialogConfig.data = {
        profileDetails: this.userDetail,
        section: editSectionType
      };

      const dialogRef = this.dialog.open(EditProfileDialogComponent, dialogConfig);

      dialogRef.afterClosed().subscribe(result => {
        if (result) {
        }
      });
    }
  }

  connect(){
    this.signalRService.connectionRequest(this.loggedInUser, this.userDetail?.userDetailId, false, null);
    this.connectionStatus = Enums.ConnectionRequests.Pending;
  }

  updateRequest(isAccept: boolean){
    if(isAccept){
      this.connection.status = Enums.ConnectionRequests.Accept //Accepted the request
      this.signalRService.connectionRequest(this.loggedInUser, this.userDetail?.userDetailId, true, this.connection);
    }
    else{
      this.connection.status = Enums.ConnectionRequests.NotConnected //Rejected the request
      this.signalRService.connectionRequest(this.loggedInUser, this.userDetail?.userDetailId, true, this.connection);
    }
  }
}

