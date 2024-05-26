import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AddPostDialogComponent } from 'src/app/dashboard/post-list/add-post/add-post-dialog/add-post-dialog.component';
import { PostCommentsDialogComponent } from 'src/app/dashboard/post-list/post-comments-dialog/post-comments-dialog.component';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { PostService } from 'src/app/services/post.service';
import { SearchService } from 'src/app/services/search.service';
import { UserService } from 'src/app/services/user.service';
import { ConfirmationPopupDialogComponent } from 'src/app/shared/confirmation-popup-dialog/confirmation-popup-dialog.component';
import { SignalRService } from 'src/app/shared/signaal-r.service';

@Component({
  selector: 'app-search-posts',
  templateUrl: './search-posts.component.html',
  styleUrls: ['./search-posts.component.scss']
})
export class SearchPostsComponent implements OnInit{
  @Input() searchQuery : any;
  userId: any;
  skip = 0;
  take = 10;
  posts: any;
  
  constructor(private searchService: SearchService,
    private imgConverter: ImageConversionService,
    private userService: UserService,
    private dialog: MatDialog,
    private toastr: ToastrService,
    private postService: PostService,
    private signalRService: SignalRService,
    private router: Router
  ){}

  ngOnInit(): void {
    this.userId = this.userService.getUserId();
    this.getPosts();
  }

  getPosts(){
    this.searchService.getAllPostsInSearch(this.searchQuery, this.skip, this.take, this.userId).subscribe((res: any)=>{
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
            this.posts = res;
          })
          .catch(error => {
            console.error('Error converting images:', error);
          });
      }
    });
  }

  onWindowScroll() {
    this.skip += this.take;
    this.getPosts();
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
          postDetails: this.posts.find((post: any) => post.postId === postId)
        }
      });
    }
  
    deletePost(postId: number) {
      const dialogRef = this.dialog.open(ConfirmationPopupDialogComponent, {
        width: 'auto',
        height: 'auto',
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
              const indexToRemove = this.posts.findIndex((item: any) => item.postId === postId);
              if (indexToRemove !== -1) {
                this.posts.splice(indexToRemove, 1);
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

    addLike(postId: number){
      const post = this.posts.find((post: any) => post.postId === postId)
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
          postDetails: this.posts.find((post: any) => post.postId === postId)
        }
      });
    }

    showProfile(userId: number) {
      this.router.navigate(['profile'], { queryParams: { userId: userId } });
    }
}
