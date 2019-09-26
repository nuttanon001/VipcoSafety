// Angular Core
import { Validators } from '@angular/forms';
import { Component, OnInit, OnDestroy, ViewContainerRef, ViewChild } from '@angular/core';
// Components
import { BaseInfoComponent } from '../../shared/base-info-component';
import { DynamicFormComponent } from '../../shared/dynamic-form/dynamic-form/dynamic-form.component';
// Services
import { ShareService } from '../../shared/share.service';
import { AuthService } from '../../core/auth/auth.service';
import { LiftingService } from '../shared/lifting.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { LiftingCheckService } from '../shared/lifting-check.service';
import { LiftingEquipService } from '../shared/lifting-equip.service';
import { LiftingPercautionService } from '../shared/lifting-percaution.service';
import { LiftingCommunicateService } from '../shared/lifting-communicate.service';
import { EmployeeGroupService } from '../../employees/shared/employee-group.service';
import { PermitHasChecklistService } from '../../groupwork-permits/shared/permit-has-checklist.service';
import { PermitHasEquipmentService } from '../../groupwork-permits/shared/permit-has-equipment.service';
// Models
import { Lifting } from '../shared/lifting.model';
import { LiftingCheck } from '../shared/lifting-check.model';
import { LiftingEquip } from '../shared/lifting-equip.model';
import { Location } from '../../locations/shared/location.model';
import { LiftingPercaution } from '../shared/lifting-percaution.model';
import { ProjectMaster } from '../../projects/shared/project-master.model';
import { StatusWorkPermit } from '../../shared/basemodel/status-work-permit.enum';
import { FieldConfig, GroupField } from '../../shared/dynamic-form/field-config.model';
// Rxjs
import { Subscription } from 'rxjs';
import { Employee } from '../../employees/shared/employee.model';
import { Tree } from 'primeng/primeng';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-lifting-info',
  templateUrl:  './lifting-info.component.html' ,
  styleUrls: [ './lifting-info.component.scss' ],
  providers: [ ShareService ]
})
export class LiftingInfoComponent extends
  BaseInfoComponent<Lifting, LiftingService, LiftingCommunicateService> implements OnDestroy {
  constructor(
    service: LiftingService,
    serviceCom: LiftingCommunicateService,
    private serviceHasChecklist: LiftingCheckService,
    private serviceHasEquipment: LiftingEquipService,
    private serviceHasPercaution: LiftingPercautionService,
    private servicePermitHasChecklist: PermitHasChecklistService,
    private servicePermitHasEquipment: PermitHasEquipmentService,
    private serviceShared:ShareService,
    private serviceGroup: EmployeeGroupService,
    private serviceDialogs: DialogsService,
    private serviceAuth: AuthService,
    private viewContainer: ViewContainerRef,
  ) {
    super(service, serviceCom);
  }
  // Template
  subscription2: Subscription;
  regConfig: Array<FieldConfig>;
  groupConfig: Array<GroupField>;
  groupCode: string;
  isValid: boolean = false;
  isCopying: boolean = false;
  // OnGetData
  onGetDataByKey(InfoValue: Lifting): void {
    if (InfoValue && InfoValue.Lifting1WorkPermitId)
    {
      this.isCopying = InfoValue.Copying;
      this.service.getOneKeyNumber(InfoValue)
        .subscribe(dbData => {
          this.InfoValue = dbData;
          if (this.InfoValue) {
            // Set is copying
            // Get Checklist for LiftingWorkpermit
            this.serviceHasChecklist.getByMasterId(this.InfoValue.Lifting1WorkPermitId)
              .subscribe(dbData => {
                if (dbData) {
                  let newLiftingHasChecks: Array<LiftingCheck> = new Array;
                  dbData.forEach(item => {
                    newLiftingHasChecks.push({
                      CheckListId: item.CheckListId,
                      CheckListNameEng: item.CheckListNameEng,
                      CheckListNameThai: item.CheckListNameThai,
                      LiftingHasCheckListId: this.isCopying ? undefined : item.LiftingHasCheckListId,
                      Lifting1WorkPermitId: this.isCopying ? undefined : item.Lifting1WorkPermitId,
                      CreateDate: this.isCopying ? undefined : item.CreateDate,
                      Creator: this.isCopying ? undefined : item.Creator,
                      HasCheck: item.HasCheck,
                      ModifyDate: this.isCopying ? undefined : item.ModifyDate,
                      Modifyer: this.isCopying ? undefined : item.Modifyer
                    });
                  });
                  this.InfoValue.LiftingHasCheckLists = newLiftingHasChecks;
                }
              });
            // Get Equipment for LiftingWorkpermit
            this.serviceHasEquipment.getByMasterId(this.InfoValue.Lifting1WorkPermitId)
              .subscribe(dbData => {
                if (dbData) {
                  let newLiftingHasEquip: Array<LiftingEquip> = new Array;
                  dbData.forEach(item => {
                    newLiftingHasEquip.push({
                      SafetyEquipmentId: item.SafetyEquipmentId,
                      SafetyEquipmentNameThai: item.SafetyEquipmentNameThai,
                      SafetyEquipmentNameEng: item.SafetyEquipmentNameEng,
                      LiftingHasEquipId: this.isCopying ? undefined :  item.LiftingHasEquipId,
                      Lifting1WorkPermitId: this.isCopying ? undefined :  item.Lifting1WorkPermitId,
                      CreateDate: this.isCopying ? undefined :  item.CreateDate,
                      Creator: this.isCopying ? undefined :  item.Creator,
                      HasCheck: item.HasCheck,
                      ModifyDate: this.isCopying ? undefined :  item.ModifyDate,
                      Modifyer: this.isCopying ? undefined :  item.Modifyer,
                    });
                  });
                  this.InfoValue.LiftingHasEquips = newLiftingHasEquip;
                }
              });
            // Get Percaution for LiftingWorkpermit
            this.serviceHasPercaution.getByMasterId(this.InfoValue.Lifting1WorkPermitId)
              .subscribe(dbData => {
                if (dbData) {
                  let newLiftingHasPercaut: Array<LiftingPercaution> = new Array;
                  let RowIndex = 1;
                  dbData.forEach(item => {
                    newLiftingHasPercaut.push({
                      LiftingHasPerId: this.isCopying ? undefined :  item.LiftingHasPerId,
                      Measure: item.Measure,
                      Risk: item.Risk,
                      Description: item.Description,
                      Remark: item.Remark,
                      Lifting1WorkPermitId: this.isCopying ? undefined :  item.Lifting1WorkPermitId,
                      CreateDate: this.isCopying ? undefined :  item.CreateDate,
                      Creator: this.isCopying ? undefined :  item.Creator,
                      ModifyDate: this.isCopying ? undefined :  item.ModifyDate,
                      Modifyer: this.isCopying ? undefined :  item.Modifyer,
                      RowIndex: RowIndex
                    });
                    RowIndex += 1;
                  });
                  this.InfoValue.LiftingHasPercautions = newLiftingHasPercaut;
                }
              });
          }
        }, error => console.error(error), () => {
          if (this.isCopying) {
            this.InfoValue.Lifting1WorkPermitId = 0;
            this.InfoValue.StatusWorkPermit = StatusWorkPermit.Require;
            this.InfoValue.ApprovedDate = undefined;
            this.InfoValue.ComplateBy = undefined;
            this.InfoValue.ComplateByName = undefined;
            this.InfoValue.ComplateDate = undefined;
            this.InfoValue.ComplateTimeString = undefined;
            this.InfoValue.LiftDate = undefined;
            this.InfoValue.LiftDateTimeString = undefined;
            this.InfoValue.IsSendMail = undefined;
            this.InfoValue.CreateDate = undefined;
            this.InfoValue.Creator = undefined;
            this.InfoValue.ModifyDate = undefined;
            this.InfoValue.Modifyer = undefined;
            // Get Name Require
            this.getNameRequire();
          }
          this.buildForm();
        });
    }
    else
    {
      this.InfoValue = {
        Lifting1WorkPermitId: 0,
        StatusWorkPermit: StatusWorkPermit.Require,
        LiftingHasCheckLists: new Array,
        LiftingHasEquips: new Array,
        LiftingHasPercautions: new Array,
        GroupWorkPermitId: 2,
        OverTenTon:true,
      };

      // Get Name Require
      this.getNameRequire();

      this.servicePermitHasChecklist.getByMasterId(this.InfoValue.GroupWorkPermitId)
        .subscribe(dbData => {
          if (dbData) {
            let newLiftingHasChecks: Array<LiftingCheck> = new Array;
            dbData.forEach(item => {
              newLiftingHasChecks.push({
                CheckListId: item.CheckListId,
                CheckListNameEng: item.CheckListNameEng,
                CheckListNameThai: item.CheckListNameThai,
                LiftingHasCheckListId: 0,
                Lifting1WorkPermitId: 0,
                HasCheck: item.CheckListNameThai.indexOf("อุปกรณ์ช่วยยก") === -1 ? true : false,
              });
            });
            this.InfoValue.LiftingHasCheckLists = newLiftingHasChecks;
          }
        });

      this.servicePermitHasEquipment.getByMasterId(this.InfoValue.GroupWorkPermitId)
        .subscribe(dbData => {
          if (dbData) {
            let newLiftingSpaceEquip: Array<LiftingEquip> = new Array;
            dbData.forEach(item => {
              newLiftingSpaceEquip.push({
                SafetyEquipmentId: item.SafetyEquipmentId,
                SafetyEquipmentNameThai: item.SafetyEquipmentNameThai,
                SafetyEquipmentNameEng: item.SafetyEquipmentNameEng,
                LiftingHasEquipId: 0,
                Lifting1WorkPermitId: 0,
                HasCheck: false,
              });
            });
            this.InfoValue.LiftingHasEquips = newLiftingSpaceEquip;
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
                  name: "WorkGroup",
                  value: Group.Description
                });
            }
          });
      }
    }
  }
  // BulidForm
  buildForm(): void {
    this.groupConfig = [
      {
        name: "detail",
        title: "ข้อมูลเบื้องต้น"
      },
      {
        name: "1",
        title: "ข้อมูลอื่นๆ"
      },
      {
        name: "2",
        title: "ข้อมูลเครน"
      },
      {
        name: "3",
        title: "ข้อมูลชิ้นงาน"
      },
      {
        name: "4",
        title: "ข้อมูลสลิง"
      },
      {
        name: "5",
        title: "ข้อมูลโซ่"
      },
      {
        name: "6",
        title: "ข้อมูลผ้าใบ"
      },
      {
        name: "7",
        title: "ข้อมูลสะเก็น"
      },
      {
        name: "8",
        title: "ข้อมูลลักษณะการยก"
      },
      {
        name: "9",
        title: "ข้อมูลอุปกรณ์ช่วยยก"
      },
      {
        name: "10",
        title: "ข้อมูลตะขอ/สาแหลก"
      },
    ];
    this.regConfig = [
      // BasemodelRequireWorkpermit //
      //{
      //  type: "radiobutton",
      //  label: "Type of Lifting Equipment",
      //  name: "TypeWork",
      //  options: ["ขนาดชิ้นงานเกิน 10 Ton.", "ชิ้นงานยาวเกิน 12 เมตร", "ชิ้นงานกว้างเกิน 3 เมตร", "มีรูปร่างซับซ้อน/ใช้เครน 2 เครื่องในการเคลื่อนย้าย"],
      //  disabled: this.denySave,
      //  value: this.InfoValue.TypeWork,
      //  group:"detail",
      //  validations: [
      //    {
      //      name: "required",
      //      validator: Validators.required,
      //      message: "Is required"
      //    },
      //  ]
      //},
      // Group Check Box
      {
        type: "checkbox",
        label: "ขนาดชิ้นงานเกิน 10 Ton",
        name: "OverTenTon",
        disabled: this.denySave,
        value: this.InfoValue.OverTenTon,
        group: "detail",
      },
      {
        type: "checkbox",
        label: "ชิ้นงานยาวเกิน 12 เมตร",
        name: "LengthOverTwelveMeter",
        disabled: this.denySave,
        value: this.InfoValue.LengthOverTwelveMeter,
        group: "detail",
      },
      {
        type: "checkbox",
        label: "ชิ้นงานกว้างเกิน 3 เมตร",
        name: "WidthOverThreeMeter",
        disabled: this.denySave,
        value: this.InfoValue.WidthOverThreeMeter,
        group: "detail",
      },
      {
        type: "checkbox",
        label: "มีรูปร่างซับซ้อน/ใช้เครน 2 เครื่องในการเคลื่อนย้าย",
        name: "TwoCraneLift",
        disabled: this.denySave,
        value: this.InfoValue.TwoCraneLift,
        group: "detail",
      },

      {
        type: "input",
        label: "ยื่นคำขอโดย",
        inputType: "text",
        name: "RequireByEmpName",
        disabled: this.denySave,
        value: this.InfoValue.RequireByEmpName,
        group:"detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
        ]
      },
      {
        type: "input",
        label: "RepayMail",
        inputType: "maill",
        name: "RepayMail",
        disabled: this.denySave,
        value: this.InfoValue.RepayMail,
        group:"detail",
        validations: [
          {
            name: "maxlength",
            validator: Validators.maxLength(200),
            message: "Max length is 200"
          },
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
        ]
      },
      {
        type: "date",
        label: "วันที่เริ่ม",
        name: "LiftDate",
        disabled: this.denySave,
        value: this.InfoValue.LiftDate,
        group:"detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          }
        ]
      },
      {
        type: "input",
        label: "เวลาเริ่ม",
        inputType: "time",
        name: "LiftDateTimeString",
        disabled: this.denySave,
        value: this.InfoValue.LiftDateTimeString,
        group:"detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
        ]
      },
      {
        type: "date",
        label: "วันที่จบ",
        name: "LiftFinishDate",
        disabled: this.denySave,
        value: this.InfoValue.LiftFinishDate,
        group: "detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          }
        ]
      },
      {
        type: "input",
        label: "เวลาจบ",
        inputType: "time",
        name: "LiftFinishDateTimeString",
        disabled: this.denySave,
        value: this.InfoValue.LiftFinishDateTimeString,
        group: "detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
        ]
      },
      {
        type: "inputclick",
        label: "สำหรับงาน Job. No.",
        inputType: "text",
        name: "JobNo",
        disabled: this.denySave,
        value: this.InfoValue.JobNo,
        readonly: true,
        group:"detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
          {
            name: "maxlength",
            validator: Validators.maxLength(100),
            message: "Max length is 100"
          },
        ]
      },
      {
        type: "inputclick",
        label: "กลุ่มงาน",
        inputType: "text",
        name: "WorkGroup",
        disabled: this.denySave,
        value: this.InfoValue.WorkGroup,
        readonly: true,
        group:"detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
          {
            name: "maxlength",
            validator: Validators.maxLength(100),
            message: "Max length is 100"
          },
        ]
      },
      {
        type: "inputclick",
        label: "สถานที่ปฏิบัติงาน",
        inputType: "text",
        name: "Location",
        disabled: this.denySave,
        value: this.InfoValue.Location,
        readonly: true,
        group: "detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
          {
            name: "maxlength",
            validator: Validators.maxLength(100),
            message: "Max length is 100"
          },
        ]
      },
      {
        type: "inputclick",
        label: "โฟร์แมนผู้รับผิดชอบในงาน",
        inputType: "text",
        name: "SupervisorName",
        disabled: this.denySave,
        value: this.InfoValue.SupervisorName,
        group: "detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
          {
            name: "maxlength",
            validator: Validators.maxLength(150),
            message: "Max length is 150"
          },
        ]
      },
      {
        type: "inputclick",
        label: "วิศวกรผู้รับผิดชอบในงาน",
        inputType: "text",
        name: "EngineerName",
        disabled: this.denySave,
        value: this.InfoValue.EngineerName,
        group: "detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
          {
            name: "maxlength",
            validator: Validators.maxLength(150),
            message: "Max length is 150"
          },
        ]
      },
      {
        type: "inputclick",
        label: "ผู้ให้สัญญาณเครน",
        inputType: "text",
        name: "SignalName",
        disabled: this.denySave,
        value: this.InfoValue.SignalName,
        group: "detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
          {
            name: "maxlength",
            validator: Validators.maxLength(150),
            message: "Max length is 150"
          },
        ]
      },
      {
        type: "inputclick",
        label: "ผู้บังคับเครน",
        inputType: "text",
        name: "ControlCraneName",
        disabled: this.denySave,
        value: this.InfoValue.ControlCraneName,
        continue: true,
        group:"detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
          {
            name: "maxlength",
            validator: Validators.maxLength(150),
            message: "Max length is 150"
          },
        ]
      },
      {
        type: "inputclick",
        label: "ผู้ควบคุม",
        inputType: "text",
        name: "ControlName",
        disabled: this.denySave,
        value: this.InfoValue.ControlName,
        group: "detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
          {
            name: "maxlength",
            validator: Validators.maxLength(150),
            message: "Max length is 150"
          },
        ]
      },
      {
        type: "inputclick",
        label: "ผู้ยึดเกาะ",
        inputType: "text",
        name: "ConnectName",
        disabled: this.denySave,
        value: this.InfoValue.ConnectName,
        continue: true,
        group: "detail",
        validations: [
          {
            name: "required",
            validator: Validators.required,
            message: "Is required"
          },
          {
            name: "maxlength",
            validator: Validators.maxLength(150),
            message: "Max length is 150"
          },
        ]
      },
      //////////////////////////
      // Line-1
      {
        type: "input",
        label: "ขออนุญาตยก-ขนย้ายวัสดุน้ำหนัก -- ตัน",
        inputType: "number",
        name: "Line1TotalWeight",
        disabled: this.denySave,
        value: this.InfoValue.Line1TotalWeight,
        group:"1",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "ขออนุญาตยก-ขนย้ายวัสดุเพิ่อทำงาน",
        inputType: "text",
        name: "Line1Comment",
        disabled: this.denySave,
        value: this.InfoValue.Line1Comment,
        group:"1",
        validations: [
          {
            name: "maxlength",
            validator: Validators.maxLength(200),
            message: "Max length is 200"
          },
        ]
      },
      {
        type: "input",
        label: "การรับน้ำหนักของอุปกรณ์การยก/เส้น(ตัน)",
        inputType: "number",
        name: "WeightPerLift",
        disabled: this.denySave,
        value: this.InfoValue.WeightPerLift,
        group: "1",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      // 
      // Line-2
      {
        type: "input",
        label: "ยกโดย Over Header Cranc ขนาด -- ตัน",
        inputType: "text",
        name: "Line2OverHeadCrancSize",
        disabled: this.denySave,
        value: this.InfoValue.Line2OverHeadCrancSize,
        group:"2",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "Over Header Cranc จำนวน -- เครื่อง",
        inputType: "number",
        name: "Line2OverHeadCrancEa",
        disabled: this.denySave,
        value: this.InfoValue.Line2OverHeadCrancEa,
        group:"2",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "Mobile Cranc ขนาด -- ตัน",
        inputType: "text",
        name: "Line2MobileCrancSize",
        disabled: this.denySave,
        value: this.InfoValue.Line2MobileCrancSize,
        group:"2",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "Mobile Cranc จำนวน -- คัน",
        inputType: "number",
        name: "Line2MobileCrancEa",
        disabled: this.denySave,
        value: this.InfoValue.Line2MobileCrancEa,
        group:"2",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },

      // Line - 3
      {
        type: "input",
        label: "ขนาดชิ้นงานกว้าง -- เมตร",
        inputType: "number",
        name: "Line3WidthWork",
        disabled: this.denySave,
        value: this.InfoValue.Line3WidthWork,
        group:"3",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "ขนาดชิ้นงานยาว -- เมตร",
        inputType: "number",
        name: "Line3LengthWork",
        disabled: this.denySave,
        value: this.InfoValue.Line3LengthWork,
        group:"3",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "ขนาดชิ้นงานสูง -- เมตร",
        inputType: "number",
        name: "Line3HeightWork",
        disabled: this.denySave,
        value: this.InfoValue.Line3HeightWork,
        group:"3",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      // Line - 4
      {
        type: "input",
        label: "ขนาดสลิง -- นิ้ว",
        inputType: "text",
        name: "Line4SlingSize",
        disabled: this.denySave,
        value: this.InfoValue.Line4SlingSize,
        group:"4",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "จำนวนสลิง -- เส้น",
        inputType: "number",
        name: "Line4SlingTotal",
        disabled: this.denySave,
        value: this.InfoValue.Line4SlingTotal,
        group:"4",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "ความยาวสลิง -- เมตร",
        inputType: "number",
        name: "Line4SlingLength",
        disabled: this.denySave,
        value: this.InfoValue.Line4SlingLength,
        group:"4",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      // Line - 5
      {
        type: "input",
        label: "ขนาดโซ่ -- มิลลิเมตร",
        inputType: "text",
        name: "Line5ChainSize",
        disabled: this.denySave,
        value: this.InfoValue.Line5ChainSize,
        group:"5",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "จำนวนโซ่ -- เส้น",
        inputType: "number",
        name: "Line5ChainTotal",
        disabled: this.denySave,
        value: this.InfoValue.Line5ChainTotal,
        group:"5",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "ความยาวโซ่ -- เมตร",
        inputType: "number",
        name: "Line5ChainLength",
        disabled: this.denySave,
        value: this.InfoValue.Line5ChainLength,
        group:"5",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      // Line - 6
      {
        type: "input",
        label: "ขนาดผ้าใบ",
        inputType: "text",
        name: "Line6BurlapSize",
        disabled: this.denySave,
        value: this.InfoValue.Line6BurlapSize,
        group:"6",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "จำนวนผ้าใบ -- เส้น",
        inputType: "number",
        name: "Line6BurlapTotal",
        disabled: this.denySave,
        value: this.InfoValue.Line6BurlapTotal,
        group:"6",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "ความยาวผ้าใบ -- เมตร",
        inputType: "number",
        name: "Line6burlapLength",
        disabled: this.denySave,
        value: this.InfoValue.Line6burlapLength,
        group:"6",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      // Line - 7
      {
        type: "input",
        label: "ขนาดสะเก็น -- นิ้ว",
        inputType: "text",
        name: "Line7ShacklesSize",
        disabled: this.denySave,
        value: this.InfoValue.Line7ShacklesSize,
        group:"7",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "จำนวนสะเก็น -- เส้น",
        inputType: "number",
        name: "Line7ShacklesTotal",
        disabled: this.denySave,
        value: this.InfoValue.Line7ShacklesTotal,
        group:"7",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      // Line 8
      {
        type: "input",
        label: "ลักษณะในการยก:ยกโดยมีหูยก -- หู",
        inputType: "number",
        name: "Line8TypeLiftTotal",
        disabled: this.denySave,
        value: this.InfoValue.Line8TypeLiftTotal,
        group:"8",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "ลักษณะในการยก:ยกโดยการอุ้ม -- องศา",
        inputType: "number",
        name: "Line8LiftCarry",
        disabled: this.denySave,
        value: this.InfoValue.Line8LiftCarry,
        group:"8",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "ลักษณะในการยก:มุมองศาในการยก -- องศา",
        inputType: "number",
        name: "Line8LiftDegree",
        disabled: this.denySave,
        value: this.InfoValue.Line8LiftDegree,
        group:"8",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      // Line 9
      {
        type: "input",
        label: "อุปกรณ์ในการช่วยยก:ลิฟติ้งบีมยาว -- เมตร",
        inputType: "number",
        name: "Line9Length",
        disabled: this.denySave,
        value: this.InfoValue.Line9LiftingBeamLength,
        group:"9",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "อุปกรณ์ในการช่วยยก:ลิฟติ้งบีมน้ำหนัก -- ตัน",
        inputType: "number",
        name: "Line8LiftCarry",
        disabled: this.denySave,
        value: this.InfoValue.Line9LiftingBeamWeigth,
        group:"9",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "อุปกรณ์ในการช่วยยก:รอกโซ่ -- ตัน",
        inputType: "number",
        name: "Line9ChainHoistSize",
        disabled: this.denySave,
        value: this.InfoValue.Line9ChainHoistSize,
        group:"9",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "อุปกรณ์ในการช่วยยก:กำมะลอ -- ตัน",
        inputType: "number",
        name: "Line9CummalongSize",
        disabled: this.denySave,
        value: this.InfoValue.Line9CummalongSize,
        group:"9",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      // Line - 10
      {
        type: "input",
        label: "ตะขอยก/ก้ามปู -- ตัน",
        inputType: "number",
        name: "Line10Ton",
        disabled: this.denySave,
        value: this.InfoValue.Line10Ton,
        group:"10",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Is greater than 0."
          },
        ]
      },
      {
        type: "input",
        label: "สาแหลกจำนวน -- คู่",
        inputType: "number",
        name: "Line10GG",
        disabled: this.denySave,
        value: this.InfoValue.Line10GG,
        group:"10",
        validations: [
          {
            name: "min",
            validator: Validators.min(0),
            message: "Cummalong size min is 0."
          },
        ]
      },
      {
        type: "input",
        label: "อื่นๆ",
        inputType: "text",
        name: "Other",
        disabled: this.denySave,
        value: this.InfoValue.Other,
        group:"1",
        validations: [
          {
            name: "maxlength",
            validator: Validators.maxLength(200),
            message: "Max length is 200"
          },
        ]
      },
    ];
    //let ExcludeList = this.regConfig.map((item) => item.name);

    //ExcludeList.push("LiftingHasEquips");
    //ExcludeList.push("LiftingHasCheckLists");
    //ExcludeList.push("LiftingHasPercautions");

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
    //      group:"detail",
    //    });
    //  }
    //});
  }
  // Submit
  submitDynamicForm(value?: any): void {
    if (value) {
      if (!this.denySave) {
        let template = value as Lifting;
        // Template
        for (let key in template) {
          // console.log(key);
          if (key !== "LiftingHasEquips" && key !== "LiftingHasCheckLists") {
            this.InfoValue[key] = template[key];
          }
        }

        // TypeWork
        //this.InfoValue.OverTenTon = this.InfoValue.TypeWork === "ขนาดชิ้นงานเกิน 10 Ton.";
        //this.InfoValue.LengthOverTwelveMeter = this.InfoValue.TypeWork === "ชิ้นงานยาวเกิน 12 เมตร";
        //this.InfoValue.WidthOverThreeMeter = this.InfoValue.TypeWork === "ชิ้นงานกว้างเกิน 3 เมตร";
        //this.InfoValue.TwoCraneLift = this.InfoValue.TypeWork === "มีรูปร่างซับซ้อน/ใช้เครน 2 เครื่องในการเคลื่อนย้าย";
        // Set is valid
        this.isValid = true;
        this.SetCommunicatetoParent();
      }
    }
  }
  // Set communicateto parent
  SetCommunicatetoParent(): void {
    if (this.isValid && this.InfoValue.LiftingHasEquips && this.InfoValue.LiftingHasCheckLists &&
        this.InfoValue.LiftingHasPercautions) {

      if (this.InfoValue.LiftingHasEquips.length > 0 && this.InfoValue.LiftingHasCheckLists.length > 0 &&
          this.InfoValue.LiftingHasPercautions.length > 0) {
        // Communicate
        this.communicateService.toParent(this.InfoValue);
      }
    }
  }
  // Equipment
  OnEquipmentEvent(item: { data?: LiftingEquip, option: number }): void {
    if (this.denySave) {
      return;
    }

    if (item) {
      if (item.data && item.option) {
        const liftingHasEquip = this.InfoValue.LiftingHasEquips.filter(value => value.SafetyEquipmentId == item.data.SafetyEquipmentId);
        if (liftingHasEquip[0]) {
          liftingHasEquip[0].HasCheck = item.data.HasCheck;
        }
        this.InfoValue.LiftingHasEquips = this.InfoValue.LiftingHasEquips.slice();
        this.SetCommunicatetoParent();
      }
    }
  }
  // Check-kist
  OnCheckListEvent(item: { data?: LiftingCheck, option: number }): void {
    if (this.denySave) {
      return;
    }

    if (item) {
      if (item.data && item.option) {
        const liftingHasCheck = this.InfoValue.LiftingHasCheckLists.filter(value => value.CheckListId == item.data.CheckListId);
        if (liftingHasCheck[0]) {
          liftingHasCheck[0].HasCheck = item.data.HasCheck;
        }
        this.InfoValue.LiftingHasCheckLists = this.InfoValue.LiftingHasCheckLists.slice();
        this.SetCommunicatetoParent();
      }
    }
  }
  // Precaution
  OnPrecautionEvent(Item: { data?: LiftingPercaution, option: number }): void {
    if (this.denySave) {
      return;
    }
    if (Item.option === 1 && !Item.data) {
      let rowIndex = (this.InfoValue.LiftingHasPercautions.length || 0) + 1;

      this.InfoValue.LiftingHasPercautions.push({
        LiftingHasPerId: 0,
        Lifting1WorkPermitId: this.InfoValue.Lifting1WorkPermitId,
        Measure: "",
        Risk: "",
        Description: "",
        Remark: "",
        RowIndex: rowIndex
      });
      this.InfoValue.LiftingHasPercautions = this.InfoValue.LiftingHasPercautions.slice();
      this.SetCommunicatetoParent();
    }
    else if (Item.option === 2) {
      const confinedSpacePercaution = this.InfoValue.LiftingHasPercautions.filter(value => value.RowIndex == Item.data.RowIndex);
      if (confinedSpacePercaution[0]) {
        confinedSpacePercaution[0].Risk = Item.data.Risk;
        confinedSpacePercaution[0].Measure = Item.data.Measure;
      }
      this.InfoValue.LiftingHasPercautions = this.InfoValue.LiftingHasPercautions.slice();
      this.SetCommunicatetoParent();
    }
    else if (Item.option === 0) {
      let indexItem = this.InfoValue.LiftingHasPercautions.indexOf(Item.data);
      this.InfoValue.LiftingHasPercautions.splice(indexItem, 1);
      this.InfoValue.LiftingHasPercautions = this.InfoValue.LiftingHasPercautions.slice();
      this.SetCommunicatetoParent();
    }
  }
  // From Components
  FromComponents(): void {
    this.subscription2 = this.serviceShared.ToParent$.subscribe(data => {
      if (data.name.indexOf("WorkGroup") !== -1) {
        this.serviceDialogs.dialogSelectGroupMis(this.viewContainer)
          .subscribe(workGroup => {
            this.serviceShared.toChild(
              {
                name: data.name,
                value: workGroup.GroupDesc
              });
          });
      } else if (data.name.indexOf("JobNo") !== -1) {
        this.serviceDialogs.dialogSelectProject(this.viewContainer)
          .subscribe((project: ProjectMaster) => {
            this.serviceShared.toChild(
              {
                name: data.name,
                value: project.ProjectCode
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
      } else if (data.name.indexOf("SupervisorName") !== -1 || data.name.indexOf("EngineerName") !== -1 ||
        data.name.indexOf("SignalName") !== -1 || data.name.indexOf("ControlCraneName") !== -1 ||
        data.name.indexOf("ControlName") !== -1 || data.name.indexOf("ConnectName") !== -1) {

        if (data.name.indexOf("ControlCraneName") !== -1 || data.name.indexOf("ConnectName") !== -1) {
          this.serviceDialogs.dialogSelectEmployees(this.viewContainer)
            .subscribe((emp: Array<Employee>) => {
              if (emp) {
                let nameThai: string = "";
                emp.forEach(item => {
                  nameThai += (nameThai ? "," : "") + item.NameThai
                });
                this.serviceShared.toChild(
                  {
                    name: data.name,
                    value: nameThai
                  });
              }
            });
        } else {
          this.serviceDialogs.dialogSelectEmployee(this.viewContainer)
            .subscribe((emp: Employee) => {
              this.serviceShared.toChild(
                {
                  name: data.name,
                  value: emp.NameThai
                });
            });
        }
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
