import { TestBed, inject } from '@angular/core/testing';

import { AllWorkPermitService } from './all-work-permit.service';

describe('AllWorkPermitService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AllWorkPermitService]
    });
  });

  it('should be created', inject([AllWorkPermitService], (service: AllWorkPermitService) => {
    expect(service).toBeTruthy();
  }));
});
