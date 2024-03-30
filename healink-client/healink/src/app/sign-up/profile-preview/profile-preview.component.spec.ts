import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfilePreviewComponent } from './profile-preview.component';

describe('ProfilePreviewComponent', () => {
  let component: ProfilePreviewComponent;
  let fixture: ComponentFixture<ProfilePreviewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProfilePreviewComponent]
    });
    fixture = TestBed.createComponent(ProfilePreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
