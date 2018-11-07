// Angular Core
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Component, OnInit, ViewContainerRef, ViewChild, OnDestroy } from '@angular/core';
import { BaseInfoComponent } from '../../shared/base-info-component';
// Services
import { ShareService } from '../../shared/share.service';
import { AuthService } from '../../core/auth/auth.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { ConfinedSpaceService } from '../shared/confined-space.service';
import { ConfinedSpacePerService } from '../shared/confined-space-per.service';
import { ConfinedSpaceCheckService } from '../shared/confined-space-check.service';
import { ConfinedSpaceEquipService } from '../shared/confined-space-equip.service';
import { EmployeeGroupService } from '../../employees/shared/employee-group.service';
import { ConfinedSpaceEmphelpService } from '../shared/confined-space-emphelp.service';
import { ConfinedSpaceEmpworkService } from '../shared/confined-space-empwork.service';
import { ConfinedSpaceCommunicateService } from '../shared/confined-space-communicate.service';
import { PermitHasChecklistService } from '../../groupwork-permits/shared/permit-has-checklist.service';
import { PermitHasEquipmentService } from '../../groupwork-permits/shared/permit-has-equipment.service';
// Models
import { ConfinedSpace } from '../shared/confined-space.model';
import { ConfinedSpacePer } from '../shared/confined-space-per.model';
import { ConfinedSpaceCheck } from '../shared/confined-space-check.model';
import { ConfinedSpaceEquip } from '../shared/confined-space-equip.model';
import { FieldConfig } from '../../shared/dynamic-form/field-config.model';
import { ConfinedSpaceEmphelp } from '../shared/confined-space-emphelp.model';
import { ConfinedSpaceEmpwork } from '../shared/confined-space-empwork.model';
import { StatusWorkPermit } from '../../shared/basemodel/status-work-permit.enum';
// Components
import { DynamicFormComponent } from '../../shared/dynamic-form/dynamic-form/dynamic-form.component';
import { Subscription } from 'rxjs';
import { Location } from '../../locations/shared/location.model';

