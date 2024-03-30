import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddPostDialogComponent } from './add-post-dialog/add-post-dialog.component';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss']
})
export class AddPostComponent implements OnInit{

  constructor(
    private dialog: MatDialog){}

  ngOnInit(): void {
  }

  addPost(){
    this.dialog.open(AddPostDialogComponent,{
      width:'600px',
      height:'90%',
      hasBackdrop: true,
      panelClass: 'custom-dialog-container'
    });
  }
}
