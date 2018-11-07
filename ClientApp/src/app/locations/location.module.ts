import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LocationRoutingModule } from './location-routing.module';
import { LocationService } from './shared/location.service';
import { LocationCommunicateService } from './shared/location-communicate.service';

@NgModule({
  imports: [
    CommonModule,
    LocationRoutingModule
  ],
  declarations: [],
  providers: [
    LocationService,
    LocationCommunicateService
  ]
})
export class LocationModule { }
