import { TestBed, inject } from '@angular/core/testing';

import { ConfinedSpaceEmpworkService } from './confined-space-empwork.service';

describe('ConfinedSpaceEmpworkService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ConfinedSpaceEmpworkService]
    });
  });

  it('should be created', inject([ConfinedSpaceEmpworkService], (service: ConfinedSpaceEmpworkService) => {
    expect(service).toBeTruthy();
  }));
});
