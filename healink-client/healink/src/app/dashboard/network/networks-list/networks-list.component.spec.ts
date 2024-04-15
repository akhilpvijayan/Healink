import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NetworksListComponent } from './networks-list.component';

describe('NetworksListComponent', () => {
  let component: NetworksListComponent;
  let fixture: ComponentFixture<NetworksListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NetworksListComponent]
    });
    fixture = TestBed.createComponent(NetworksListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
