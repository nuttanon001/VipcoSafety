import { TestBed, inject } from '@angular/core/testing';

import { LiftingEquipService } from './lifting-equip.service';

describe('LiftingEquipService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LiftingEquipService]
    });
  });

  it('should be created', inject([LiftingEquipService], (service: LiftingEquipService) => {
    expect(service).toBeTruthy();
  }));
});
