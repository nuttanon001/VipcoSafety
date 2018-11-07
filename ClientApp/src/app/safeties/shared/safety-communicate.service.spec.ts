import { TestBed, inject } from '@angular/core/testing';

import { SafetyCommunicateService } from './safety-communicate.service';

describe('SafetyCommunicateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SafetyCommunicateService]
    });
  });

  it('should be created', inject([SafetyCommunicateService], (service: SafetyCommunicateService) => {
    expect(service).toBeTruthy();
  }));
});
