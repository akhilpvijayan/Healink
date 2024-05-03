import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-org-jobs',
  templateUrl: './org-jobs.component.html',
  styleUrls: ['./org-jobs.component.scss']
})
export class OrgJobsComponent {
  @Input() userDetail: any;
}
