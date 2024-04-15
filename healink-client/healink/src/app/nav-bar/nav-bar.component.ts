import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '../Auth/auth.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationPopupDialogComponent } from '../shared/confirmation-popup-dialog/confirmation-popup-dialog.component';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit, OnDestroy{
  private signOutSubscription: Subscription | undefined;
  isLoggedIn = false;
  isNoNotifications = false;
  constructor(private authService: AuthService,
    private router: Router,
    private userService: UserService,
    private dialog: MatDialog) {}

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn() ? true : false;
    this.signOutSubscription = this.authService.signOutObservable$.subscribe(() => {
      // Call your function here
      this.isLoggedIn = this.authService.isLoggedIn() ? true : false;
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
}
