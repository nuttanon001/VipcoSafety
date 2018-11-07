//Angular Core
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
// Services
import { ApprovdFlowService } from './shared/approvd-flow.service';
import { ApprovdFlowDetailService } from './shared/approvd-flow-detail.service';
import { ApprovdFlowCommunicateService } from './shared/approvd-flow-communicate.service';
// Components
import { ApprovedCenterComponent } from './approved-center.component';
import { ApprovedInfoComponent } from './approved-info/approved-info.component';
import { ApprovedTableComponent } from './approved-table/approved-table.component';
import { ApprovedMasterComponent } from './approved-master/approved-master.component';
import { ApprovedDetailTableComponent } from './approved-detail-table/approved-detail-table.component';
// Modules
import { CustomMaterialModule } from '../shared/customer-material.module';
import { ApprovedFlowRoutingModule } from './approved-flow-routing.module';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CustomMaterialModule,
    ApprovedFlowRoutingModule
  ],
  declarations: [
    ApprovedCenterComponent,
    ApprovedMasterComponent,
    ApprovedInfoComponent,
    ApprovedTableComponent,
    ApprovedDetailTableComponent],
  providers: [
    ApprovdFlowService,
    ApprovdFlowDetailService,
    ApprovdFlowCommunicateService
  ]
})
export class ApprovedFlowModule { }
