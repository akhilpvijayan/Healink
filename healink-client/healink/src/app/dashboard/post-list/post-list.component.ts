import { Component, ElementRef, HostListener, Input, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { PostService } from 'src/app/services/post.service';
import { ReloadService } from 'src/app/services/reload.service';
import { ConfirmationPopupDialogComponent } from 'src/app/shared/confirmation-popup-dialog/confirmation-popup-dialog.component';
import { AddPostDialogComponent } from './add-post/add-post-dialog/add-post-dialog.component';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent implements OnInit, OnDestroy {
  @Input() userDetail: any;
  postDetails: any = [];
  userId: any;

  private reloadSubscription: Subscription;
  constructor(private postService: PostService,
    private reloadService: ReloadService,
    private imgConverter: ImageConversionService,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    private spinner: NgxSpinnerService) {
    this.reloadSubscription = this.reloadService.getReloadObservable()
      .subscribe((componentName: string) => {
        if (componentName === 'app-post-list') {
          this.ngOnInit();
        }
      });
  }

  ngOnInit(): void {
    this.spinner.show();
    this.route.queryParams.subscribe(params => {
      this.userId =  params['q'];
    });
    if(this.userId){
      this.postService.getPosts(this.userId).subscribe((res: any) => {
        if(res[0]){
          const promises = res.map((post: any) => {
            const imageConversionPromise = post.contentImage != null ? 
              this.imgConverter.convertImageToDataURL(post.contentImage).then((dataUrl: any) => {
                post.contentImage = dataUrl;
              }) : Promise.resolve();
        
            const profileLogoConversionPromise = post.profileLogo != null ? 
              this.imgConverter.convertImageToDataURL(post.profileLogo).then((dataUrl: any) => {
                post.profileLogo = dataUrl;
              }) : Promise.resolve();
        
            return Promise.all([imageConversionPromise, profileLogoConversionPromise]);
          });
    
          Promise.all(promises)
            .then(() => {
              // All FileReader operations completed and setting postdetails
              this.postDetails = res;
              this.spinner.hide();
            })
            .catch(error => {
              console.error('Error converting images:', error);
              this.spinner.hide();
            });
        }
        else{
          this.toastr.warning("No posts found");
          this.spinner.hide();
        }
      });
    }
    else{
      this.postService.getAllPosts().subscribe((res: any) => {
        if(res[0]){
        const promises = res.map((post: any) => {
          const imageConversionPromise = post.contentImage != null ? 
            this.imgConverter.convertImageToDataURL(post.contentImage).then((dataUrl: any) => {
              post.contentImage = dataUrl;
            }) : Promise.resolve();
      
          const profileLogoConversionPromise = post.profileLogo != null ? 
            this.imgConverter.convertImageToDataURL(post.profileLogo).then((dataUrl: any) => {
              post.profileLogo = dataUrl;
            }) : Promise.resolve();
      
          return Promise.all([imageConversionPromise, profileLogoConversionPromise]);
        });
  
        Promise.all(promises)
          .then(() => {
            // All FileReader operations completed and setting postdetails
            this.postDetails = res;
            this.spinner.hide();
          })
          .catch(error => {
            console.error('Error converting images:', error);
            this.spinner.hide();
          });
        }
        else{
          this.toastr.warning("No posts found");
          this.spinner.hide();
        }
      });
    }

  }

  updatePost(postId: number) {
    this.dialog.open(AddPostDialogComponent, { 
      width: '600px', 
      height: '90%', 
      hasBackdrop: true, 
      panelClass: 'custom-dialog-container' ,
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
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
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
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

  showProfile(userId: number) {
    this.router.navigate(['profile'], { queryParams: { userId: userId } });
  }
}
