// Angular Core
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
// Modules
import { SharedModule } from '../shared/shared.module';
import { CustomMaterialModule } from '../shared/customer-material.module';
import { ConfinedSpaceRoutingModule } from './confined-space-routing.module';
// Services
import { ConfinedSpaceService } from './shared/confined-space.service';
import { ConfinedSpaceEquipService } from './shared/confined-space-equip.service';
import { ConfinedSpaceCheckService } from './shared/confined-space-check.service';
import { ConfinedSpaceEmphelpService } from './shared/confined-space-emphelp.service';
import { ConfinedSpaceEmpworkService } from './shared/confined-space-empwork.service';
import { ConfinedSpaceCommunicateService } from './shared/confined-space-communicate.service';
// Components
import { ConfinedSpaceCenterComponent } from './confined-space-center.component';
import { ConfinedSpaceInfoComponent } from './confined-space-info/confined-space-info.component';
import { ConfinedSpaceTableComponent } from './confined-space-table/confined-space-table.component';
import { ConfinedSpaceMasterComponent } from './confined-space-master/confined-space-master.component';
import { ConfinedSpaceEmphelpTableComponent } from './confined-space-emphelp-table/confined-space-emphelp-table.component';
import { ConfinedSpaceEmpworkTableComponent } from './confined-space-empwork-table/confined-space-empwork-table.component';
import { ConfinedSpaceChecklistTableComponent } from './confined-space-checklist-table/confined-space-checklist-table.component';
import { ConfinedSpaceEquipmentTableComponent } from './confined-space-equipment-table/confined-space-equipment-table.component';
import { PermitHasChecklistService } from '../groupwork-permits/shared/permit-has-checklist.service';
import { PermitHasEquipmentService } from '../groupwork-permits/shared/permit-has-equipment.service';
import { ConfinedSpacePrecautionTableComponent } from './confined-space-precaution-table/confined-space-precaution-table.component';
import { ConfinedSpacePerService } from './shared/confined-space-per.service';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    CustomMaterialModule,
    ConfinedSpaceRoutingModule,
  ],
  declarations: [
    ConfinedSpaceCenterComponent,
    ConfinedSpaceTableComponent,
    ConfinedSpaceMasterComponent,
    ConfinedSpaceInfoComponent,
    ConfinedSpaceEmphelpTableComponent,
    ConfinedSpaceEmpworkTableComponent,
    ConfinedSpaceChecklistTableComponent,
    ConfinedSpaceEquipmentTableComponent,
    ConfinedSpacePrecautionTableComponent,
  ],
  providers: [
    ConfinedSpaceService,
    ConfinedSpaceEmphelpService,
    ConfinedSpaceEmpworkService,
    ConfinedSpaceEquipService,
    ConfinedSpaceCheckService,
    ConfinedSpaceCommunicateService,
    PermitHasChecklistService,
    PermitHasEquipmentService,
    ConfinedSpacePerService,
  ]
})
export class ConfinedSpaceModule { }
