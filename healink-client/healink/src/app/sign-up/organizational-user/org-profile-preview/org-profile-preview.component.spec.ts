import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrgProfilePreviewComponent } from './org-profile-preview.component';

describe('OrgProfilePreviewComponent', () => {
  let component: OrgProfilePreviewComponent;
  let fixture: ComponentFixture<OrgProfilePreviewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OrgProfilePreviewComponent]
    });
    fixture = TestBed.createComponent(OrgProfilePreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
