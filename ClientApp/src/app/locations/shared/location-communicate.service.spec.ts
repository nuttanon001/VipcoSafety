import { TestBed, inject } from '@angular/core/testing';

import { LocationCommunicateService } from './location-communicate.service';

describe('LocationCommunicateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LocationCommunicateService]
    });
  });

  it('should be created', inject([LocationCommunicateService], (service: LocationCommunicateService) => {
    expect(service).toBeTruthy();
  }));
});
