import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
import { BaseMasterComponent } from '../../shared/base-master-component';
import { ApprovdFlow } from '../shared/approvd-flow.model';
import { ApprovdFlowService } from '../shared/approvd-flow.service';
import { ApprovdFlowCommunicateService } from '../shared/approvd-flow-communicate.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { AuthService } from '../../core/auth/auth.service';
import { ApprovedTableComponent } from '../approved-table/approved-table.component';

@Component({
  selector: 'app-approved-master',
  templateUrl: './approved-master.component.html',
  styleUrls: ['./approved-master.component.scss']
})
export class ApprovedMasterComponent
  extends BaseMasterComponent<ApprovdFlow, ApprovdFlowService, ApprovdFlowCommunicateService> {

  constructor(
    service: ApprovdFlowService,
    serviceCom: ApprovdFlowCommunicateService,
    serviceDialog: DialogsService,
    serviceAuth: AuthService,
    viewCon: ViewContainerRef,
  ) {
    super(service, serviceCom, serviceAuth, serviceDialog, viewCon);
  }
  backToSchedule: boolean = false;
  @ViewChild(ApprovedTableComponent)
  private tableComponent: ApprovedTableComponent;

  onReloadData(): void {
    this.tableComponent.reloadData();
  }

  onCheckStatus(infoValue?: ApprovdFlow): boolean {
    if (this.authService.getAuth) {
      if (this.authService.getAuth.LevelUser < 2) {
        if (this.authService.getAuth.UserName !== infoValue.Creator) {
          this.dialogsService.error("Access Denied", "You don't have permission to access.", this.viewContainerRef);
          return false;
        }
      }
    }
    return true;
  }
}
