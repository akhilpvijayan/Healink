import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-sign-up-option-dialog',
  templateUrl: './sign-up-option-dialog.component.html',
  styleUrls: ['./sign-up-option-dialog.component.scss']
})
export class SignUpOptionDialogComponent {

  constructor(private dialogRef: MatDialogRef<SignUpOptionDialogComponent>){}

  closeDialog(userType: number){
    this.dialogRef.close(userType);
  }
}
