import { Component, ElementRef, HostListener, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { PostService } from 'src/app/services/post.service';
import { ReloadService } from 'src/app/services/reload.service';
import { ConfirmationPopupDialogComponent } from 'src/app/shared/confirmation-popup-dialog/confirmation-popup-dialog.component';
import { AddPostDialogComponent } from './add-post/add-post-dialog/add-post-dialog.component';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent implements OnInit, OnDestroy {

  postDetails: any = [];

  private reloadSubscription: Subscription;
  constructor(private postService: PostService,
    private reloadService: ReloadService,
    private imgConverter: ImageConversionService,
    private dialog: MatDialog,
    private toastr: ToastrService) {
    this.reloadSubscription = this.reloadService.getReloadObservable()
      .subscribe((componentName: string) => {
        if (componentName === 'app-post-list') {
          this.ngOnInit();
        }
      });
  }

  ngOnInit(): void {
    this.postService.getAllPosts().subscribe((res: any) => {
      const promises = res.map((post: any) => {
        if (post.contentImage != null) {
          return this.imgConverter.convertImageToDataURL(post.contentImage).then((dataUrl: any) => {
            post.contentImage = dataUrl;
          });
        }
        return true;
      });

      Promise.all(promises)
        .then(() => {
          // All FileReader operations completed and setting postdetails
          this.postDetails = res;
        })
        .catch(error => {
          console.error('Error converting images:', error);
        });
    });

  }

  updatePost(postId: number) {
    this.dialog.open(AddPostDialogComponent, { 
      width: '600px', 
      height: '90%', 
      hasBackdrop: true, 
      panelClass: 'custom-dialog-container' ,
      data: {
        postDetails: this.postDetails.find((post: any) => post.postId === postId)
      }
    });
  }

  deletePost(postId: number) {
    const dialogRef = this.dialog.open(ConfirmationPopupDialogComponent, {
      width: '600px',
      height: '170px',
      hasBackdrop: true,
      panelClass: 'custom-dialog-container',
      data: {
        message: 'Are you sure want to Delete this post?.'
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.postService.deletePost(postId).subscribe((res: any)=>{
          if(res){
            this.ngOnInit()
            this.toastr.success("Post deleted successfully");
          }
          else{
            this.toastr.error("Unexpected error on deleting post");
          }
        })
      }
    });
  }

  ngOnDestroy(): void {
    this.reloadSubscription.unsubscribe();
  }
}
