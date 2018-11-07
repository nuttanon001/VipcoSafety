import { TestBed, inject } from '@angular/core/testing';

import { LiftingService } from './lifting.service';

describe('LiftingService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LiftingService]
    });
  });

  it('should be created', inject([LiftingService], (service: LiftingService) => {
    expect(service).toBeTruthy();
  }));
});
