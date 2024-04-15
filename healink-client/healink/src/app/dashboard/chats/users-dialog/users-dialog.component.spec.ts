import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersDialogComponent } from './users-dialog.component';

describe('UsersDialogComponent', () => {
  let component: UsersDialogComponent;
  let fixture: ComponentFixture<UsersDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsersDialogComponent]
    });
    fixture = TestBed.createComponent(UsersDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
