import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchPostsComponent } from './search-posts.component';

describe('SearchPostsComponent', () => {
  let component: SearchPostsComponent;
  let fixture: ComponentFixture<SearchPostsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchPostsComponent]
    });
    fixture = TestBed.createComponent(SearchPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
