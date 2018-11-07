// Angular Core
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
// Components
import { BaseInfoComponent } from '../../shared/base-info-component';
// Services
import { ApprovdFlowService } from '../shared/approvd-flow.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { ApprovdFlowDetailService } from '../shared/approvd-flow-detail.service';
import { ApprovdFlowCommunicateService } from '../shared/approvd-flow-communicate.service';
// Models
import { ApprovdFlow } from '../shared/approvd-flow.model';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { ApprovdFlowDetail } from '../shared/approvd-flow-detail.model';

@Component({
  selector: 'app-approved-info',
  templateUrl: './approved-info.component.html',
  styleUrls: ['./approved-info.component.scss']
})
export class ApprovedInfoComponent extends
  BaseInfoComponent<ApprovdFlow, ApprovdFlowService, ApprovdFlowCommunicateService> {
  constructor(
    service: ApprovdFlowService,
    serviceCom: ApprovdFlowCommunicateService,
    private serviceFlowDetailService: ApprovdFlowDetailService,
    private serviceDialog: DialogsService,
    private fb: FormBuilder,
    private viewContainer: ViewContainerRef,
  ) {
    super(service, serviceCom);
  }

  // on get data
  onGetDataByKey(InfoValue: ApprovdFlow): void {
    if (InfoValue && InfoValue.ApprovedFlowMasterId) {
      this.service.getOneKeyNumber(InfoValue)
        .subscribe(dbData => {
          this.InfoValue = dbData;
          if (this.InfoValue) {
            this.serviceFlowDetailService.getByMasterId(this.InfoValue.ApprovedFlowMasterId)
              .subscribe(dbData => {
                if (dbData) {
                  this.InfoValue.ApprovedFlowDetails = dbData;

                  this.InfoValueForm.patchValue({
                    ApprovedFlowDetails: dbData
                  });
                }
              });
          }
        }, error => console.error(error), () => this.buildForm());
    } else {
      this.InfoValue = {
        ApprovedFlowMasterId: 0,
        ApprovedFlowDetails: new Array
      };
      this.buildForm();
    }
  }

  //BulidForm
  buildForm(): void {
    this.InfoValueForm = this.fb.group({
      ApprovedFlowMasterId: [this.InfoValue.ApprovedFlowMasterId],
      ApprovedByEmp: [this.InfoValue.ApprovedByEmp],
      ApprovedByNameThai: new FormControl(
        {
          value: this.InfoValue.ApprovedByNameThai,
          disabled: this.denySave
        },
        Validators.required
      ),
      ApprovedByMail: new FormControl(
        {
          value: this.InfoValue.ApprovedByMail,
          disabled: this.denySave,
        },
        Validators.maxLength(200)
      ),
      ApprovedFlowDetails: new FormControl(
        {
          value: this.InfoValue.ApprovedFlowDetails,
          disabled: this.denySave,
        },
        Validators.required
      ),
      // BaseModel
      Creator: [this.InfoValue.Creator],
      CreateDate: [this.InfoValue.CreateDate],
      Modifyer: [this.InfoValue.Modifyer],
      ModifyDate: [this.InfoValue.ModifyDate],
    });
    this.InfoValueForm.valueChanges.pipe(debounceTime(250), distinctUntilChanged()).subscribe(data => this.onValueChanged(data));

    if (this.InfoValueForm) {
      Object.keys(this.InfoValueForm.controls).forEach(field => {
        const control = this.InfoValueForm.get(field);
        control.markAsTouched({ onlySelf: true });
      });
    }
  }

  // On JobcardDetail
  OnDetailSelect(Item: { data?: ApprovdFlowDetail, option: number }) {
    if (this.denySave) {
      return;
    }
    if (Item.option === 1) {
      this.serviceDialog.dialogSelectGroupMises(this.viewContainer)
        .subscribe(groupMis => {
          if (groupMis) {
            groupMis.forEach(item => {
              if (!this.InfoValue.ApprovedFlowDetails.find(detail => detail.GroupMis === item.GroupMIS)) {
                this.InfoValue.ApprovedFlowDetails.push({
                  ApprovedFlowMasterId: this.InfoValue.ApprovedFlowMasterId,
                  ApprovedFlowDetailId: 0,
                  GroupMis: item.GroupMIS,
                  GroupMisName: item.GroupDesc,
                });
                this.InfoValue.ApprovedFlowDetails = this.InfoValue.ApprovedFlowDetails.slice();
                // Update to form
                this.InfoValueForm.patchValue({
                  ApprovedFlowDetails: this.InfoValue.ApprovedFlowDetails
                });
              }
            });
          }
        });
    } else if (Item.option === 0) // Remove
    {
      let indexItem = this.InfoValue.ApprovedFlowDetails.indexOf(Item.data);
      this.InfoValue.ApprovedFlowDetails.splice(indexItem, 1);
      this.InfoValue.ApprovedFlowDetails = this.InfoValue.ApprovedFlowDetails.slice();
      // Update to form
      this.InfoValueForm.patchValue({
        ApprovedFlowDetails: this.InfoValue.ApprovedFlowDetails
      });
    }
  }

  // Open Dialog
  openDialog(type?: string): void {
    if (this.denySave) {
      return;
    }

    if (type) {
      if (type.indexOf("GroupMis") !== -1) {
        this.serviceDialog.dialogSelectGroupMises(this.viewContainer)
          .subscribe(groupMis => {
            if (groupMis) {
              groupMis.forEach(item => {
                if (!this.InfoValue.ApprovedFlowDetails.find(detail => detail.GroupMis === item.GroupMIS)) {
                  this.InfoValue.ApprovedFlowDetails.push({
                    ApprovedFlowMasterId: this.InfoValue.ApprovedFlowMasterId,
                    ApprovedFlowDetailId: 0,
                    GroupMis: item.GroupMIS,
                    GroupMisName: item.GroupDesc,
                  });
                }
              });
            }
          });
      } else if (type.indexOf("Employee") !== -1) {
        this.serviceDialog.dialogSelectEmployee(this.viewContainer)
          .subscribe(employee => {
            this.InfoValueForm.patchValue({
              ApprovedByEmp: employee ? employee.EmpCode : undefined,
              ApprovedByNameThai: employee ? employee.NameThai : undefined,
            });
          });
      }
    }
  }

}
