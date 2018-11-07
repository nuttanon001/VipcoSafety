import { Injectable } from '@angular/core';
import { BaseCommunicateService } from '../../shared/base-communicate.service';
import { Safety } from './safety.model';

@Injectable()
export class SafetyCommunicateService extends BaseCommunicateService<Safety> {
  constructor() { super(); }
}
