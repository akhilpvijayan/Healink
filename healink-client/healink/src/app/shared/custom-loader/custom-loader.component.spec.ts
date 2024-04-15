import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomLoaderComponent } from './custom-loader.component';

describe('CustomLoaderComponent', () => {
  let component: CustomLoaderComponent;
  let fixture: ComponentFixture<CustomLoaderComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CustomLoaderComponent]
    });
    fixture = TestBed.createComponent(CustomLoaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
