// angular core
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
// 3rd party
import "rxjs/Rx";
import "hammerjs";
// services
import { DialogsService } from "./shared/dialogs.service";
// modules
import { CustomMaterialModule } from "../shared/customer-material.module";
import { SharedModule } from "../shared/shared.module";
// components
import { ErrorDialog } from "./error-dialog/error-dialog.component";
import { ContextDialog } from "./context-dialog/context-dialog.component";
import { ConfirmDialog } from "./confirm-dialog/confirm-dialog.component";
import { GroupDialogComponent } from "./group-dialog/group-dialog.component";
import { ProjectInfoComponent } from './project-dialog/project-info.component';
import { ProjectDialogComponent } from "./project-dialog/project-dialog.component";
import { GroupmisDialogComponent } from "./groupmis-dialog/groupmis-dialog.component";
import { EmployeeDialogComponent } from "./employee-dialog/employee-dialog.component";
import { GroupTableComponent } from "./group-dialog/groupmis-table/group-table.component";
import { ProjectSubInfoComponent } from './project-sub-dialog/project-sub-info.component';
import { ProjectSubDialogComponent } from './project-sub-dialog/project-sub-dialog.component';
import { ProjectTableComponent } from "./project-dialog/project-table/project-table.component";
import { EmployeeTableComponent } from "./employee-dialog/employee-table/employee-table.component";
import { GroupmisTableComponent } from "./groupmis-dialog/groupmis-table/groupmis-table.component";
import { ProjectDetailTableComponent } from './project-dialog/project-detail-table/project-detail-table.component';
import { ConfirmMessageDialogComponent } from './confirm-message-dialog/confirm-message-dialog.component';
import { CheckListDialogComponent } from './check-list-dialog/check-list-dialog.component';
import { CheckListInfoDialogComponent } from './check-list-dialog/check-list-info-dialog/check-list-info-dialog.component';
import { CheckListTableDialogComponent } from './check-list-dialog/check-list-table-dialog/check-list-table-dialog.component';
import { EquipmentDialogComponent } from './equipment-dialog/equipment-dialog.component';
import { EquipmentTableDialogComponent } from './equipment-dialog/equipment-table-dialog/equipment-table-dialog.component';
import { EquipmentInfoDialogComponent } from './equipment-dialog/equipment-info-dialog/equipment-info-dialog.component';
import { LocationDialogComponent } from './location-dialog/location-dialog.component';
import { LocationInfoDialogComponent } from './location-dialog/location-info-dialog/location-info-dialog.component';
import { LocationTableDialogComponent } from './location-dialog/location-table-dialog/location-table-dialog.component';

@NgModule({
  imports: [
    // angular
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    // customer Module
    SharedModule,
    CustomMaterialModule,
  ],
  declarations: [
    ErrorDialog,
    ConfirmDialog,
    ContextDialog,
    EmployeeDialogComponent,
    EmployeeTableComponent,
    ProjectDialogComponent,
    ProjectTableComponent,
    //WorkgroupDialogComponent,
    GroupmisDialogComponent,
    GroupmisTableComponent,
    ProjectDetailTableComponent,
    ProjectInfoComponent,
    ProjectSubDialogComponent,
    ProjectSubInfoComponent,
    GroupDialogComponent,
    GroupTableComponent,
    ConfirmMessageDialogComponent,
    CheckListDialogComponent,
    CheckListInfoDialogComponent,
    CheckListTableDialogComponent,
    EquipmentDialogComponent,
    EquipmentTableDialogComponent,
    EquipmentInfoDialogComponent,
    LocationDialogComponent,
    LocationInfoDialogComponent,
    LocationTableDialogComponent,
  ],
  providers: [
    DialogsService,
  ],
  // a list of components that are not referenced in a reachable component template.
  // doc url is :https://angular.io/guide/ngmodule-faq
  entryComponents: [
    ErrorDialog,
    ConfirmDialog,
    ContextDialog,
    GroupTableComponent,
    GroupDialogComponent,
    ProjectInfoComponent,
    GroupmisTableComponent,
    ProjectDialogComponent,
    EmployeeDialogComponent,
    GroupmisDialogComponent,
    ProjectSubInfoComponent,
    ProjectSubDialogComponent,
    ProjectDetailTableComponent,
    ConfirmMessageDialogComponent,
    CheckListDialogComponent,
    CheckListInfoDialogComponent,
    CheckListTableDialogComponent,
    EquipmentDialogComponent,
    EquipmentTableDialogComponent,
    EquipmentInfoDialogComponent,
    LocationDialogComponent,
    LocationInfoDialogComponent,
    LocationTableDialogComponent,
  ],
})
export class DialogsModule { }