@Component({
  selector: 'app-confined-space-info',
  templateUrl: './confined-space-info.component.html',
  styleUrls: [ './confined-space-info.component.scss' ],
  providers: [EmployeeGroupService, ShareService ]
})
export class ConfinedSpaceInfoComponent extends
  BaseInfoComponent<ConfinedSpace, ConfinedSpaceService, ConfinedSpaceCommunicateService> implements OnDestroy {
  constructor(
    service: ConfinedSpaceService,
    serviceCom: ConfinedSpaceCommunicateService,
    private serviceShared: ShareService,
    private serviceHasPer: ConfinedSpacePerService,
    private serviceHasChecklist: ConfinedSpaceCheckService,
    private serviceHasEquipment: ConfinedSpaceEquipService,
    private serviceHasEmpHelp: ConfinedSpaceEmphelpService,
    private serviceHasEmpWork: ConfinedSpaceEmpworkService,
    private servicePermitHasChecklist: PermitHasChecklistService,
    private servicePermitHasEquipment: PermitHasEquipmentService,
    private serviceGroup: EmployeeGroupService,
    private serviceDialogs: DialogsService,
    private serviceAuth: AuthService,
    private fb: FormBuilder,
    private viewContainer: ViewContainerRef,
  ) {
    super(service, serviceCom);
  }
  // Parameter
  @ViewChild(DynamicFormComponent) form: DynamicFormComponent;
  // Template
  subscription2: Subscription;
  regConfig: Array<FieldConfig>;
  groupCode: string;
  isValid: boolean = false;
  isCopying: boolean = false;
  // OnGetData
  onGetDataByKey(InfoValue: ConfinedSpace): void {
    if (InfoValue && InfoValue.ConfinedSpaceWorkPermitId)
    {
      this.isCopying = InfoValue.Copying;
      this.service.getOneKeyNumber(InfoValue)
        .subscribe(dbData => {
          this.InfoValue = dbData;
          if (this.InfoValue) {
            // Get Checklist for ConfinedSpaced workpermit
            this.serviceHasChecklist.getByMasterId(this.InfoValue.ConfinedSpaceWorkPermitId)
              .subscribe(dbData => {
                if (dbData) {
                  let newConfinedHasChecks: Array<ConfinedSpaceCheck> = new Array;
                  dbData.forEach(item => {
                    newConfinedHasChecks.push({
                      CheckListId: item.CheckListId,
                      CheckListNameEng: item.CheckListNameEng,
                      CheckListNameThai: item.CheckListNameThai,
                      ConfinedHasCheckListId: this.isCopying ? undefined : item.ConfinedHasCheckListId,
                      ConfinedSpacePermitId: this.isCopying ? undefined : item.ConfinedSpacePermitId,
                      CreateDate: this.isCopying ? undefined : item.CreateDate,
                      Creator: this.isCopying ? undefined : item.Creator,
                      HasCheck: item.HasCheck,
                      ModifyDate: this.isCopying ? undefined : item.ModifyDate,
                      Modifyer: this.isCopying ? undefined : item.Modifyer
                    });
                  });
                  this.InfoValue.ConfinedHasCheckLists = newConfinedHasChecks;
                }
              });
            // Get Equipment for ConfinedSpaced workpermit
            this.serviceHasEquipment.getByMasterId(this.InfoValue.ConfinedSpaceWorkPermitId)
              .subscribe(dbData => {
                if (dbData) {
                  let newConfinedSpaceEquip: Array<ConfinedSpaceEquip> = new Array;
                  dbData.forEach(item => {
                    newConfinedSpaceEquip.push({
                      SafetyEquipmentId: item.SafetyEquipmentId,
                      SafetyEquipmentNameThai: item.SafetyEquipmentNameThai,
                      SafetyEquipmentNameEng: item.SafetyEquipmentNameEng,
                      ConfinedHasEquipId: this.isCopying ? undefined : item.ConfinedHasEquipId,
                      ConfinedSpacePermitId: this.isCopying ? undefined : item.ConfinedSpacePermitId,
                      CreateDate: this.isCopying ? undefined : item.CreateDate,
                      Creator: this.isCopying ? undefined : item.Creator,
                      HasCheck: item.HasCheck,
                      ModifyDate: this.isCopying ? undefined : item.ModifyDate,
                      Modifyer: this.isCopying ? undefined : item.Modifyer,
                    });
                  });
                  this.InfoValue.ConfinedHasEquips = newConfinedSpaceEquip;
                }
              });
            // Get EmployeeHelp for ConfinedSpaced workpermit
            this.serviceHasEmpHelp.getByMasterId(this.InfoValue.ConfinedSpaceWorkPermitId)
              .subscribe(dbData => {
                if (dbData) {
                  let newConfinedSpaceEmphelp: Array<ConfinedSpaceEmphelp> = new Array;
                  dbData.forEach(item => {
                    newConfinedSpaceEmphelp.push({
                      ConfinedHasEmpHelpId: this.isCopying ? undefined : item.ConfinedHasEmpHelpId,
                      EmpCode: item.EmpCode,
                      EmpNameThai: item.EmpNameThai,
                      ConfinedSpacePermitId: this.isCopying ? undefined : item.ConfinedSpacePermitId,
                      CreateDate: this.isCopying ? undefined : item.CreateDate,
                      Creator: this.isCopying ? undefined : item.Creator,
                      ModifyDate: this.isCopying ? undefined : item.ModifyDate,
                      Modifyer: this.isCopying ? undefined : item.Modifyer,
                    });
                  });
                  this.InfoValue.ConfinedHasEmpHelps = newConfinedSpaceEmphelp;
                }
              });
            // Get EmployeeWork for ConfinedSpaced workpermit
            this.serviceHasEmpWork.getByMasterId(this.InfoValue.ConfinedSpaceWorkPermitId)
              .subscribe(dbData => {
                if (dbData) {
                  let newConfinedSpaceEmpwork: Array<ConfinedSpaceEmpwork> = new Array;
                  dbData.forEach(item => {
                    newConfinedSpaceEmpwork.push({
                      ConfinedHasEmpWorkId: this.isCopying ? undefined : item.ConfinedHasEmpWorkId,
                      EmpCode: item.EmpCode,
                      EmpNameThai: item.EmpNameThai,
                      ConfinedSpacePermitId: this.isCopying ? undefined : item.ConfinedSpacePermitId,
                      CreateDate: this.isCopying ? undefined : item.CreateDate,
                      Creator: this.isCopying ? undefined : item.Creator,
                      ModifyDate: this.isCopying ? undefined : item.ModifyDate,
                      Modifyer: this.isCopying ? undefined : item.Modifyer,
                    });
                  });
                  this.InfoValue.ConfinedHasEmpWorks = newConfinedSpaceEmpwork;
                }
              });
            // Get Percaution for ConfinedSpaced workpermit
            this.serviceHasPer.getByMasterId(this.InfoValue.ConfinedSpaceWorkPermitId)
              .subscribe(dbData => {
                if (dbData) {
                  let newConfinedSpacePer: Array<ConfinedSpacePer> = new Array;
                  let RowIndex = 1;
                  dbData.forEach(item => {
                    newConfinedSpacePer.push({
                      ConfinedHasPreId: this.isCopying ? undefined : item.ConfinedHasPreId,
                      Description: item.Description,
                      Measure: item.Measure,
                      Remark: item.Remark,
                      Risk: item.Risk,
                      ConfinedSpaceWorkPermitId: this.isCopying ? undefined : item.ConfinedSpaceWorkPermitId,
                      CreateDate: this.isCopying ? undefined : item.CreateDate,
                      Creator: this.isCopying ? undefined : item.Creator,
                      ModifyDate: this.isCopying ? undefined : item.ModifyDate,
                      Modifyer: this.isCopying ? undefined : item.Modifyer,
                      RowIndex: RowIndex
                    });
                    RowIndex += 1;
                  });
                  this.InfoValue.ConfinedHasPrecautions = newConfinedSpacePer;
                }
              });
          }
        }, error => console.error(error), () => {
          if (this.isCopying) {
            this.InfoValue.ConfinedSpaceWorkPermitId = 0;
            this.InfoValue.StatusWorkPermit = StatusWorkPermit.Require;
            this.InfoValue.ApprovedDate = undefined;
            this.InfoValue.ComplateBy = undefined;
            this.InfoValue.ComplateByName = undefined;
            this.InfoValue.ComplateDate = undefined;
            this.InfoValue.ComplateTimeString = undefined;
            this.InfoValue.WpStartDate = undefined;
            this.InfoValue.WpStartTimeString = undefined;
            this.InfoValue.WpEndDate = undefined;
            this.InfoValue.WpEndTimeString = undefined;
            this.InfoValue.IsSendMail = undefined;
            this.InfoValue.CreateDate = undefined;
            this.InfoValue.Creator = undefined;
            this.InfoValue.ModifyDate = undefined;
            this.InfoValue.Modifyer = undefined;
            // get name require
            this.getNameRequire();
          }
          this.buildForm();
        });
    }
    else
    {
      this.InfoValue = {
        ConfinedSpaceWorkPermitId: 0,
        StatusWorkPermit: StatusWorkPermit.Require,
        ConfinedHasEmpWorks: new Array,
        ConfinedHasEmpHelps: new Array,
        ConfinedHasCheckLists: new Array,
        ConfinedHasEquips: new Array,
        ConfinedHasPrecautions:new Array,
        GroupWorkPermitId: 1,
        TypeWork: "Installation Work",
        HasHotWorkString: "No",
      };
      // get name require
      this.getNameRequire();

      this.servicePermitHasChecklist.getByMasterId(this.InfoValue.GroupWorkPermitId)
        .subscribe(dbData => {
          if (dbData) {
            let newConfinedHasChecks: Array<ConfinedSpaceCheck> = new Array;
            dbData.forEach(item => {
              newConfinedHasChecks.push({
                CheckListId: item.CheckListId,
                CheckListNameEng: item.CheckListNameEng,
                CheckListNameThai: item.CheckListNameThai,
                ConfinedHasCheckListId: 0,
                ConfinedSpacePermitId: 0,
                HasCheck: item.CheckListNameEng.indexOf("Isolation") === -1 ? true : false,
              });
            });
            this.InfoValue.ConfinedHasCheckLists = newConfinedHasChecks;
          }
        });

      this.servicePermitHasEquipment.getByMasterId(this.InfoValue.GroupWorkPermitId)
        .subscribe(dbData => {
          if (dbData) {
            let newConfinedSpaceEquip: Array<ConfinedSpaceEquip> = new Array;
            dbData.forEach(item => {
              newConfinedSpaceEquip.push({
                SafetyEquipmentId: item.SafetyEquipmentId,
                SafetyEquipmentNameThai: item.SafetyEquipmentNameThai,
                SafetyEquipmentNameEng: item.SafetyEquipmentNameEng,
                ConfinedHasEquipId: 0,
                ConfinedSpacePermitId: 0,
                HasCheck: false,
              });
            });
            this.InfoValue.ConfinedHasEquips = newConfinedSpaceEquip;
          }
        });

      this.buildForm();
    }

    // Observable
    this.FromComponents();
  }
  // get name require
  getNameRequire(): void {
    if (this.serviceAuth.getAuth) {
      this.InfoValue.RequireByEmpName = this.serviceAuth.getAuth.NameThai;
      this.InfoValue.RequireByEmpCode = this.serviceAuth.getAuth.EmpCode;
      this.InfoValue.RepayMail = this.serviceAuth.getAuth.MailAddress;
      if (this.InfoValue.RequireByEmpCode) {
        this.serviceGroup.getGroupByEmpCode(this.InfoValue.RequireByEmpCode)
          .subscribe(Group => {
            if (Group) {
              this.groupCode = Group.GroupCode;
              this.serviceShared.toChild(
                {
                  name: "SubContractor",
                  value: Group.Description
                });
            }
          });
      }
    }
  }
  // BulidForm
  buildForm(): void {
    this.regConfig = [
      // BasemodelRequireWorkpermit //
      //{
      //  type: "radiobutton",
      //  label: "Type of Work",
      //  name: "TypeWork",
      //  options: ["Installation Work", "Repair Work"],
      //  disabled: this.denySave,
      //  value: this.InfoValue.TypeWork,
      //  validations: [
      //    {
      //      name: "required",
      //      validator: Validators.required,
      //      message: "Require by is required"
      //    },
      //  ]
      //},
      {
        type: "checkbox",
        label: "Installation Work",
        name: "InstallWork",
        disabled: this.denySave,
        value: this.InfoValue.InstallWork,
      },
      {
        type: "checkbox",
        label: "Repair Work",
        name: "RepairWork",
        disabled: this.denySave,
        value: this.InfoValue.RepairWork,
      },
      {
        type: "input",
        label: "RequireByName",
        inputType: "text",
        name: "RequireByEmpName",
        disabled: this.denySave,
        value: this.InfoValue.RequireByEmpName,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "RequireName by is required"
          },
        ]
      },
      {
        type: "inputclick",
        label: "WorkGroup",
        inputType: "text",
        name: "SubContractor",
        disabled: this.denySave,
        value: this.InfoValue.SubContractor,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "SubContractor by is required"
          },
          {
            name: "maxlength",
            validator: Validators.maxLength(250),
            message: "Max length subcontractor is 250"
          },
        ]
      },
      {
        type: "inputclick",
        label: "Location",
        inputType: "text",
        name: "Location",
        disabled: this.denySave,
        value: this.InfoValue.Location,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Location by is required"
          },
          {
            name: "maxlength",
            validator: Validators.maxLength(200),
            message: "Max length location is 200"
          },
        ]
      },
      {
        type: "input",
        label: "Description",
        inputType: "text",
        name: "WorkDescription",
        disabled: this.denySave,
        value: this.InfoValue.WorkDescription,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Description is required"
          },
          {
            name: "maxlength",
            validator: Validators.maxLength(500),
            message: "Max length description is 500"
          },
        ]
      },
      {
        type: "date",
        label: "StartDate",
        name: "WpStartDate",
        disabled: this.denySave,
        value: this.InfoValue.WpStartDate,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Start date is required"
          }
        ]
      },
      {
        type: "input",
        label: "StartTime",
        inputType: "time",
        name: "WpStartTimeString",
        disabled: this.denySave,
        value: this.InfoValue.WpStartTimeString,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Start time is required"
          },
          //{
          //  name: "pattern",
          //  validator: Validators.pattern(
          //    "[/[0-2]/, /\d/,':',/[0-5]/, /\d/]"
          //  ),
          //  message: "Invalid time"
          //}
        ]
      },
      {
        type: "date",
        label: "FinishDate",
        name: "WpEndDate",
        disabled: this.denySave,
        value: this.InfoValue.WpEndDate,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Finish date is required"
          }
        ]
      },
      {
        type: "input",
        label: "FinishTime",
        inputType: "time",
        name: "WpEndTimeString",
        disabled: this.denySave,
        value: this.InfoValue.WpEndTimeString,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Finish time is required"
          },
          //{
          //  name: "pattern",
          //  validator: Validators.pattern(
          //    "[/[0-2]/, /\d/,':',/[0-5]/, /\d/]"
          //  ),
          //  message: "Invalid time"
          //}
        ]
      },
      {
        type: "input",
        label: "Total Worker",
        inputType: "number",
        name: "TotalWorker",
        disabled: this.denySave,
        value: this.InfoValue.TotalWorker,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Total worker is required"
          },
        ]
      },
      {
        type: "input",
        label: "Equipments/Tools",
        inputType: "text",
        name: "SpecialTool",
        disabled: this.denySave,
        value: this.InfoValue.SpecialTool,
        validations: [
          {
            name: "maxlength",
            validator: Validators.maxLength(500),
            message: "Max length equipments/toops is 500"
          },
        ]
      },
      {
        type: "input",
        label: "Repay mail",
        inputType: "mail",
        name: "RepayMail",
        disabled: this.denySave,
        value: this.InfoValue.RepayMail,
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Repay mail is required"
          },
        ]
      },
      {
        type: "radiobutton",
        label: "Applied hot work permit from",
        name: "HasHotWorkString",
        options: ["Yes", "No"],
        disabled: this.denySave,
        value: this.InfoValue.HasHotWorkString
      },
      {
        type: "input",
        label: "Hot WorkPermitNo",
        inputType: "text",
        name: "HotPermitNo",
        disabled: this.denySave,
        value: this.InfoValue.HotPermitNo,
        validations: [
          {
            name: "maxlength",
            validator: Validators.maxLength(50),
            message: "Max length hot workpermit no is 50"
          },
        ]
      },
      //{
      //  type: "radiobutton",
      //  label: "Applied hot work permit form",
      //  name: "TypeHotWork",
      //  options: ["Grinding", "Cutting", "Welding","Other"],
      //  disabled: this.denySave,
      //  value: this.InfoValue.TypeHotWork
      //},
      {
        type: "checkbox",
        label: "Grinding",
        name: "HotWorkGrinding",
        disabled: this.denySave,
        value: this.InfoValue.HotWorkGrinding,
      },
      {
        type: "checkbox",
        label: "Cutting",
        name: "HotWorkCutting",
        disabled: this.denySave,
        value: this.InfoValue.HotWorkCutting,
      },
      {
        type: "checkbox",
        label: "Welding",
        name: "HotWorkWelding",
        disabled: this.denySave,
        value: this.InfoValue.HotWorkWelding,
      },
      {
        type: "checkbox",
        label: "Other",
        name: "HotWorkOther",
        disabled: this.denySave,
        value: this.InfoValue.HotWorkOther,
      },

      {
        type: "input",
        label: "Other",
        inputType: "text",
        name: "HotWorkOtherString",
        disabled: this.denySave,
        value: this.InfoValue.HotWorkOtherString,
        validations: [
          {
            name: "maxlength",
            validator: Validators.maxLength(50),
            message: "Max length other is 50"
          },
        ]
      },
    ];

    // let ExcludeList = this.regConfig.map((item) => item.name);

    //ExcludeList.push("ConfinedHasEmpWorks");
    //ExcludeList.push("ConfinedHasEmpHelps");
    //ExcludeList.push("ConfinedHasCheckLists");
    //ExcludeList.push("ConfinedHasEquips");
    //ExcludeList.push("ConfinedHasPrecautions");

    //Object.keys(this.InfoValue).forEach((item, index) => {
    //  if (!ExcludeList.find((Exitem) => Exitem !== item)) {
    //    this.regConfig.push({
    //      type: "input",
    //      label: item,
    //      inputType: "text",
    //      name: item,
    //      disabled: this.denySave,
    //      hidden: true,
    //      value: this.InfoValue[item],
    //    });
    //  }
    //});
  }
  // Submit
  submitDynamicForm(value?: any): void {
    if (value) {
      if (!this.denySave) {
        let template = value as ConfinedSpace;
        // Template
        for (let key in template) {
          // console.log(key);
          if (key !== "ConfinedHasCheckLists" && key !== "ConfinedHasEmpHelps" &&
              key !== "ConfinedHasEmpWorks" && key !== "ConfinedHasEquips") {
            this.InfoValue[key] = template[key];
          }
        }

        // TypeWork
        this.InfoValue.InstallWork = this.InfoValue.TypeWork === "Installation Work";
        this.InfoValue.RepairWork = this.InfoValue.TypeWork === "Repair Work";
        // HotWork
        this.InfoValue.HasHotPermit = this.InfoValue.HasHotWorkString === "Yes";
        // HotWorkGrinding
        this.InfoValue.HotWorkGrinding = this.InfoValue.TypeHotWork === "Grinding";
        this.InfoValue.HotWorkCutting = this.InfoValue.TypeHotWork === "Cutting";
        this.InfoValue.HotWorkWelding = this.InfoValue.TypeHotWork === "Welding";
        this.InfoValue.HotWorkOther = this.InfoValue.TypeHotWork === "Other";
        // Set is valid
        this.isValid = true;
        this.SetCommunicatetoParent();
      }
    }
  }
  // Set communicateto parent
  SetCommunicatetoParent(): void {
    if (this.isValid && this.InfoValue.ConfinedHasCheckLists && this.InfoValue.ConfinedHasEmpHelps &&
      this.InfoValue.ConfinedHasEmpHelps && this.InfoValue.ConfinedHasEmpWorks && this.InfoValue.ConfinedHasPrecautions) {

      if (this.InfoValue.ConfinedHasCheckLists.length > 0 && this.InfoValue.ConfinedHasEmpHelps.length > 0 &&
        this.InfoValue.ConfinedHasEmpWorks.length > 0 && this.InfoValue.ConfinedHasEquips.length > 0 &&
        this.InfoValue.ConfinedHasPrecautions.length > 0) {
        // Communicate
        this.communicateService.toParent(this.InfoValue);
      }
    }
  }
  // Equipment
  OnEquipmentEvent(item: { data?: ConfinedSpaceEquip, option: number }): void {
    if (this.denySave) {
      return;
    }

    if (item) {
      if (item.data && item.option) {
        const confinedSpaceEquip = this.InfoValue.ConfinedHasEquips.filter(value => value.SafetyEquipmentId == item.data.SafetyEquipmentId);
        if (confinedSpaceEquip[0]) {
          confinedSpaceEquip[0].HasCheck = item.data.HasCheck;
        }
        this.InfoValue.ConfinedHasEquips = this.InfoValue.ConfinedHasEquips.slice();
        this.SetCommunicatetoParent();
      }
    }
  }
  // Check-kist
  OnCheckListEvent(item: { data?: ConfinedSpaceCheck, option: number }): void {
    if (this.denySave) {
      return;
    }

    if (item) {
      if (item.data && item.option) {
        const confinedSpaceCheck = this.InfoValue.ConfinedHasCheckLists.filter(value => value.CheckListId == item.data.CheckListId);
        if (confinedSpaceCheck[0]) {
          confinedSpaceCheck[0].HasCheck = item.data.HasCheck;
        }
        this.InfoValue.ConfinedHasCheckLists = this.InfoValue.ConfinedHasCheckLists.slice();
        this.SetCommunicatetoParent();
      }
    }
  }
  // Employee-Help
  OnEmployeeHelp(Item: { data?: ConfinedSpaceEmphelp, option: number }): void {
    if (this.denySave) {
      return;
    }

    if (Item.option === 1) {
      this.serviceDialogs.dialogSelectEmployees(this.viewContainer,this.groupCode)
        .subscribe(employee => {
          if (employee) {
            employee.forEach(item => {
              if (!this.InfoValue.ConfinedHasEmpHelps.find(detail => detail.EmpCode === item.EmpCode)) {
                this.InfoValue.ConfinedHasEmpHelps.push({
                  ConfinedHasEmpHelpId: 0,
                  EmpCode: item.EmpCode,
                  EmpNameThai: item.NameThai,
                  ConfinedSpacePermitId: this.InfoValue.ConfinedSpaceWorkPermitId,
                });
                this.InfoValue.ConfinedHasEmpHelps = this.InfoValue.ConfinedHasEmpHelps.slice();
                // Debug here
                // console.log(JSON.stringify(this.InfoValue.ConfinedHasEmpHelps));
              }
            });
            this.SetCommunicatetoParent();
          }
        });
    }
    else if (Item.option === 0) {
      let indexItem = this.InfoValue.ConfinedHasEmpHelps.indexOf(Item.data);
      this.InfoValue.ConfinedHasEmpHelps.splice(indexItem, 1);
      this.InfoValue.ConfinedHasEmpHelps = this.InfoValue.ConfinedHasEmpHelps.slice();
      this.SetCommunicatetoParent();
    }
  }
  // Employee-Work
  OnEmployeeWork(Item: { data?: ConfinedSpaceEmpwork, option: number }): void {
    if (this.denySave) {
      return;
    }
    if (Item.option === 1) {
      this.serviceDialogs.dialogSelectEmployees(this.viewContainer, this.groupCode)
        .subscribe(employee => {
          if (employee) {
            employee.forEach(item => {
              if (!this.InfoValue.ConfinedHasEmpWorks.find(detail => detail.EmpCode === item.EmpCode)) {
                this.InfoValue.ConfinedHasEmpWorks.push({
                  ConfinedHasEmpWorkId: 0,
                  EmpCode: item.EmpCode,
                  EmpNameThai: item.NameThai,
                  ConfinedSpacePermitId: this.InfoValue.ConfinedSpaceWorkPermitId,
                });
                this.InfoValue.ConfinedHasEmpWorks = this.InfoValue.ConfinedHasEmpWorks.slice();
                // Debug here
                // console.log(JSON.stringify(this.InfoValue.ConfinedHasEmpWorks));
              }
            });
            this.SetCommunicatetoParent();
          }
        });
    }
    else if (Item.option === 0) {
      let indexItem = this.InfoValue.ConfinedHasEmpWorks.indexOf(Item.data);
      this.InfoValue.ConfinedHasEmpWorks.splice(indexItem, 1);
      this.InfoValue.ConfinedHasEmpWorks = this.InfoValue.ConfinedHasEmpWorks.slice();
      this.SetCommunicatetoParent();
    }
  }
  // Precaution
  OnPrecaution(Item: { data?: ConfinedSpacePer, option: number }): void {
    if (this.denySave) {
      return;
    }
    if (Item.option === 1 && !Item.data)
    {
      let rowIndex = (this.InfoValue.ConfinedHasPrecautions.length || 0) + 1;

      this.InfoValue.ConfinedHasPrecautions.push({
        ConfinedHasPreId: 0,
        ConfinedSpaceWorkPermitId: this.InfoValue.ConfinedSpaceWorkPermitId,
        Measure: "",
        Risk: "",
        Description: "",
        Remark: "",
        RowIndex: rowIndex
      });
      this.InfoValue.ConfinedHasPrecautions = this.InfoValue.ConfinedHasPrecautions.slice();
      this.SetCommunicatetoParent();
    }
    else if (Item.option === 2)
    {
      const confinedSpacePercaution = this.InfoValue.ConfinedHasPrecautions.filter(value => value.RowIndex == Item.data.RowIndex);
      if (confinedSpacePercaution[0]) {
        confinedSpacePercaution[0].Risk = Item.data.Risk;
        confinedSpacePercaution[0].Measure = Item.data.Measure;
      }
      this.InfoValue.ConfinedHasPrecautions = this.InfoValue.ConfinedHasPrecautions.slice();
      this.SetCommunicatetoParent();
    }
    else if (Item.option === 0)
    {
      let indexItem = this.InfoValue.ConfinedHasPrecautions.indexOf(Item.data);
      this.InfoValue.ConfinedHasPrecautions.splice(indexItem, 1);
      this.InfoValue.ConfinedHasPrecautions = this.InfoValue.ConfinedHasPrecautions.slice();
      this.SetCommunicatetoParent();
    }
  }
  // From Components
  FromComponents(): void {
    this.subscription2 = this.serviceShared.ToParent$.subscribe(data => {
      if (data.name.indexOf("SubContractor") !== -1) {
        this.serviceDialogs.dialogSelectGroupMis(this.viewContainer)
          .subscribe(workGroup => {
            this.serviceShared.toChild(
              {
                name: data.name,
                value: workGroup.GroupDesc
              });
          });
      } else if (data.name.indexOf("Location") !== -1) {
        this.serviceDialogs.dialogInfoLocation(this.viewContainer)
          .subscribe((location: Location) => {
            this.serviceShared.toChild(
              {
                name: data.name,
                value: location.Name
              });
          });
      }
    });
  }
  // On Destory
  ngOnDestroy() {
    if (this.subscription2) {
      this.subscription2.unsubscribe();
    }
    super.ngOnDestroy();
  }
}
