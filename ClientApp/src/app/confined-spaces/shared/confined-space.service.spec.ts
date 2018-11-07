import { TestBed, inject } from '@angular/core/testing';

import { ConfinedSpaceService } from './confined-space.service';

describe('ConfinedSpaceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ConfinedSpaceService]
    });
  });

  it('should be created', inject([ConfinedSpaceService], (service: ConfinedSpaceService) => {
    expect(service).toBeTruthy();
  }));
});
