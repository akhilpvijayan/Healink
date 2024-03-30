import { Component, OnInit } from '@angular/core';
import { AuthService } from '../Auth/auth.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit{
userId: any;
userDetail: any = [];
constructor(private authService: AuthService, public userService: UserService){}

  ngOnInit(): void {
    this.userId = this.userService.getUserId();
    this.userService.getUserDetail(this.userId).subscribe((res: any)=>{
      this.userDetail;
    });
  }

  signOut(){
    this.authService.signOut();
  }

}
