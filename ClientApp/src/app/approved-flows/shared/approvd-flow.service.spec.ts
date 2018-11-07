import { TestBed, inject } from '@angular/core/testing';

import { ApprovdFlowService } from './approvd-flow.service';

describe('ApprovdFlowService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ApprovdFlowService]
    });
  });

  it('should be created', inject([ApprovdFlowService], (service: ApprovdFlowService) => {
    expect(service).toBeTruthy();
  }));
});
