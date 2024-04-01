import { formatDate } from '@angular/common';
import { Component, Input } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-profile-preview',
  templateUrl: './profile-preview.component.html',
  styleUrls: ['./profile-preview.component.scss']
})
export class ProfilePreviewComponent {
  @Input() userForm: any;

  constructor(private userService: UserService){}

  formatMonthYear(date: string): string{
    return this.userService.formatMonthYear(date);
  }

  calculateDuration(startDate: string, endDate: string, current: boolean): string {
    return this.userService.calculateDuration(startDate, endDate, current);
  }
}
