// Angular Core
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
// Modules
import { CustomMaterialModule } from '../shared/customer-material.module';
import { GroupworkPermitRoutingModule } from './groupwork-permit-routing.module';
// Services
import { GroupworkPermitService } from './shared/groupwork-permit.service';
import { PermitHasChecklistService } from './shared/permit-has-checklist.service';
import { PermitHasEquipmentService } from './shared/permit-has-equipment.service';
import { GroupworkPermitCommunicateService } from './shared/groupwork-permit-communicate.service';
// Components
import { GroupworkPermitCenterComponent } from './groupwork-permit-center.component';
import { GroupworkPermitInfoComponent } from './groupwork-permit-info/groupwork-permit-info.component';
import { GroupworkPermitTableComponent } from './groupwork-permit-table/groupwork-permit-table.component';
import { GroupworkPermitMasterComponent } from './groupwork-permit-master/groupwork-permit-master.component';
import { PermitHasChecklistComponent } from './permit-has-checklist/permit-has-checklist.component';
import { PermitHasEquipmentComponent } from './permit-has-equipment/permit-has-equipment.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CustomMaterialModule,
    GroupworkPermitRoutingModule
  ],
  declarations: [
    GroupworkPermitInfoComponent,
    GroupworkPermitTableComponent,
    GroupworkPermitCenterComponent,
    GroupworkPermitMasterComponent,
    PermitHasChecklistComponent,
    PermitHasEquipmentComponent,
  ],
  providers: [
    GroupworkPermitService,
    PermitHasEquipmentService,
    PermitHasChecklistService,
    GroupworkPermitCommunicateService,
  ]
})
export class GroupworkPermitModule { }
