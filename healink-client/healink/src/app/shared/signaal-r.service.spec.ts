import { TestBed } from '@angular/core/testing';

import { SignaalRService } from './signaal-r.service';

describe('SignaalRService', () => {
  let service: SignaalRService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SignaalRService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
