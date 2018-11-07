import { Injectable } from '@angular/core';
import { BaseCommunicateService } from '../../shared/base-communicate.service';

@Injectable()
export class LocationCommunicateService extends BaseCommunicateService<Location> {
  constructor() { super(); }
}
