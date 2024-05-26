import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReloginDialogComponent } from './relogin-dialog.component';

describe('ReloginDialogComponent', () => {
  let component: ReloginDialogComponent;
  let fixture: ComponentFixture<ReloginDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReloginDialogComponent]
    });
    fixture = TestBed.createComponent(ReloginDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
