import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Toast, ToastRef, ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/Auth/auth.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-relogin-dialog',
  templateUrl: './relogin-dialog.component.html',
  styleUrls: ['./relogin-dialog.component.scss']
})
export class ReloginDialogComponent {
  password: string = '';

  constructor(private authService: AuthService,
    private toastr: ToastrService,
    private dialogRef: MatDialogRef<ReloginDialogComponent>,
    private userService: UserService
  ){}

  login(){
    this.authService.login({username :this.userService.getUserDetail(this.userService.getUserId()), password :this.password}).subscribe({
      next: (result: any) => {
        if (result !== null && (result.accessToken || result.refreshToken)) {
          this.authService.setToken(result.accessToken);
          this.authService.setUser(result.userId);
          this.authService.setRefreshToken(result.refreshToken);
          this.toastr.success(result.message);
          this.closeDialog();
        } else {
          this.toastr.error('Login failed: Invalid response from server.');
        }
      },
      error: (err: any) => {
        if (err.status == 404) {
          this.toastr.error('Invalid credentials.');
        }
        else {
          this.toastr.error('An error occurred during login.');
        }
      }
    });
  }

  closeDialog(){
    this.dialogRef.close();
  }
}
