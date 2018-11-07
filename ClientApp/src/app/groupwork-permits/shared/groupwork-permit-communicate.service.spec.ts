import { TestBed, inject } from '@angular/core/testing';

import { GroupworkPermitCommunicateService } from './groupwork-permit-communicate.service';

describe('GroupworkPermitCommunicateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GroupworkPermitCommunicateService]
    });
  });

  it('should be created', inject([GroupworkPermitCommunicateService], (service: GroupworkPermitCommunicateService) => {
    expect(service).toBeTruthy();
  }));
});
