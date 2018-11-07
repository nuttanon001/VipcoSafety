// Angular Core
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// Modules
import { SharedModule } from '../shared/shared.module';
import { LiftingRoutingModule } from './lifting-routing.module';
import { CustomMaterialModule } from '../shared/customer-material.module';
// Services
import { LiftingService } from './shared/lifting.service';
import { LiftingEquipService } from './shared/lifting-equip.service';
import { LiftingCheckService } from './shared/lifting-check.service';
import { LiftingCommunicateService } from './shared/lifting-communicate.service';
// Components
import { LiftingCenterComponent } from './lifting-center.component';
import { LiftingInfoComponent } from './lifting-info/lifting-info.component';
import { LiftingTableComponent } from './lifting-table/lifting-table.component';
import { LiftingMasterComponent } from './lifting-master/lifting-master.component';
import { LiftingChecklistTableComponent } from './lifting-checklist-table/lifting-checklist-table.component';
import { LiftingEquipmentTableComponent } from './lifting-equipment-table/lifting-equipment-table.component';
import { EmployeeGroupService } from '../employees/shared/employee-group.service';
import { PermitHasChecklistService } from '../groupwork-permits/shared/permit-has-checklist.service';
import { PermitHasEquipmentService } from '../groupwork-permits/shared/permit-has-equipment.service';
import { LiftingReportComponent } from './lifting-report/lifting-report.component';
import { LiftingPercautionTableComponent } from './lifting-percaution-table/lifting-percaution-table.component';
import { LiftingPercautionService } from './shared/lifting-percaution.service';

@NgModule({
  imports: [
    FormsModule,
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    CustomMaterialModule,
    LiftingRoutingModule,
  ],
  declarations: [
    LiftingCenterComponent,
    LiftingTableComponent,
    LiftingMasterComponent,
    LiftingInfoComponent,
    LiftingChecklistTableComponent,
    LiftingEquipmentTableComponent,
    LiftingReportComponent,
    LiftingPercautionTableComponent
  ],
  providers: [
    LiftingService,
    LiftingEquipService,
    LiftingCheckService,
    EmployeeGroupService,
    PermitHasChecklistService,
    PermitHasEquipmentService,
    LiftingCommunicateService,
    LiftingPercautionService,
  ]
})
export class LiftingModule { }
