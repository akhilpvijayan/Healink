import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrgJobsComponent } from './org-jobs.component';

describe('OrgJobsComponent', () => {
  let component: OrgJobsComponent;
  let fixture: ComponentFixture<OrgJobsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OrgJobsComponent]
    });
    fixture = TestBed.createComponent(OrgJobsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
