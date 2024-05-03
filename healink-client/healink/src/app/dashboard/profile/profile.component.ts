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
  constructor(private userService: UserService,
    private route: ActivatedRoute,
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
    this.userService.getUserDetail(this.userId).subscribe(async (res: any) => {
      if (res) {
        this.userDetail = res;
        this.userDetailClone = res;
        if (this.userDetail?.experience) {
          for (const experienceItem of this.userDetail.experience) {
            if (experienceItem?.companyLogo) {
              try {
                const dataUrl = await this.imgConverter.convertImageToDataURL(experienceItem.companyLogo);
                experienceItem.companyLogo = dataUrl;
              } catch (error) {
                console.error('Error converting image to data URL:', error);
              }
            }
          }
        }
        if (this.userDetail?.education) {
          for (const experienceItem of this.userDetail.education) {
            if (experienceItem?.orgLogo) {
              try {
                const dataUrl = await this.imgConverter.convertImageToDataURL(experienceItem.orgLogo);
                experienceItem.orgLogo = dataUrl;
              } catch (error) {
                console.error('Error converting image to data URL:', error);
              }
            }
          }
        }
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
        if (this.userDetail.organizationLogo != null) {
          this.imgConverter.convertImageToDataURL(this.userDetail.organizationLogo).then((profileImageUrl: any) => {
            this.userDetail.organizationLogo = profileImageUrl;
          });
        }
        if (this.userDetail.organizationCover != null) {
          this.imgConverter.convertImageToDataURL(this.userDetail.organizationCover).then((profileImageUrl: any) => {
            this.userDetail.organizationCover = profileImageUrl;
          });
        }
        this.spinner.hide();
      }
    });
  }
}
