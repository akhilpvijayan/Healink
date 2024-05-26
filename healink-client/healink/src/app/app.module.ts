import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { UserPostsComponent } from './dashboard/profile/user-posts/user-posts.component';
import { NavBarComponent } from './nav-bar/nav-bar.component'; 
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import {MatBadgeModule} from '@angular/material/badge';
import { NetworkComponent } from './dashboard/network/network.component';
import { NotificationsComponent } from './dashboard/notifications/notifications.component';
import {MatListModule} from '@angular/material/list';
import {MatCardModule} from '@angular/material/card';
import { NetworksListComponent } from './dashboard/network/networks-list/networks-list.component';
import { NetworkSideBarComponent } from './dashboard/network/network-side-bar/network-side-bar.component';
import { InvitationsComponent } from './dashboard/network/invitations/invitations.component';
import { InvitationsListComponent } from './dashboard/network/invitations-list/invitations-list.component';
import { NetworksComponent } from './dashboard/network/networks/networks.component';
import { CustomLoaderComponent } from './shared/custom-loader/custom-loader.component';
import { NgxSpinnerModule } from "ngx-spinner";
import { ChatsComponent } from './dashboard/chats/chats.component';
import { ChatDetailsComponent } from './dashboard/chats/chat-details/chat-details.component';
import { UsersDialogComponent } from './dashboard/chats/users-dialog/users-dialog.component';
import { MessagesComponent } from './dashboard/messages/messages.component';
import { PostCommentsDialogComponent } from './dashboard/post-list/post-comments-dialog/post-comments-dialog.component';
import { OrgProfileComponent } from './dashboard/profile/org-profile/org-profile.component';
import { PersonalProfileComponent } from './dashboard/profile/personal-profile/personal-profile.component';
import { MatTabsModule } from '@angular/material/tabs';
import { OrgAboutComponent } from './dashboard/profile/org-profile/org-about/org-about.component';
import { OrgPostsComponent } from './dashboard/profile/org-profile/org-posts/org-posts.component';
import { OrgJobsComponent } from './dashboard/profile/org-profile/org-jobs/org-jobs.component';
import { SearchComponent } from './search/search.component';
import { SearchAllComponent } from './search/search-all/search-all.component';
import { SearchPostsComponent } from './search/search-posts/search-posts.component';
import { SearchPersonalUsersComponent } from './search/search-personal-users/search-personal-users.component';
import { SearchOrganizationalUsersComponent } from './search/search-organizational-users/search-organizational-users.component';
import { SharePostDialogComponent } from './dashboard/post-list/share-post-dialog/share-post-dialog.component';
import { PostDetailsComponent } from './dashboard/post-list/post-details/post-details.component';
import { ReloginDialogComponent } from './shared/relogin-dialog/relogin-dialog.component';


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
    OrgProfilePreviewComponent,
    UserPostsComponent,
    NavBarComponent,
    NetworkComponent,
    NotificationsComponent,
    NetworksListComponent,
    NetworkSideBarComponent,
    InvitationsComponent,
    InvitationsListComponent,
    NetworksComponent,
    CustomLoaderComponent,
    ChatsComponent,
    ChatDetailsComponent,
    UsersDialogComponent,
    MessagesComponent,
    PostCommentsDialogComponent,
    OrgProfileComponent,
    PersonalProfileComponent,
    OrgAboutComponent,
    OrgPostsComponent,
    OrgJobsComponent,
    SearchComponent,
    SearchAllComponent,
    SearchPostsComponent,
    SearchPersonalUsersComponent,
    SearchOrganizationalUsersComponent,
    SharePostDialogComponent,
    PostDetailsComponent,
    ReloginDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
    BrowserAnimationsModule,
    MatDialogModule,
    MatIconModule,
    NgSelectModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule,
    MatBadgeModule,
    MatListModule,
    MatCardModule,
    MatTabsModule,
    NgxSpinnerModule,
    FormsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
