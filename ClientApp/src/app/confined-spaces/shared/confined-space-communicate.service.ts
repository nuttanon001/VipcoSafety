import { Injectable } from '@angular/core';
import { BaseCommunicateService } from '../../shared/base-communicate.service';
import { ConfinedSpace } from './confined-space.model';

@Injectable()
export class ConfinedSpaceCommunicateService extends BaseCommunicateService<ConfinedSpace> {
  constructor() { super(); }
}
