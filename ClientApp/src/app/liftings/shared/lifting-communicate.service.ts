import { Injectable } from '@angular/core';
import { BaseCommunicateService } from '../../shared/base-communicate.service';
import { Lifting } from './lifting.model';

@Injectable()
export class LiftingCommunicateService extends BaseCommunicateService<Lifting> {
  constructor() { super() }
}
