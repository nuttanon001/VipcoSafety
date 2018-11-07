import { TestBed, inject } from '@angular/core/testing';

import { ConfinedSpacePerService } from './confined-space-per.service';

describe('ConfinedSpacePerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ConfinedSpacePerService]
    });
  });

  it('should be created', inject([ConfinedSpacePerService], (service: ConfinedSpacePerService) => {
    expect(service).toBeTruthy();
  }));
});
