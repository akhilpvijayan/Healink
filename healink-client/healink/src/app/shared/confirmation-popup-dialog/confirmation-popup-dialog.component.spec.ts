import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmationPopupDialogComponent } from './confirmation-popup-dialog.component';

describe('ConfirmationPopupDialogComponent', () => {
  let component: ConfirmationPopupDialogComponent;
  let fixture: ComponentFixture<ConfirmationPopupDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ConfirmationPopupDialogComponent]
    });
    fixture = TestBed.createComponent(ConfirmationPopupDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
