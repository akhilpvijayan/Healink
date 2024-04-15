import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-networks',
  templateUrl: './networks.component.html',
  styleUrls: ['./networks.component.scss']
})
export class NetworksComponent implements OnInit{
personalUsers: any;
organizationUsers: any;
userId: any;
  constructor(private userService: UserService,
    private imgConverter: ImageConversionService,
    private spinner: NgxSpinnerService,
    private router: Router){}

  ngOnInit(): void {
    this.spinner.show();
    this.userId = this.userService.getUserId();
    this.userService.getPersonalUsers(this.userId).subscribe((res: any) =>{
      if(res){
        const promises = res.map((user: any) => {
          const imageConversionPromise = user.profileImage != null ? 
            this.imgConverter.convertImageToDataURL(user.profileImage).then((dataUrl: any) => {
              user.profileImage = dataUrl;
            }) : Promise.resolve();
    
          return Promise.all([imageConversionPromise]);
        });
  
        Promise.all(promises)
          .then(() => {
            this.personalUsers = res;
            this.spinner.hide();
          })
          .catch(error => {
            console.error('Error converting images:', error);
            this.spinner.hide();
          });
      }
      else{
        //this.spinner.hide();
      }
    });

    this.userService.getOrganizationalUsers(this.userId).subscribe((res: any) =>{
      if(res){
        const promises = res.map((user: any) => {
          const imageConversionPromise = user.organizationLogo != null ? 
            this.imgConverter.convertImageToDataURL(user.organizationLogo).then((dataUrl: any) => {
              user.organizationLogo = dataUrl;
            }) : Promise.resolve();
    
          return Promise.all([imageConversionPromise]);
        });
  
        Promise.all(promises)
          .then(() => {
            this.organizationUsers = res;
            //this.spinner.hide();
          })
          .catch(error => {
            console.error('Error converting images:', error);
            //this.spinner.hide();
          });
      }
      else{
        //this.spinner.hide();
      }
    })
  }

  showProfile(userId: number) {
    this.router.navigate(['profile'], { queryParams: { userId: userId } });
  }
}
