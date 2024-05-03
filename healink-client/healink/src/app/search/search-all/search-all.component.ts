import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatTabGroup } from '@angular/material/tabs';
import { ImageConversionService } from 'src/app/services/image-conversion.service';
import { SearchService } from 'src/app/services/search.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-search-all',
  templateUrl: './search-all.component.html',
  styleUrls: ['./search-all.component.scss']
})
export class SearchAllComponent implements OnInit{
@Input() searchQuery : any;
@Output() invokeParentFunction = new EventEmitter<number>();
skip = 0;
take = 3;
topPersonalUsers: any;
topOrgUsers: any;
posts: any;
userId: any;

  constructor(private searchService: SearchService,
    private imgConverter: ImageConversionService,
    private userService: UserService
  ){}

  ngOnInit(): void {
    this.userId = this.userService.getUserId();
    this.searchService.getTopPersonalUsersInSearch(this.searchQuery, this.skip, this.take).subscribe((res: any)=>{
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
            this.topPersonalUsers = res;
          })
          .catch(error => {
            console.error('Error converting images:', error);
          });
      }
    });
    this.searchService.getTopOrganizationalUsersInSearch(this.searchQuery, this.skip, this.take).subscribe((res: any)=>{
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
            this.topOrgUsers = res;
          })
          .catch(error => {
            console.error('Error converting images:', error);
          });
      }
    });
    this.getPosts();
  }

  getPosts(){
    this.searchService.getAllPostsInSearch(this.searchQuery, this.skip, this.take, this.userId).subscribe((res: any)=>{
      if(res[0]){
        const promises = res.map((post: any) => {
          const imageConversionPromise = post.contentImage != null ? 
            this.imgConverter.convertImageToDataURL(post.contentImage).then((dataUrl: any) => {
              post.contentImage = dataUrl;
            }) : Promise.resolve();
      
          const profileLogoConversionPromise = post.profileLogo != null ? 
            this.imgConverter.convertImageToDataURL(post.profileLogo).then((dataUrl: any) => {
              post.profileLogo = dataUrl;
            }) : Promise.resolve();
      
          return Promise.all([imageConversionPromise, profileLogoConversionPromise]);
        });
  
        Promise.all(promises)
          .then(() => {
            this.posts = res;
          })
          .catch(error => {
            console.error('Error converting images:', error);
          });
      }
    });
  }

  onWindowScroll() {
    this.skip += this.take;
    this.getPosts();
    }

    navigateToPeopleTab(tabId: number) {
      this.invokeParentFunction.emit(tabId);
    }

}
