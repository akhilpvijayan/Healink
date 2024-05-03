import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrgAboutComponent } from './org-about.component';

describe('OrgAboutComponent', () => {
  let component: OrgAboutComponent;
  let fixture: ComponentFixture<OrgAboutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OrgAboutComponent]
    });
    fixture = TestBed.createComponent(OrgAboutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
