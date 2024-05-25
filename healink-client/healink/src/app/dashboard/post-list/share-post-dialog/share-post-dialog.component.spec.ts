import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharePostDialogComponent } from './share-post-dialog.component';

describe('SharePostDialogComponent', () => {
  let component: SharePostDialogComponent;
  let fixture: ComponentFixture<SharePostDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SharePostDialogComponent]
    });
    fixture = TestBed.createComponent(SharePostDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
