import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SafetyRoutingModule } from './safety-routing.module';
import { SafetyService } from './shared/safety.service';
import { SafetyCommunicateService } from './shared/safety-communicate.service';
import { SafetyCenterComponent } from './safety-center.component';
import { SafetyTableComponent } from './safety-table/safety-table.component';
import { SafetyMasterComponent } from './safety-master/safety-master.component';
import { SafetyInfoComponent } from './safety-info/safety-info.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { CustomMaterialModule } from '../shared/customer-material.module';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SafetyRoutingModule,
    CustomMaterialModule,
    SharedModule
  ],
  declarations: [
    SafetyCenterComponent,
    SafetyTableComponent,
    SafetyMasterComponent,
    SafetyInfoComponent
  ],
  providers: [
    SafetyService,
    SafetyCommunicateService
  ]
})
export class SafetyModule { }
