import { TestBed, inject } from '@angular/core/testing';

import { ConfinedSpaceEquipService } from './confined-space-equip.service';

describe('ConfinedSpaceEquipService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ConfinedSpaceEquipService]
    });
  });

  it('should be created', inject([ConfinedSpaceEquipService], (service: ConfinedSpaceEquipService) => {
    expect(service).toBeTruthy();
  }));
});
