import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-org-about',
  templateUrl: './org-about.component.html',
  styleUrls: ['./org-about.component.scss']
})
export class OrgAboutComponent implements OnInit{
@Input() userDetail: any;

constructor(){}

ngOnInit(): void {
  throw new Error('Method not implemented.');
}
}
