import { Injectable } from '@angular/core';
import { BaseCommunicateService } from '../../shared/base-communicate.service';
import { ApprovdFlow } from './approvd-flow.model';

@Injectable()
export class ApprovdFlowCommunicateService extends BaseCommunicateService<ApprovdFlow> {
  constructor() { super(); }
}
