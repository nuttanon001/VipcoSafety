import { TestBed, inject } from '@angular/core/testing';

import { LiftingCommunicateService } from './lifting-communicate.service';

describe('LiftingCommunicateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LiftingCommunicateService]
    });
  });

  it('should be created', inject([LiftingCommunicateService], (service: LiftingCommunicateService) => {
    expect(service).toBeTruthy();
  }));
});
