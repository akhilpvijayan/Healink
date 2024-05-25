import { AfterViewInit, Component, ElementRef, Inject, Input, OnInit, Optional, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { PostService } from 'src/app/services/post.service';
import { UserService } from 'src/app/services/user.service';
import { SignalRService } from 'src/app/shared/signaal-r.service';

@Component({
  selector: 'app-post-comments-dialog',
  templateUrl: './post-comments-dialog.component.html',
  styleUrls: ['./post-comments-dialog.component.scss']
})
export class PostCommentsDialogComponent implements OnInit, AfterViewInit {
  @ViewChild('commentInput') commentInput!: ElementRef;
  @ViewChild('editedContent') editedContent!: ElementRef;
  @Input() postDetails: any | null = null;
  comments: any = [];
  skip = 0;
  take = 10;
  commentContent: string = '';

  constructor(
    private postservice: PostService,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: any = null,
    @Optional() private dialogRef: MatDialogRef<PostCommentsDialogComponent>,
    private signalRService: SignalRService,
    private userService: UserService,
    private imgConverter : ImageConversionService
  ) { }

  ngOnInit(): void {
    this.postservice.getComments(this.skip, this.take, this.data?.postDetails?.postId ?? this.postDetails?.postId).subscribe((res: any) => {
      if(res[0]){
        const promises = res.map((post: any) => {
          const isEditingPromise = post.editing == null ? post.editing = false : Promise.resolve();
      
          const profileLogoConversionPromise = post.profileLogo != null ? 
            this.imgConverter.convertImageToDataURL(post.profileLogo).then((dataUrl: any) => {
              post.profileLogo = dataUrl;
            }) : Promise.resolve();
      
          return Promise.all([isEditingPromise, profileLogoConversionPromise]);
        });
  
        Promise.all(promises)
          .then(() => {
            this.comments = [...this.comments, ...res];
          })
          .catch(error => {
            console.error('Error converting images:', error);
          });
      }
    });

    this.signalRService.addCommentsListener((isDelete: boolean, comment: any, isUpdate: boolean) => {
      if (isDelete) {
        const index = this.comments.findIndex((c: any) => c.commentId === comment.commentId);
        if (index !== -1) {
          this.comments.splice(index, 1);
        }
      }
      else if(isUpdate){
        const index = this.comments.findIndex((c: any) => c.commentId === comment.commentId);
        this.comments[index].content= comment.content;
      }
      else {
        this.comments.push(comment);
      }
    });
  }
  ngAfterViewInit(): void {
    setTimeout(() => {
      this.commentInput.nativeElement.focus();
    }, 400);
  }

  preventDefault(event: Event): void {
    event.preventDefault();
  }

  addComment() {
    this.signalRService.postComment(this.userService.getUserId(), this.data?.postDetails?.postId ?? this.postDetails?.postId, this.data?.postDetails?.userId ?? this.postDetails?.userId, this.commentContent, false, 0);
    this.commentContent = '';
  }

  deleteComment(commentId: number) {
    this.signalRService.postComment(this.userService.getUserId(), this.data?.postDetails?.postId ?? this.postDetails?.postId, this.data?.postDetails?.userId ?? this.postDetails?.userId, this.commentContent, true, commentId);
  }

  editComment(comment: any): void {
    comment.editing = true;
    setTimeout(() => {
      this.editedContent.nativeElement.focus();
    }, 100);
  }

  saveComment(comment: any, updatedContent: string): void {
    comment.content = updatedContent;
    comment.editing = false;
    this.signalRService.postComment(this.userService.getUserId(), this.data?.postDetails?.postId?? this.postDetails?.postId, this.data?.postDetails?.userId ?? this.postDetails?.userId, updatedContent, false, comment.commentId);
  }

  closeDialog(){
    this.dialogRef.close();
  }
}
