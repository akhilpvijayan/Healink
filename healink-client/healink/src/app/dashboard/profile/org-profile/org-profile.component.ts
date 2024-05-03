import { Component, Input } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { UserService } from 'src/app/services/user.service';
import { EditProfileDialogComponent } from '../edit-profile-dialog/edit-profile-dialog.component';

@Component({
  selector: 'app-org-profile',
  templateUrl: './org-profile.component.html',
  styleUrls: ['./org-profile.component.scss'],
})
export class OrgProfileComponent {
  @Input() userDetail: any;
  loggedInUser: any;
  userDetailClone: any;
  showEditButton: boolean = false;
  showCoverEditButton: boolean = false;
  constructor(private userService: UserService,
    private dialog: MatDialog) { }


  ngOnInit(): void {
    this.loggedInUser = this.userService.getUserId();
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
}
