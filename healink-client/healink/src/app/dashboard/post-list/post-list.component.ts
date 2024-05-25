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
import { UserService } from 'src/app/services/user.service';
import { SignalRService } from 'src/app/shared/signaal-r.service';
import { PostCommentsDialogComponent } from './post-comments-dialog/post-comments-dialog.component';
import { SharePostDialogComponent } from './share-post-dialog/share-post-dialog.component';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent implements OnInit, OnDestroy {
  @Input() userDetail: any;
  postDetails: any = [];
  userId: any;
  skip = 0;
  take = 6;
  loading = false;
  loggedInUser: any;

  private reloadSubscription: Subscription;
  constructor(private postService: PostService,
    private reloadService: ReloadService,
    private imgConverter: ImageConversionService,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private userService: UserService,
    private signalRService: SignalRService) {
    this.reloadSubscription = this.reloadService.getReloadObservable()
      .subscribe(reloadData => {
        if (reloadData.componentName === 'app-post-list') {
          this.skip = 0;
          this.postDetails = [];
          this.loadPosts();
        }
        if (reloadData.componentName === 'app-post-list-update') {
          this.loadUpdatedPost(reloadData.data);
        }
      });
  }

  ngOnInit(): void {
    this.spinner.show();
    this.loggedInUser = this.userService.getUserId();
    this.route?.queryParams?.subscribe(params => {
      this.userId =  params['q'];
    });
    this.loadPosts();
    this.signalRService.addLikesListener((user: number, postId: number, likecount: number) => {
      const post = this.postDetails.find((post: any) => post.postId === postId)
      if (post) {
        post.likeCount = likecount;
      }
    });
  }

  loadPosts(){
    if(this.userId){
      this.postService.getPosts(this.skip, this.take,this.userId).subscribe((res: any) => {
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
              this.postDetails = [...this.postDetails, ...res];
              this.loading = false;
              this.spinner.hide();
            })
            .catch(error => {
              console.error('Error converting images:', error);
              this.spinner.hide();
            });
        }
        else{
          if(this.postDetails == null){
            this.toastr.warning("No posts found");
          }
          this.spinner.hide();
        }
      });
    }
    else{
      this.postService.getAllPosts(this.skip, this.take, this.userService.getUserId()).subscribe((res: any) => {
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
            this.postDetails = [...this.postDetails, ...res];
            this.loading = false;
            this.spinner.hide();
          })
          .catch(error => {
            console.error('Error converting images:', error);
            this.spinner.hide();
          });
        }
        else{
          if(this.postDetails == null){
            this.toastr.warning("No posts found");
          }
          this.spinner.hide();
        }
      });
    }
  }

// Detect scroll event and load more posts when the user reaches the bottom
onWindowScroll() {
  this.skip += this.take;
  this.loadPosts();
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
            const indexToRemove = this.postDetails.findIndex((item: any) => item.postId === postId);
            if (indexToRemove !== -1) {
              this.postDetails.splice(indexToRemove, 1);
            }
            
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

  loadUpdatedPost(postId: any){
    this.postService.getPost(postId.key).subscribe((res: any)=>{
      if(res[0]){
        const indexToUpdate = this.postDetails.findIndex((item: any) => item.postId === postId.key);
        if (indexToUpdate !== -1) {
          if(res[0].contentImage != null){
            this.imgConverter.convertImageToDataURL(res[0].contentImage).then((dataUrl: any) => {
              res[0].contentImage = dataUrl;
            });
          }
          if(res[0].profileLogo != null){
            this.imgConverter.convertImageToDataURL(res[0].profileLogo).then((dataUrl: any) => {
              res[0].profileLogo = dataUrl;
            })
          }
          this.postDetails[indexToUpdate] = res[0];
        }
      }
    });
  }

  addLike(postId: number){
    const post = this.postDetails.find((post: any) => post.postId === postId)
    if (post) {
      this.signalRService.likePost(this.userService.getUserId(), post.postId, post.userId, post.isLikedByMe? true: false);
      post.likeCount += (post.isLikedByMe ? -1 : 1);
      post.isLikedByMe = !post.isLikedByMe;
    }
  }

  addComment(postId: number){
    this.dialog.open(PostCommentsDialogComponent,{
      width:'600px',
      height:'98%',
      hasBackdrop: true,
      panelClass: 'custom-dialog-container',
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
      data: {
        postDetails: this.postDetails.find((post: any) => post.postId === postId)
      }
    });
  }

  sharePost(postId: number){
    this.dialog.open(SharePostDialogComponent,{
      width:'auto',
      height:'auto',
      hasBackdrop: true,
      panelClass: 'custom-dialog-container',
      enterAnimationDuration: '300ms',
      exitAnimationDuration: '300ms',
      data: {
        postDetails: this.postDetails.find((post: any) => post.postId === postId)
      }
    });
  }

  showPostDetails(post: any){
    this.router.navigate(['post'], { queryParams: { q: post.postId } , state: { post }});
  }
}
