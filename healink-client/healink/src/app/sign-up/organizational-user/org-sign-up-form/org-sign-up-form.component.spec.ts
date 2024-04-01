import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrgSignUpFormComponent } from './org-sign-up-form.component';

describe('OrgSignUpFormComponent', () => {
  let component: OrgSignUpFormComponent;
  let fixture: ComponentFixture<OrgSignUpFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OrgSignUpFormComponent]
    });
    fixture = TestBed.createComponent(OrgSignUpFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
