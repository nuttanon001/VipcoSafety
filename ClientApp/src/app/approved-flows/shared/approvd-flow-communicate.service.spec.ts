import { TestBed, inject } from '@angular/core/testing';

import { ApprovdFlowCommunicateService } from './approvd-flow-communicate.service';

describe('ApprovdFlowCommunicateService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ApprovdFlowCommunicateService]
    });
  });

  it('should be created', inject([ApprovdFlowCommunicateService], (service: ApprovdFlowCommunicateService) => {
    expect(service).toBeTruthy();
  }));
});
