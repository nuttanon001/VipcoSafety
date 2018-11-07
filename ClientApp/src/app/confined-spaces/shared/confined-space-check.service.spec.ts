import { TestBed, inject } from '@angular/core/testing';

import { ConfinedSpaceCheckService } from './confined-space-check.service';

describe('ConfinedSpaceCheckService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ConfinedSpaceCheckService]
    });
  });

  it('should be created', inject([ConfinedSpaceCheckService], (service: ConfinedSpaceCheckService) => {
    expect(service).toBeTruthy();
  }));
});
