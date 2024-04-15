import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NetworkSideBarComponent } from './network-side-bar.component';

describe('NetworkSideBarComponent', () => {
  let component: NetworkSideBarComponent;
  let fixture: ComponentFixture<NetworkSideBarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NetworkSideBarComponent]
    });
    fixture = TestBed.createComponent(NetworkSideBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
