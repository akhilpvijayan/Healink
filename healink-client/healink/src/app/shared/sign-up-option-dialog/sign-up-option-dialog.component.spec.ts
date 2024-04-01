import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignUpOptionDialogComponent } from './sign-up-option-dialog.component';

describe('SignUpOptionDialogComponent', () => {
  let component: SignUpOptionDialogComponent;
  let fixture: ComponentFixture<SignUpOptionDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SignUpOptionDialogComponent]
    });
    fixture = TestBed.createComponent(SignUpOptionDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
