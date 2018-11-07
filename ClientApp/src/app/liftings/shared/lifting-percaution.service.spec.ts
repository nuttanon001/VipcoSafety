import { TestBed, inject } from '@angular/core/testing';

import { LiftingPercautionService } from './lifting-percaution.service';

describe('LiftingPercautionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LiftingPercautionService]
    });
  });

  it('should be created', inject([LiftingPercautionService], (service: LiftingPercautionService) => {
    expect(service).toBeTruthy();
  }));
});
