import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchPersonalUsersComponent } from './search-personal-users.component';

describe('SearchPersonalUsersComponent', () => {
  let component: SearchPersonalUsersComponent;
  let fixture: ComponentFixture<SearchPersonalUsersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchPersonalUsersComponent]
    });
    fixture = TestBed.createComponent(SearchPersonalUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
