import { TestBed, inject } from '@angular/core/testing';

import { LiftingCheckService } from './lifting-check.service';

describe('LiftingCheckService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LiftingCheckService]
    });
  });

  it('should be created', inject([LiftingCheckService], (service: LiftingCheckService) => {
    expect(service).toBeTruthy();
  }));
});
