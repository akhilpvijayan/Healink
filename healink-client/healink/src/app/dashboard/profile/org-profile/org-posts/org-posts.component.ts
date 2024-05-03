import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-org-posts',
  templateUrl: './org-posts.component.html',
  styleUrls: ['./org-posts.component.scss']
})
export class OrgPostsComponent {
  @Input() userDetail: any;
}
