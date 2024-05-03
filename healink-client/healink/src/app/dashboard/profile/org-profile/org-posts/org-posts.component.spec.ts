import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrgPostsComponent } from './org-posts.component';

describe('OrgPostsComponent', () => {
  let component: OrgPostsComponent;
  let fixture: ComponentFixture<OrgPostsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OrgPostsComponent]
    });
    fixture = TestBed.createComponent(OrgPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
