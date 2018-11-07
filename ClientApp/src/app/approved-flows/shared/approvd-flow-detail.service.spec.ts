import { TestBed, inject } from '@angular/core/testing';

import { ApprovdFlowDetailService } from './approvd-flow-detail.service';

describe('ApprovdFlowDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ApprovdFlowDetailService]
    });
  });

  it('should be created', inject([ApprovdFlowDetailService], (service: ApprovdFlowDetailService) => {
    expect(service).toBeTruthy();
  }));
});
