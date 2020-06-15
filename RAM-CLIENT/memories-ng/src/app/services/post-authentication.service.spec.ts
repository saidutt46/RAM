import { TestBed } from '@angular/core/testing';

import { PostAuthenticationService } from './post-authentication.service';

describe('PostAuthenticationService', () => {
  let service: PostAuthenticationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PostAuthenticationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
