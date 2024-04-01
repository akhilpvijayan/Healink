import { AfterViewInit, Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Route, Router } from '@angular/router';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-side-profile',
  templateUrl: './side-profile.component.html',
  styleUrls: ['./side-profile.component.scss']
})
export class SideProfileComponent{
  @Input() userDetail: any;
  constructor(private router: Router,
    private userService: UserService){}
  
  showProfile() {
    this.router.navigate(['profile'], { queryParams: { userId: this.userService.getUserId() } });
  }
}
