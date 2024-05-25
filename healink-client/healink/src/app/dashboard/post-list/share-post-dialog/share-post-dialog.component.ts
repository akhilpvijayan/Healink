import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-share-post-dialog',
  templateUrl: './share-post-dialog.component.html',
  styleUrls: ['./share-post-dialog.component.scss']
})
export class SharePostDialogComponent implements OnInit{
  isPopupVisible = false;
  shareLink = '';

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<SharePostDialogComponent>,
    private toastr: ToastrService){}

  ngOnInit(): void {
    this.shareLink = environment.clientUrl + 'post?q=' + this.data.postDetails.postId;
  }

  closeDialog(){
    this.dialogRef.close();
  }

  copyToClipboard() {
    const shareLinkInput = document.getElementById('share-link') as HTMLInputElement;
    shareLinkInput.select();
    shareLinkInput.setSelectionRange(0, 99999); // For mobile devices

    document.execCommand('copy');
    this.toastr.success("Link copied to clipboard");
  }
}
