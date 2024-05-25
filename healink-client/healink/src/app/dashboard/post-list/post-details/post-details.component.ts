import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AddPostDialogComponent } from '../add-post/add-post-dialog/add-post-dialog.component';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from 'src/app/services/user.service';
import { ConfirmationPopupDialogComponent } from 'src/app/shared/confirmation-popup-dialog/confirmation-popup-dialog.component';
import { PostService } from 'src/app/services/post.service';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { SignalRService } from 'src/app/shared/signaal-r.service';
import { PostCommentsDialogComponent } from '../post-comments-dialog/post-comments-dialog.component';
import { SharePostDialogComponent } from '../share-post-dialog/share-post-dialog.component';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.scss']
})
export class PostDetailsComponent implements OnInit{
  post: any;
  loggedInUser: any;

  constructor(private router: Router,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private userService: UserService,
    private postService: PostService,
    private imgConverter: ImageConversionService,
    private signalRService: SignalRService
  ) {
    const navigation = this.router.getCurrentNavigation();
    this.post = navigation?.extras?.state?.['post'];
  }

  ngOnInit(): void {
    this.loggedInUser = this.userService.getUserId();
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
        postDetails: this.post
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
            this.router.navigateByUrl('posts')
            this.toastr.success("Post deleted successfully");
          }
          else{
            this.toastr.error("Unexpected error on deleting post");
          }
        })
      }
    });
  }

  showProfile(userId: number) {
    this.router.navigate(['profile'], { queryParams: { userId: userId } });
  }

  loadUpdatedPost(postId: any){
    this.postService.getPost(postId.key).subscribe((res: any)=>{
      if(res[0]){
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
        this.post = res[0];
      }
    });
  }

  addLike(postId: number){
    const post = this.post;
    if (post) {
      this.signalRService.likePost(this.userService.getUserId(), post.postId, post.userId, post.isLikedByMe? true: false);
      post.likeCount += (post.isLikedByMe ? -1 : 1);
      post.isLikedByMe = !post.isLikedByMe;
    }
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
        postDetails: this.post
      }
    });
  }
}
