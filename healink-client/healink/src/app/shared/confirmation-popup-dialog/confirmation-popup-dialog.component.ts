import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirmation-popup-dialog',
  templateUrl: './confirmation-popup-dialog.component.html',
  styleUrls: ['./confirmation-popup-dialog.component.scss']
})
export class ConfirmationPopupDialogComponent implements OnInit{

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<ConfirmationPopupDialogComponent>){}

  ngOnInit(): void {
    console.log(this.data.message);
  }

  closeDialog(isConfirm: boolean){
    this.dialogRef.close(isConfirm);
  }
}
