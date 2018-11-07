import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
import { BaseMasterComponent } from '../../shared/base-master-component';
import { GroupworkPermit } from '../shared/groupwork-permit.model';
import { GroupworkPermitService } from '../shared/groupwork-permit.service';
import { GroupworkPermitCommunicateService } from '../shared/groupwork-permit-communicate.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { AuthService } from '../../core/auth/auth.service';
import { GroupworkPermitTableComponent } from '../groupwork-permit-table/groupwork-permit-table.component';

@Component({
  selector: 'app-groupwork-permit-master',
  templateUrl: './groupwork-permit-master.component.html',
  styleUrls: ['./groupwork-permit-master.component.scss']
})
export class GroupworkPermitMasterComponent
  extends BaseMasterComponent<GroupworkPermit, GroupworkPermitService, GroupworkPermitCommunicateService> {

  constructor(
    service: GroupworkPermitService,
    serviceCom: GroupworkPermitCommunicateService,
    serviceDialog: DialogsService,
    serviceAuth: AuthService,
    viewCon: ViewContainerRef,
  ) {
    super(service, serviceCom, serviceAuth, serviceDialog, viewCon);
  }
  backToSchedule: boolean = false;
  @ViewChild(GroupworkPermitTableComponent)
  private tableComponent: GroupworkPermitTableComponent;

  onReloadData(): void {
    this.tableComponent.reloadData();
  }

  onCheckStatus(infoValue?: GroupworkPermit): boolean {
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
