import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AbstractControl } from '@angular/forms';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(
    private httpClient: HttpClient) { }

    getUserDetail(userId: any) {
      return this.httpClient.get<any>(`${environment.apiUrl}users/`+userId);
    }

    getPersonalUsers(userId: any) {
      return this.httpClient.get<any>(`${environment.apiUrl}users/personal/`+userId);
    }

    getOrganizationalUsers(userId: any) {
      return this.httpClient.get<any>(`${environment.apiUrl}users/organizational/`+userId);
    }

    getUserId(){
      const user = localStorage.getItem("healink-user-id");
      return user?parseInt(user, 10):0;
    }

    addUser(data: any){
      return this.httpClient.post<any>(`${environment.apiUrl}signup/`, data);
    }

    addUserExperience(experience: any, userId : number) {
      return this.httpClient.post<any>(`${environment.apiUrl}user/experience/`+userId, experience);
    }

    addUserEducation(education: any, userId: number) {
      return this.httpClient.post<any>(`${environment.apiUrl}user/education/`+userId, education);
    }

    updateUser(data: any, userId: number){
      return this.httpClient.put<any>(`${environment.apiUrl}user/`+userId, data);
    }

    isDuplicateUsername(username: string) {
      return this.httpClient.get<any>(`${environment.apiUrl}isduplicateusername/`+username);
    }

    isDuplicateEmail(email: string) {
      return this.httpClient.get<any>(`${environment.apiUrl}isemailexist/`+email);
    }

    formatMonthYear(date: string): string {
      return formatDate(date, 'MMM yyyy', 'en-US');
    }

    isChatExist(userId: number, targetId: number){
      return this.httpClient.get<any>(`${environment.apiUrl}chats/exists/`+userId+`/`+targetId);
    }
  
    calculateDuration(startDate: string, endDate: string, current: boolean): string {
      if (current && !endDate) {
        // If current and no end date, calculate duration between start date and current date
        const currentDate = new Date();
        const diff = currentDate.getTime() - new Date(startDate).getTime();
        return this.formatDuration(diff);
      } else if (endDate) {
        // If end date is set, calculate duration between start date and end date
        const diff = new Date(endDate).getTime() - new Date(startDate).getTime();
        return this.formatDuration(diff);
      } else {
        return '';
      }
    }
  
    private formatDuration(diff: number): string {
      const years = Math.floor(diff / (1000 * 60 * 60 * 24 * 365));
      var months = Math.floor((diff % (1000 * 60 * 60 * 24 * 365)) / (1000 * 60 * 60 * 24 * 30));
      months = months == 0 && years == 0 ? 1: months;
      return years > 0 ? `${years} yr ${months} mos` : `${months} mos`;
    }

    // Custom validator function to check if username already exists
  userNameExists(control: AbstractControl) {
    return new Promise(resolve => {
      if (!control.value) {
        resolve(false);
      } else {
        this.isDuplicateUsername(control.value).subscribe((res: boolean) => {
          resolve(res ? { userNameExists: true } : false);
        });
      }
    });
  }

  emailExists(control: AbstractControl) {
    return new Promise(resolve => {
      if (!control.value) {
        resolve(false);
      } else {
        this.isDuplicateEmail(control.value).subscribe((res: boolean) => {
          resolve(res ? { emailExists: true } : false);
        });
      }
    });
  }

}
