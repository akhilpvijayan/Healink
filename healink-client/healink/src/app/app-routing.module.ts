import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './guards/auth.guard';
import { SignUpComponent } from './sign-up/sign-up.component';
import { ProfileComponent } from './dashboard/profile/profile.component';
import { UserPostsComponent } from './dashboard/profile/user-posts/user-posts.component';
import { NotificationsComponent } from './dashboard/notifications/notifications.component';
import { NetworkComponent } from './dashboard/network/network.component';
import { InvitationsListComponent } from './dashboard/network/invitations-list/invitations-list.component';
import { MessagesComponent } from './dashboard/messages/messages.component';
import { SearchComponent } from './search/search.component';

const routes: Routes = [
  { path: '', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignUpComponent },
  { path: 'home', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  { path: 'posts', component: UserPostsComponent, canActivate: [AuthGuard] },
  { path: 'notifications', component: NotificationsComponent, canActivate: [AuthGuard] },
  { path: 'network', component: NetworkComponent, canActivate: [AuthGuard] },
  { path: 'network/invitation-list', component: InvitationsListComponent, canActivate: [AuthGuard] },
  { path: 'users/personal', component: NetworkComponent, canActivate: [AuthGuard] },
  { path: 'users/organizational', component: NetworkComponent, canActivate: [AuthGuard] },
  { path: 'messages', component: MessagesComponent, canActivate: [AuthGuard] },
  { path: 'search', component: SearchComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
