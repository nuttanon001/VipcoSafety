import { TestBed, inject } from '@angular/core/testing';

import { PermitHasEquipmentService } from './permit-has-equipment.service';

describe('PermitHasEquipmentService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PermitHasEquipmentService]
    });
  });

  it('should be created', inject([PermitHasEquipmentService], (service: PermitHasEquipmentService) => {
    expect(service).toBeTruthy();
  }));
});
