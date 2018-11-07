import { TestBed, inject } from '@angular/core/testing';

import { ConfinedSpaceEmphelpService } from './confined-space-emphelp.service';

describe('ConfinedSpaceEmphelpService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ConfinedSpaceEmphelpService]
    });
  });

  it('should be created', inject([ConfinedSpaceEmphelpService], (service: ConfinedSpaceEmphelpService) => {
    expect(service).toBeTruthy();
  }));
});
