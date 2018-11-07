import { Injectable } from '@angular/core';
import { BaseCommunicateService } from '../../shared/base-communicate.service';
import { GroupworkPermit } from './groupwork-permit.model';

@Injectable()
export class GroupworkPermitCommunicateService extends BaseCommunicateService<GroupworkPermit> {
  constructor() { super() }
}
