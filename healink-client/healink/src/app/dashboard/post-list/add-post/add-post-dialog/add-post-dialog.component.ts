import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { PostService } from 'src/app/services/post.service';
import { ReloadService } from 'src/app/services/reload.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-post-dialog',
  templateUrl: './add-post-dialog.component.html',
  styleUrls: ['./add-post-dialog.component.scss']
})
export class AddPostDialogComponent implements OnInit {
  addPostForm!: FormGroup;
  defaultHeight: number = 300;
  selectedFile: any;
  imageUrl: string | ArrayBuffer | null = null;
  formData = new FormData();
  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private postService: PostService,
    private toastr: ToastrService,
    private dialogRef: MatDialogRef<AddPostDialogComponent>,
    private reloadService: ReloadService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private imgConverter: ImageConversionService) { }

  ngOnInit(): void {
    this.initializeForm();
    this.selectedFile = this.data?.postDetails.contentImage ?? this.data.postDetails.contentImage;
    this.imageUrl = this.data?.postDetails?.contentImage ?? this.imgConverter.convertImageToDataURL(this.data.postDetails.contentImage)
  }

  initializeForm() {
    this.addPostForm = this.formBuilder.group({
      content: [this.data?.postDetails?.content ?? '', Validators.required],
      userId: this.userService.getUserId()
    });
  }

  onFileSelected(target: any) {
    const file = target.files[0];
    if (file) {
      this.selectedFile = target?.files[0];
      const reader = new FileReader();
      reader.onload = (e) => {
        this.imageUrl = e.target?.result ?? null;
      };
      reader.readAsDataURL(file);
    }
  }

  saveFileInfo(){
    const formData : FormData =new FormData();
    formData.append('content', this.addPostForm.value.content);
    formData.append('contentImage', this.selectedFile);
    formData.append('userId', this.addPostForm.value.userId);
    if(this.data?.postDetails?.postId != null){
      formData.append('postId', this.data.postDetails.postId);
    };
    return formData;
  }


  adjustTextareaHeight(event: Event) {
    const textarea = event.target as HTMLTextAreaElement;
    textarea.style.height = 'auto'; // Reset height to auto to properly calculate scroll height
    const newHeight = Math.max(textarea.scrollHeight, this.defaultHeight); // Ensure the new height is at least the default height
    textarea.style.height = newHeight + 'px'; // Set the new height
  }

  onSubmit() {
    if (this.addPostForm.valid) {
      if(this.data?.postDetails?.postId != null){
        this.postService.updatePost(this.saveFileInfo()).subscribe((res: any) => {
          if (res) {
            this.toastr.warning("Post updated successfully");
            this.closeDialog();
            this.triggerReload();
          }
        })
      }
      else{
        this.postService.addPost(this.saveFileInfo()).subscribe((res: any) => {
          if (res) {
            this.toastr.success("New post created successfully");
            this.closeDialog();
            this.triggerReload();
          }
        });
      }
    }
  }

  closeDialog(){
    this.dialogRef.close();
  }

  triggerReload(): void {
    this.reloadService.reloadComponent('app-post-list');
  }

  isString(value: any): boolean {
    return typeof value === 'string';
  }
}
