import { TestBed, inject } from '@angular/core/testing';

import { ConfinedSpaceCommunicateService } from './confined-space-communicate.service';

describe('ConfinedSpaceCommunicateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ConfinedSpaceCommunicateService]
    });
  });

  it('should be created', inject([ConfinedSpaceCommunicateService], (service: ConfinedSpaceCommunicateService) => {
    expect(service).toBeTruthy();
  }));
});
