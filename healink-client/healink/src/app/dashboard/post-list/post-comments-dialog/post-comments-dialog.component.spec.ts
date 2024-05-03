import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostCommentsDialogComponent } from './post-comments-dialog.component';

describe('PostCommentsDialogComponent', () => {
  let component: PostCommentsDialogComponent;
  let fixture: ComponentFixture<PostCommentsDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PostCommentsDialogComponent]
    });
    fixture = TestBed.createComponent(PostCommentsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
