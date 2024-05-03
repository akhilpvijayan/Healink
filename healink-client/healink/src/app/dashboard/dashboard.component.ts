import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { AuthService } from '../Auth/auth.service';
import { UserService } from '../services/user.service';
import { FormGroup } from '@angular/forms';
import { ImageConversionService } from '../services/image-conversion.service';
import { Enums } from '../shared/enums';
import { SignalRService } from '../shared/signaal-r.service';
import { PostListComponent } from './post-list/post-list.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit{
userId: any;
userDetail: any = [];
@ViewChild('middlebox') middleboxRef!: ElementRef;
@ViewChild(PostListComponent) postListComponent!: PostListComponent;

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

  ngAfterViewInit(): void {
    // Add scroll event listener to the middlebox element
    this.middleboxRef.nativeElement.addEventListener('scroll', this.onScroll);
  }

  ngOnDestroy(): void {
    // Remove scroll event listener when the component is destroyed
    this.middleboxRef.nativeElement.removeEventListener('scroll', this.onScroll);
  }

  onScroll = (): void => {
    const middlebox = this.middleboxRef.nativeElement;
    const scrollPosition = middlebox.scrollTop + middlebox.clientHeight;
    const scrollHeight = middlebox.scrollHeight;

    if (scrollPosition >= scrollHeight - 100) {
      this.postListComponent.onWindowScroll();
    }
  };
}
