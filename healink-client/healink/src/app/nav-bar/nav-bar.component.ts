import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '../Auth/auth.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationPopupDialogComponent } from '../shared/confirmation-popup-dialog/confirmation-popup-dialog.component';
import { Enums } from '../shared/enums';
import { ImageConversionService } from '../services/image-conversion.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit, OnDestroy{
  private signOutSubscription: Subscription | undefined;
  isLoggedIn = false;
  isNoNotifications = false;
  searchContent: string = '';
  userDetail: any;
  constructor(private authService: AuthService,
    private router: Router,
    private userService: UserService,
    private dialog: MatDialog,
    private imgConverter: ImageConversionService) {}

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn() ? true : false;
    this.signOutSubscription = this.authService.signOutObservable$.subscribe(() => {
      // Call your function here
      this.isLoggedIn = this.authService.isLoggedIn() ? true : false;
    });
    this.userService.getUserDetail(this.userService.getUserId()).subscribe((res: any)=>{
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

  ngOnDestroy(): void {
    this.signOutSubscription?.unsubscribe();
  }

  showHome() {
    this.router.navigate(['home']);
  }

  showProfile() {
    this.router.navigate(['profile'], { queryParams: { userId: this.userService.getUserId() } });
  }

  showNotifications(){
    this.router.navigate(['notifications']);
  }

  showNetwork(){
    this.router.navigate(['network']);
  }

  showMessages(){
    this.router.navigate(['messages']);
  }

  signOut() {
    const dialogRef = this.dialog.open(ConfirmationPopupDialogComponent, {
      width: '600px',
      height: '170px',
      hasBackdrop: true,
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
      panelClass: 'custom-dialog-container',
      data: {
        message: 'Are you sure want to SignOut?.'
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.authService.signOut();
      }
    });
  }

  search(){
    if(this.searchContent){
      this.router.navigate(['search'], { queryParams: { q: this.searchContent } });
    }
  }
}
