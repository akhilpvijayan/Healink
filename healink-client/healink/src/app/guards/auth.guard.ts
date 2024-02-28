import { Injectable } from '@angular/core';
import { CanActivate, CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../Auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService:AuthService, private router: Router) {}

  canActivate(): boolean{
    if(this.authService.isLoggedIn()){
      return true;
    }
    else{
      this.router.navigateByUrl('login');
      return false;
    }
  }
};
