import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvitationsListComponent } from './invitations-list.component';

describe('InvitationsListComponent', () => {
  let component: InvitationsListComponent;
  let fixture: ComponentFixture<InvitationsListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InvitationsListComponent]
    });
    fixture = TestBed.createComponent(InvitationsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
