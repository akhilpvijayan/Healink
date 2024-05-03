import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { SearchService } from 'src/app/services/search.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-search-organizational-users',
  templateUrl: './search-organizational-users.component.html',
  styleUrls: ['./search-organizational-users.component.scss']
})
export class SearchOrganizationalUsersComponent implements OnInit{
  @Input() searchQuery : any;
  skip = 0;
  take = 3;
  organizationalUsers: any;
  userId: any;
  
    constructor(private searchService: SearchService,
      private imgConverter: ImageConversionService,
      private userService: UserService,
      private router: Router
    ){}
  
    ngOnInit(): void {
      this.userId = this.userService.getUserId();
      this.getOrganizationalUsers();
    }
  
    getOrganizationalUsers(){
      this.searchService.getAllOrganizationalUsersInSearch(this.searchQuery, this.skip, this.take).subscribe((res: any)=>{
        if(res[0]){
          const promises = res.map((post: any) => {
            const profileLogoConversionPromise = post.organizationLogo != null ? 
              this.imgConverter.convertImageToDataURL(post.organizationLogo).then((dataUrl: any) => {
                post.organizationLogo = dataUrl;
              }) : Promise.resolve();
        
            return Promise.all([profileLogoConversionPromise]);
          });
    
          Promise.all(promises)
            .then(() => {
              this.organizationalUsers = res;
            })
            .catch(error => {
              console.error('Error converting images:', error);
            });
        }
      });
    }
  
    onWindowScroll() {
      this.skip += this.take;
      this.getOrganizationalUsers();
      }

      showProfile(userId: any) {
        this.router.navigate(['profile'], { queryParams: { userId: userId } });
      }
  
}
