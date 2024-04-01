import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../Auth/auth.service';
import { Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DialogRef } from '@angular/cdk/dialog';
import { MatDialog } from '@angular/material/dialog';
import { SignUpOptionDialogComponent } from '../shared/sign-up-option-dialog/sign-up-option-dialog.component';
import { Enums } from '../shared/enums';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  isInvalidUser = false;
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private dialog: MatDialog,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  signUp() {
    const dialogRef = this.dialog.open(SignUpOptionDialogComponent, {
      width: '500px',
      height: '300px',
      hasBackdrop: true,
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result == Enums.Role.PersonalUser || result == Enums.Role.OrganizationalUser) {
        this.router.navigate(['signup'], { queryParams: { q: result } });
      }
    });
  }

  onSubmit() {
    this.isInvalidUser = false;
    if (this.loginForm.valid) {
      this.authService.login(this.loginForm.value).subscribe({
        next: (result: any) => {
          if (result !== null && (result.accessToken || result.refreshToken)) {
            this.authService.setToken(result.accessToken);
            this.authService.setUser(result.userId);
            this.authService.setRefreshToken(result.refreshToken);
            this.toastr.success(result.message);
            this.loginForm.reset();
            this.router.navigateByUrl('home');
          } else {
            this.toastr.error('Login failed: Invalid response from server.');
          }
        },
        error: (err: any) => {
          if (err.status == 404) {
            this.toastr.error('Invalid credentials.');
            this.isInvalidUser = true;
          }
          else {
            this.toastr.error('An error occurred during login.');
          }
        }
      });

    }
  }
}
