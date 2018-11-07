import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
import { BaseMasterComponent } from '../../shared/base-master-component';
import { ConfinedSpace } from '../shared/confined-space.model';
import { ConfinedSpaceService } from '../shared/confined-space.service';
import { ConfinedSpaceCommunicateService } from '../shared/confined-space-communicate.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { AuthService } from '../../core/auth/auth.service';
import { ConfinedSpaceTableComponent } from '../confined-space-table/confined-space-table.component';
import { StatusWorkPermit } from '../../shared/basemodel/status-work-permit.enum';

@Component({
  selector: 'app-confined-space-master',
  templateUrl: './confined-space-master.component.html',
  styleUrls: ['./confined-space-master.component.scss']
})
export class ConfinedSpaceMasterComponent extends BaseMasterComponent<ConfinedSpace, ConfinedSpaceService, ConfinedSpaceCommunicateService> {

  constructor(
    service: ConfinedSpaceService,
    serviceCom: ConfinedSpaceCommunicateService,
    serviceDialog: DialogsService,
    serviceAuth: AuthService,
    viewCon: ViewContainerRef,
  ) {
    super(service, serviceCom, serviceAuth, serviceDialog, viewCon);
  }
  backToSchedule: boolean = false;
  @ViewChild(ConfinedSpaceTableComponent)
  private tableComponent: ConfinedSpaceTableComponent;
  printInfoValue?: ConfinedSpace;

  onReloadData(): void {
    this.tableComponent.reloadData();
  }

  onCheckStatus(infoValue?: ConfinedSpace): boolean {
    if (this.authService.getAuth) {
      if (this.authService.getAuth.LevelUser < 3) {
        if (this.authService.getAuth.UserName !== infoValue.Creator) {
          this.dialogsService.error("Access Denied", "You don't have permission to access.", this.viewContainerRef);
          return false;
        }

        if (infoValue.StatusWorkPermit != StatusWorkPermit.Require) {
          this.dialogsService.error("Access Deny", "You don't have permission to access", this.viewContainerRef);
          return false;
        }
      }
    }
    return true;
  }

  // on detail view
  onDetailView(value?: { data: ConfinedSpace, option: number }): void {
    if (value) {
      if (value.option === 1 || value.option === 2 || value.option === 5) {
        this.displayValue = value.data;
        this.displayValue.ReadOnly = value.option === 2;
        this.displayValue.Copying = value.option === 5;
        // Check status can edit if not readonly
        if (!this.displayValue.ReadOnly && !this.displayValue.Copying) {
          if (!this.onCheckStatus(this.displayValue)) {
            return;
          }
        }
        this.onLoading = true;
        this.ShowDetail = true;
        setTimeout(() => {
          this.communicateService.toChildEdit(this.displayValue);
          this.onLoading = false;
        }, 1000);
      }
      else if (value.option === 3) // Print
      {
        this.onLoading = true;
        this.service.getXlsx(value.data.ConfinedSpaceWorkPermitId).subscribe(data => {
          // console.log(data);
          this.onLoading = false;
        }, (error) => this.onLoading = false, () => this.onLoading = false);
      }
      else if (value.option === 4) // Send Mail
      {
        if (!this.onCheckStatus(value.data)) {
          return;
        }

        this.onLoading = true;
        this.service.getResendMail(value.data.ConfinedSpaceWorkPermitId).subscribe(data => {
          // console.log(data);
          this.onReloadData();
          this.onLoading = false;
        }, (error) => this.onLoading = false, () => this.onLoading = false);
      }
      else if (value.option === 0) {
        if (!this.onCheckStatus(value.data)) {
          return;
        }
        this.onLoading = true;
        this.dialogsService.confirm("Warning Message", "Do you want delete this item?", this.viewContainerRef)
          .subscribe(result => {
            if (result) {
              this.service.deleteKeyNumber(value.data)
                .subscribe(dbData => { }, error => { }, () => {
                  this.onLoading = false;
                  this.onReloadData();
                });
            } else {
              this.onLoading = false;
            }
          });
        this.canSave = false;
      }
    }
    else {
      this.displayValue = undefined;
      this.ShowDetail = true;
      setTimeout(() => this.communicateService.toChildEdit(this.displayValue), 1000);
    }
  }

  //onPrintView(infoValue?: ConfinedSpace): void {
  //  console.log(JSON.stringify(infoValue));
  //  if (infoValue) {
  //    this.printInfoValue = infoValue;
  //  } else {
  //    this.printInfoValue = undefined;
  //  }
  //}

  //printComponent() {
  //  if (this.printInfoValue) {
  //    this.onLoading = true;
  //    this.service.getXlsx(this.printInfoValue.ConfinedSpaceWorkPermitId).subscribe(data => {
  //      // console.log(data);
  //      this.onLoading = false;
  //    }, (error) => this.onLoading = false, () => this.onLoading = false);
  //  }
  //}
}
