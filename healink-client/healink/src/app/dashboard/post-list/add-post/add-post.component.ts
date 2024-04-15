import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddPostDialogComponent } from './add-post-dialog/add-post-dialog.component';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss']
})
export class AddPostComponent implements OnInit{
  @Input() userDetail: any;
  constructor(
    private dialog: MatDialog,
    private router: Router){}

  ngOnInit(): void {
  }

  addPost(){
    this.dialog.open(AddPostDialogComponent,{
      width:'600px',
      height:'90%',
      hasBackdrop: true,
      panelClass: 'custom-dialog-container',
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
    });
  }

  showProfile() {
    this.router.navigate(['profile'], { queryParams: { userId: this.userDetail.userId } });
  }
}
