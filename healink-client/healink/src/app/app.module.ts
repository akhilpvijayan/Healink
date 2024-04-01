import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { PostListComponent } from './dashboard/post-list/post-list.component';
import { AddPostComponent } from './dashboard/post-list/add-post/add-post.component';
import { AddPostDialogComponent } from './dashboard/post-list/add-post/add-post-dialog/add-post-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { SideProfileComponent } from './dashboard/side-profile/side-profile.component';
import {MatIconModule} from '@angular/material/icon';
import { ConfirmationPopupDialogComponent } from './shared/confirmation-popup-dialog/confirmation-popup-dialog.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { ProfilePreviewComponent } from './sign-up/personal-user/profile-preview/profile-preview.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { SignUpFormComponent } from './sign-up/personal-user/sign-up-form/sign-up-form.component';
import { ProfileComponent } from './dashboard/profile/profile.component';
import { EditProfileDialogComponent } from './dashboard/profile/edit-profile-dialog/edit-profile-dialog.component';
import { SignUpOptionDialogComponent } from './shared/sign-up-option-dialog/sign-up-option-dialog.component';
import { OrgSignUpFormComponent } from './sign-up/organizational-user/org-sign-up-form/org-sign-up-form.component';
import { OrgProfilePreviewComponent } from './sign-up/organizational-user/org-profile-preview/org-profile-preview.component'; 


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    PostListComponent,
    AddPostComponent,
    AddPostDialogComponent,
    SideProfileComponent,
    ConfirmationPopupDialogComponent,
    SignUpComponent,
    ProfilePreviewComponent,
    SignUpFormComponent,
    ProfileComponent,
    EditProfileDialogComponent,
    SignUpOptionDialogComponent,
    OrgSignUpFormComponent,
    OrgProfilePreviewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right'
    }),
    BrowserAnimationsModule,
    MatDialogModule,
    MatIconModule,
    NgSelectModule 
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
