import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthService } from '../Auth/auth.service';
import { UserService } from '../services/user.service';
import { FormGroup } from '@angular/forms';
import { ImageConversionService } from '../services/image-conversion.service';
import { Enums } from '../shared/enums';
import { SignalRService } from '../shared/signaal-r.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit{
userId: any;
userDetail: any = [];
constructor(private authService: AuthService,
   public userService: UserService,
   private imgConverter: ImageConversionService,
   private signalRService: SignalRService){}

  ngOnInit(): void {
    this.userId = this.userService.getUserId();
    this.signalRService.startConnection();
    this.userService.getUserDetail(this.userId).subscribe((res: any)=>{
      this.userDetail = res;
      if(this.userDetail?.profileImage != null && this.userDetail.RoleId != Enums.Role.OrganizationalUser){
        this.imgConverter.convertImageToDataURL(this.userDetail.profileImage).then((profileImageUrl: any) => {
          this.userDetail.profileImage = profileImageUrl;
        });
      }
      else{
        this.imgConverter.convertImageToDataURL(this.userDetail.organizationLogo).then((profileImageUrl: any) => {
          this.userDetail.organizationLogo = profileImageUrl;
        });
      }
    });
  }
}
