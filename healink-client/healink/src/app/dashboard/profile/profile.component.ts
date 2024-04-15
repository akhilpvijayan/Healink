import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { AddPostDialogComponent } from '../post-list/add-post/add-post-dialog/add-post-dialog.component';
import { SignUpComponent } from 'src/app/sign-up/sign-up.component';
import { SignUpFormComponent } from 'src/app/sign-up/personal-user/sign-up-form/sign-up-form.component';
import { EditProfileDialogComponent } from './edit-profile-dialog/edit-profile-dialog.component';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  userDetail: any;
  loggedInUser: any;
  userId: any = null;
  userDetailClone: any;
  showEditButton: boolean = false;
  showCoverEditButton: boolean = false;
  constructor(private userService: UserService,
    private route: ActivatedRoute,
    private dialog: MatDialog,
    private imgConverter: ImageConversionService,
    private spinner: NgxSpinnerService) { }


  ngOnInit(): void {
    this.spinner.show();
    this.loggedInUser = this.userService.getUserId();
    this.route.queryParams.subscribe(params => {
      this.userId = params['userId'];
    });
    //this.userService.getUserId();
    this.getUserDetail();
  }

  getUserDetail() {
    this.userService.getUserDetail(this.userId).subscribe((res: any) => {
      if (res) {
        this.userDetail = res;
        this.userDetailClone = res;
        if (this.userDetail.profileImage != null) {
          this.imgConverter.convertImageToDataURL(this.userDetail.profileImage).then((profileImageUrl: any) => {
            this.userDetail.profileImage = profileImageUrl;
          });
        }
        if (this.userDetail.profileCover != null) {
          this.imgConverter.convertImageToDataURL(this.userDetail.profileCover).then((profileCoverUrl: any) => {
            this.userDetail.profileCover = profileCoverUrl;
          });
        }
        this.spinner.hide();
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
    let dialogWidth = '600px';
    let dialogHeight = '90%';

    // Adjust dimensions based on section type
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
    dialogConfig.enterAnimationDuration= '300ms';
    dialogConfig.exitAnimationDuration = '300ms';
    dialogConfig.data = {
      profileDetails: this.userDetailClone,
      section: editSectionType
    };

    const dialogRef = this.dialog.open(EditProfileDialogComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getUserDetail();
      }
    });
  }

  addEducation() {

  }

  addExperience() {

  }
}
