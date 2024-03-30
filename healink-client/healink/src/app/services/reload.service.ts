import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReloadService {

  private reloadSubject = new Subject<string>();

  reloadComponent(componentName: string): void {
    this.reloadSubject.next(componentName);
  }

  getReloadObservable(): Observable<string> {
    return this.reloadSubject.asObservable();
  }
}
