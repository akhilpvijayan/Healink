import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-org-profile-preview',
  templateUrl: './org-profile-preview.component.html',
  styleUrls: ['./org-profile-preview.component.scss']
})
export class OrgProfilePreviewComponent {
  @Input() orgForm: any;
}
