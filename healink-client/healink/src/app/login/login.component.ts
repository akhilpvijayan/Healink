import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../Auth/auth.service';
import { Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{

  loginForm!: FormGroup;
  isInvalidUser = false;
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService){}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
  onSubmit(){
    this.isInvalidUser = false;
    if(this.loginForm.valid){
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
          if(err.status == 404){
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
