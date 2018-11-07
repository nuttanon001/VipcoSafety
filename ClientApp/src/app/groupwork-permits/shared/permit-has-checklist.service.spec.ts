import { TestBed, inject } from '@angular/core/testing';

import { PermitHasChecklistService } from './permit-has-checklist.service';

describe('PermitHasChecklistService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PermitHasChecklistService]
    });
  });

  it('should be created', inject([PermitHasChecklistService], (service: PermitHasChecklistService) => {
    expect(service).toBeTruthy();
  }));
});
