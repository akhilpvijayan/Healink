import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { SearchService } from 'src/app/services/search.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-search-personal-users',
  templateUrl: './search-personal-users.component.html',
  styleUrls: ['./search-personal-users.component.scss']
})
export class SearchPersonalUsersComponent implements OnInit{
  @Input() searchQuery : any;
  skip = 0;
  take = 6;
  userId: any;
  personalUsers: any;

  constructor(private searchService: SearchService,
    private imgConverter: ImageConversionService,
    private userService: UserService,
    private router: Router
  ){}

  ngOnInit(): void {
    this.userId = this.userService.getUserId();
    this.getPersonalUsers();
  }

  getPersonalUsers(){
    this.searchService.getAllPersonalUsersInSearch(this.searchQuery, this.skip, this.take).subscribe((res: any)=>{
      if(res[0]){
        const promises = res.map((post: any) => {
          const profileLogoConversionPromise = post.profileImage != null ? 
            this.imgConverter.convertImageToDataURL(post.profileImage).then((dataUrl: any) => {
              post.profileImage = dataUrl;
            }) : Promise.resolve();
      
          return Promise.all([profileLogoConversionPromise]);
        });
  
        Promise.all(promises)
          .then(() => {
            this.personalUsers = res;
          })
          .catch(error => {
            console.error('Error converting images:', error);
          });
      }
    });
  }

  onWindowScroll() {
    this.skip += this.take;
    this.getPersonalUsers();
    }

    showProfile(userId: any) {
      this.router.navigate(['profile'], { queryParams: { userId: userId } });
    }

}
