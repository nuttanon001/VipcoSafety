import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AllWorkPermitRoutingModule } from './all-work-permit-routing.module';
import { AllWorkPermitService } from './shared/all-work-permit.service';
import { CenterAllWorkPermitComponent } from './center-all-work-permit.component';
import { MasterAllWorkPermitComponent } from './master-all-work-permit/master-all-work-permit.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomMaterialModule } from '../shared/customer-material.module';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CustomMaterialModule,
    AllWorkPermitRoutingModule
  ],
  declarations: [
    CenterAllWorkPermitComponent,
    MasterAllWorkPermitComponent
  ],
  providers: [
    AllWorkPermitService
  ]
})
export class AllWorkPermitModule { }
