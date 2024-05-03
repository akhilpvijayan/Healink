import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchOrganizationalUsersComponent } from './search-organizational-users.component';

describe('SearchOrganizationalUsersComponent', () => {
  let component: SearchOrganizationalUsersComponent;
  let fixture: ComponentFixture<SearchOrganizationalUsersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchOrganizationalUsersComponent]
    });
    fixture = TestBed.createComponent(SearchOrganizationalUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
