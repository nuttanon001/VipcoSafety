import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseInfoComponent } from '../../shared/base-info-component';
import { GroupworkPermit } from '../shared/groupwork-permit.model';
import { GroupworkPermitService } from '../shared/groupwork-permit.service';
import { GroupworkPermitCommunicateService } from '../shared/groupwork-permit-communicate.service';
import { PermitHasChecklistService } from '../shared/permit-has-checklist.service';
import { PermitHasEquipmentService } from '../shared/permit-has-equipment.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { distinctUntilChanged, debounceTime } from 'rxjs/operators';
import { PermitHasChecklist } from '../shared/permit-has-checklist';
import { PermitHasEquipment } from '../shared/permit-has-equipment';
import { CheckList } from '../shared/check-list.model';
import { Equipment } from '../shared/equipment.model';

@Component({
  selector: 'app-groupwork-permit-info',
  templateUrl: './groupwork-permit-info.component.html',
  styleUrls: ['./groupwork-permit-info.component.scss']
})
export class GroupworkPermitInfoComponent extends
  BaseInfoComponent<GroupworkPermit, GroupworkPermitService, GroupworkPermitCommunicateService> {
  constructor(
    service: GroupworkPermitService,
    serviceCom: GroupworkPermitCommunicateService,
    private serviceHasChecklist: PermitHasChecklistService,
    private serviceHasEquipment: PermitHasEquipmentService,
    private serviceDialogs: DialogsService,
    private fb: FormBuilder,
    private viewContainer: ViewContainerRef,
  ) {
    super(service, serviceCom);
  }
  // on get data
  onGetDataByKey(InfoValue: GroupworkPermit): void {
    if (InfoValue && InfoValue.GroupWorkPermitId) {
      this.service.getOneKeyNumber(InfoValue)
        .subscribe(dbData => {
          this.InfoValue = dbData;
          if (this.InfoValue) {
            this.serviceHasChecklist.getByMasterId(this.InfoValue.GroupWorkPermitId)
              .subscribe(dbData => {
                if (dbData) {

                  let newPermitHasChecks: Array<PermitHasChecklist> = new Array;
                  dbData.forEach(item => {
                    newPermitHasChecks.push({
                      CheckListId: item.CheckListId,
                      CheckListNameEng: item.CheckListNameEng,
                      CheckListNameThai: item.CheckListNameThai,
                      CreateDate: item.CreateDate,
                      Creator: item.Creator,
                      GroupHasCheckId: item.GroupHasCheckId,
                      GroupWorkPermitId: item.GroupWorkPermitId,
                      ModifyDate: item.ModifyDate,
                      Modifyer: item.Modifyer,
                      OptionValue: item.OptionValue,
                      ReadOnly: item.ReadOnly,
                      SequenceNo: item.SequenceNo
                    });
                  });

                  this.InfoValue.GroupPermitHasCheckList = newPermitHasChecks;
                  this.InfoValueForm.patchValue({
                    GroupPermitHasCheckList: newPermitHasChecks
                  });
                }
              });

            this.serviceHasEquipment.getByMasterId(this.InfoValue.GroupWorkPermitId)
              .subscribe(dbData => {
                if (dbData) {

                  let newPermitHasEquip: Array<PermitHasEquipment> = new Array;
                  dbData.forEach(item => {
                    newPermitHasEquip.push({
                      SafetyEquipmentId: item.SafetyEquipmentId,
                      SafetyEquipmentNameEng: item.SafetyEquipmentNameEng,
                      SafetyEquipmentNameThai: item.SafetyEquipmentNameThai,
                      CreateDate: item.CreateDate,
                      Creator: item.Creator,
                      GroupHasEquipId: item.GroupHasEquipId,
                      GroupWorkPermitId: item.GroupWorkPermitId,
                      ModifyDate: item.ModifyDate,
                      Modifyer: item.Modifyer,
                      OptionValue: item.OptionValue,
                      ReadOnly: item.ReadOnly,
                      SequenceNo: item.SequenceNo,
                    });
                  });

                  this.InfoValue.GroupPermitHasEquipments = newPermitHasEquip;
                  this.InfoValueForm.patchValue({
                    GroupPermitHasEquipments: newPermitHasEquip
                  });
                }
              });
          }
        }, error => console.error(error), () => this.buildForm());
    } else {
      this.InfoValue = {
        GroupWorkPermitId: 0,
        GroupPermitHasCheckList: new Array,
        GroupPermitHasEquipments: new Array,
      };
      this.buildForm();
    }
  }
  //BulidForm
  buildForm(): void {
    this.InfoValueForm = this.fb.group({
      GroupWorkPermitId: [this.InfoValue.GroupWorkPermitId],
      Name: new FormControl(
        {
          value: this.InfoValue.Name,
          disabled: this.denySave
        },
        [Validators.required,Validators.maxLength(150)]
      ),
      Description: new FormControl(
        {
          value: this.InfoValue.Description,
          disabled: this.denySave
        },
        [Validators.maxLength(200)]
      ),
      Status: [this.InfoValue.Status],
      GroupPermitHasCheckList: new FormControl(
        {
          value: this.InfoValue.GroupPermitHasCheckList,
          disabled: this.denySave,
        },
        Validators.required
      ),
      GroupPermitHasEquipments: new FormControl(
        {
          value: this.InfoValue.GroupPermitHasEquipments,
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
  // OnDetailPermitCheckListSelect
  OnDetailPermitCheckListSelect(Item: { data?: PermitHasChecklist, option: number }) {
    if (this.denySave) {
      return;
    }
    let indexItem = -1;

    if (Item) {
      if (Item.data) {
        indexItem = this.InfoValue.GroupPermitHasCheckList.indexOf(Item.data);
      }

      if (Item.option === 1) {
        let detailInfoValue: PermitHasChecklist;
        // IF Edit data
        if (Item.data) {
          detailInfoValue = Object.assign({}, Item.data);
        } else { // Else New data
          detailInfoValue = {
            GroupHasCheckId: 0,
            SequenceNo: this.InfoValue.GroupPermitHasCheckList.length + 1
          };
        }
        if (indexItem > -1) {
          //this.serviceDialogs.dialogInfoCheckList(this.viewContainer)
          //  .subscribe((info: CheckList) => {
          //    if (info) {
          //      if (!this.InfoValue.GroupPermitHasCheckList.find(item => item.CheckListId === info.CheckListId)) {
          //        if (indexItem > -1) {
          //          // remove item
          //          this.InfoValue.GroupPermitHasCheckList.splice(indexItem, 1);
          //        }
          //        detailInfoValue.CheckListId = info.CheckListId;
          //        detailInfoValue.CheckListNameEng = info.NameEng;
          //        detailInfoValue.CheckListNameThai = info.NameThai;
          //        this.InfoValue.GroupPermitHasCheckList.push(Object.assign({}, detailInfoValue));
          //        this.InfoValue.GroupPermitHasCheckList = this.InfoValue.GroupPermitHasCheckList.slice();
          //        // Update to form
          //        this.InfoValueForm.patchValue({
          //          GroupPermitHasCheckList: this.InfoValue.GroupPermitHasCheckList
          //        });
          //      }
          //    }
          //  });
        } else {
          this.serviceDialogs.dialogInfoCheckList(this.viewContainer,1)
            .subscribe((info: Array<CheckList>) => {
              if (info) {
                
                info.forEach((item) => {
                  if (!this.InfoValue.GroupPermitHasCheckList.find(item2 => item2.CheckListId === item.CheckListId)) {
                    let tempInfo = {
                      GroupHasCheckId: 0,
                      SequenceNo: this.InfoValue.GroupPermitHasCheckList.length + 1,
                      CheckListId: item.CheckListId,
                      CheckListNameEng: item.NameEng,
                      CheckListNameThai: item.NameThai,
                    };
                    this.InfoValue.GroupPermitHasCheckList.push(Object.assign({}, tempInfo));
                  }
                });

                this.InfoValue.GroupPermitHasCheckList = this.InfoValue.GroupPermitHasCheckList.slice();
                // Update to form
                this.InfoValueForm.patchValue({
                  GroupPermitHasCheckList: this.InfoValue.GroupPermitHasCheckList
                });
              }
            });
        }
      }
      else if (Item.option === 2) {
        let upSeq = Item.data.UpdateSequenceNo;
        let curSeq = Item.data.SequenceNo;
        this.InfoValue.GroupPermitHasCheckList.forEach((info, index) => {
          let tempSequenceNo = info.SequenceNo;

          if (tempSequenceNo === upSeq) {
            // console.log("SequenceNo", info.SequenceNo, curSeq);
            info.SequenceNo = curSeq;
          }

          if (tempSequenceNo === curSeq) {
            // console.log("UpdateSequenceNo", info.SequenceNo, upSeq);
            info.SequenceNo = upSeq;
          }
        });
        this.InfoValue.GroupPermitHasCheckList.sort((a, b) => a.SequenceNo - b.SequenceNo)
        this.InfoValue.GroupPermitHasCheckList = this.InfoValue.GroupPermitHasCheckList.slice();
        // Update to form
        this.InfoValueForm.patchValue({
          GroupPermitHasCheckList: this.InfoValue.GroupPermitHasCheckList
        });
      }
      else if (Item.option === 0) // Remove
      {
        let curSeq = Item.data.SequenceNo;
        this.InfoValue.GroupPermitHasCheckList.splice(indexItem, 1);

        if (curSeq <= this.InfoValue.GroupPermitHasCheckList.length) {
          this.InfoValue.GroupPermitHasCheckList.forEach(item => {
            if (item.SequenceNo > curSeq) {
              item.SequenceNo -= 1;
            }
          });
        }
        this.InfoValue.GroupPermitHasCheckList = this.InfoValue.GroupPermitHasCheckList.slice();
        // Update to form
        this.InfoValueForm.patchValue({
          GroupPermitHasCheckList: this.InfoValue.GroupPermitHasCheckList
        });
      }
    }
  }
  // OnDetailPermitEquipmentSelect
  OnDetailPermitEquipmentSelect(Item: { data?: PermitHasEquipment, option: number }) {
    if (this.denySave) {
      return;
    }
    let indexItem = -1;

    if (Item) {
      if (Item.data) {
        indexItem = this.InfoValue.GroupPermitHasEquipments.indexOf(Item.data);
      }

      if (Item.option === 1) {
        let detailInfoValue: PermitHasEquipment;
        // IF Edit data
        if (Item.data) {
          detailInfoValue = Object.assign({}, Item.data);
        } else { // Else New data
          detailInfoValue = {
            GroupHasEquipId: 0,
            SequenceNo: this.InfoValue.GroupPermitHasEquipments.length + 1
          };
        }
        // console.log(JSON.stringify(Item.option));

        if (indexItem > -1) {
          //this.serviceDialogs.dialogInfoEquipment(this.viewContainer)
          //  .subscribe((info: Equipment) => {
          //    if (info) {
          //      if (!this.InfoValue.GroupPermitHasEquipments.find(item => item.SafetyEquipmentId == info.SafetyEquipmentId)) {
          //        if (indexItem > -1) {
          //          // remove item
          //          this.InfoValue.GroupPermitHasEquipments.splice(indexItem, 1);
          //        }
          //        detailInfoValue.SafetyEquipmentId = info.SafetyEquipmentId;
          //        detailInfoValue.SafetyEquipmentNameEng = info.NameEng;
          //        detailInfoValue.SafetyEquipmentNameThai = info.NameThai;
          //        this.InfoValue.GroupPermitHasEquipments.push(Object.assign({}, detailInfoValue));
          //        this.InfoValue.GroupPermitHasEquipments = this.InfoValue.GroupPermitHasEquipments.slice();
          //        // Update to form
          //        this.InfoValueForm.patchValue({
          //          GroupPermitHasEquipments: this.InfoValue.GroupPermitHasEquipments
          //        });
          //      }
          //    }
          //  });
        } else {
          this.serviceDialogs.dialogInfoEquipment(this.viewContainer, 1)
            .subscribe((info: Array<Equipment>) => {
              if (info) {
                info.forEach((item) => {
                  if (!this.InfoValue.GroupPermitHasEquipments.find(item2 => item2.SafetyEquipmentId == item.SafetyEquipmentId)) {
                    let tempInfo = {
                      GroupHasCheckId: 0,
                      SequenceNo: this.InfoValue.GroupPermitHasEquipments.length + 1,
                      SafetyEquipmentId: item.SafetyEquipmentId,
                      SafetyEquipmentNameEng: item.NameEng,
                      SafetyEquipmentNameThai: item.NameThai,
                    };
                    this.InfoValue.GroupPermitHasEquipments.push(Object.assign({}, tempInfo));
                  }
                });

                this.InfoValue.GroupPermitHasEquipments = this.InfoValue.GroupPermitHasEquipments.slice();
                // Update to form
                this.InfoValueForm.patchValue({
                  GroupPermitHasEquipments: this.InfoValue.GroupPermitHasEquipments
                });
              }
            });
        }
      }
      else if (Item.option === 2) {
        let upSeq = Item.data.UpdateSequenceNo;
        let curSeq = Item.data.SequenceNo;
        this.InfoValue.GroupPermitHasEquipments.forEach((info, index) => {
          let tempSequenceNo = info.SequenceNo;

          if (tempSequenceNo === upSeq) {
            // console.log("SequenceNo", info.SequenceNo, curSeq);
            info.SequenceNo = curSeq;
          }

          if (tempSequenceNo === curSeq) {
            // console.log("UpdateSequenceNo", info.SequenceNo, upSeq);
            info.SequenceNo = upSeq;
          }
        });
        this.InfoValue.GroupPermitHasEquipments.sort((a, b) => a.SequenceNo - b.SequenceNo)
        this.InfoValue.GroupPermitHasEquipments = this.InfoValue.GroupPermitHasEquipments.slice();
        // Update to form
        this.InfoValueForm.patchValue({
          GroupPermitHasEquipments: this.InfoValue.GroupPermitHasEquipments
        });
      }
      else if (Item.option === 0) // Remove
      {
        let curSeq = Item.data.SequenceNo;
        this.InfoValue.GroupPermitHasEquipments.splice(indexItem, 1);

        if (curSeq <= this.InfoValue.GroupPermitHasEquipments.length) {
          this.InfoValue.GroupPermitHasEquipments.forEach(item => {
            if (item.SequenceNo > curSeq) {
              item.SequenceNo -= 1;
            }
          });
        }

        this.InfoValue.GroupPermitHasEquipments = this.InfoValue.GroupPermitHasEquipments.slice();
        // Update to form
        this.InfoValueForm.patchValue({
          GroupPermitHasEquipments: this.InfoValue.GroupPermitHasEquipments
        });
      }
    }
  }
}
