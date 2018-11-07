import { TestBed, inject } from '@angular/core/testing';

import { GroupworkPermitService } from './groupwork-permit.service';

describe('GroupworkPermitService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GroupworkPermitService]
    });
  });

  it('should be created', inject([GroupworkPermitService], (service: GroupworkPermitService) => {
    expect(service).toBeTruthy();
  }));
});
