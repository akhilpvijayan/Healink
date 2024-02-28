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
    if(this.loginForm.valid){
      this.authService.login(this.loginForm.value).subscribe({
        next: (result: any) => {
          if (result !== null && (result.accessToken || result.refreshToken)) {
            this.authService.setToken(result.accessToken);
            this.authService.setUser(result.userId);
            this.authService.setRefreshToken(result.refreshToken);
            this.loginForm.reset();
            this.router.navigateByUrl('home');
          } else {
            console.error('Login failed: Invalid response from server');
          }
        },
        error: (err: any) => {
          console.error('Login failed:', err);
          if (err.status === 401) {
            console.error('Invalid credentials');
          } else {
            console.error('An error occurred during login');
          }
        }
      });
      
    }
  }
  
}
