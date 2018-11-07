import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
import { BaseMasterComponent } from '../../shared/base-master-component';
import { Safety } from '../shared/safety.model';
import { SafetyService } from '../shared/safety.service';
import { SafetyCommunicateService } from '../shared/safety-communicate.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { AuthService } from '../../core/auth/auth.service';
import { SafetyTableComponent } from '../safety-table/safety-table.component';

@Component({
  selector: 'app-safety-master',
  templateUrl: './safety-master.component.html',
  styleUrls: ['./safety-master.component.scss']
})
export class SafetyMasterComponent extends BaseMasterComponent<Safety, SafetyService, SafetyCommunicateService> {

  constructor(
    service: SafetyService,
    serviceCom: SafetyCommunicateService,
    serviceDialog: DialogsService,
    serviceAuth: AuthService,
    viewCon: ViewContainerRef,
  ) {
    super(service, serviceCom, serviceAuth, serviceDialog, viewCon);
  }
  backToSchedule: boolean = false;
  @ViewChild(SafetyTableComponent)
  private tableComponent: SafetyTableComponent;

  onReloadData(): void {
    this.tableComponent.reloadData();
  }

  onCheckStatus(infoValue?: Safety): boolean {
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
