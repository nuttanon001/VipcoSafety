import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseInfoMk2Component } from '../../shared/base-info-mk2-component';
import { Safety } from '../shared/safety.model';
import { SafetyService } from '../shared/safety.service';
import { SafetyCommunicateService } from '../shared/safety-communicate.service';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { AuthService } from '../../core/auth/auth.service';
import { Validators } from '@angular/forms';
import { ShareService } from '../../shared/share.service';
import { Employee } from '../../employees/shared/employee.model';

@Component({
  selector: 'app-safety-info',
  templateUrl: './safety-info.component.html',
  styleUrls: ['./safety-info.component.scss'],
  providers: [ ShareService ]
})
export class SafetyInfoComponent extends BaseInfoMk2Component<Safety, SafetyService, SafetyCommunicateService> {
  constructor(
    service: SafetyService,
    serviceCom: SafetyCommunicateService,
    private serviceShared: ShareService,
    private serviceDialogs: DialogsService,
    private serviceAuth: AuthService,
    private viewContainer: ViewContainerRef,
  ) { super(service, serviceCom); }

  onGetDataByKey(InfoValue: Safety): void {
    if (InfoValue && InfoValue.SafetyRepayMailId) {
      this.service.getOneKeyNumber(InfoValue)
        .subscribe(dbData => {
          this.InfoValue = dbData;
        }, error => console.error(error), () => this.buildForm());
    } else {
      this.InfoValue = {
        SafetyRepayMailId: 0,
      };
      this.buildForm();
    }
  }
  // Build Form
  buildForm(): void {
    this.regConfig = [
      // BasemodelRequireWorkpermit //
      {
        type: "inputclick",
        label: "SafetyName",
        inputType: "text",
        name: "SafetyName",
        disabled: this.denySave,
        value: this.InfoValue.SafetyName,
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
        label: "SafetyMail",
        inputType: "mail",
        name: "SafetyMail",
        disabled: this.denySave,
        value: this.InfoValue.SafetyMail,
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
          {
            name: "email",
            validator: Validators.email,
            message: "Is not email address."
          },
        ]
      }
    ];
    let ExcludeList = this.regConfig.map((item) => item.name);

    // Object.keys(this.InfoValue).forEach((item, index) => {
    //   if (!ExcludeList.find((Exitem) => Exitem !== item)) {
    //     this.regConfig.push({
    //       type: "input",
    //       label: item,
    //       inputType: "text",
    //       name: item,
    //       disabled: this.denySave,
    //       hidden: true,
    //       value: this.InfoValue[item],
    //     });
    //   }
    // });
  }
  // set communicate
  SetCommunicatetoParent(): void {
    if (this.isValid) {
      this.communicateService.toParent(this.InfoValue);
    }
  }
  // submit dynamic form
  submitDynamicForm(InfoValue?: Safety): void {
    if (InfoValue) {
      if (!this.denySave) {
        let template = InfoValue;
        // Template
        for (let key in template) {
          // console.log(key);
          this.InfoValue[key] = template[key];
        }
        this.isValid = true;
        //debug here
        // console.log(JSON.stringify(InfoValue));
        this.SetCommunicatetoParent();
      }
    }
  }
  // event from component
  FromComponents(): void {
    this.subscription2 = this.serviceShared.ToParent$.subscribe(data => {
      if (data.name.indexOf("SafetyName") !== -1 ) {
        this.serviceDialogs.dialogSelectEmployee(this.viewContainer)
          .subscribe((emp: Employee) => {
            this.serviceShared.toChild(
              {
                name: data.name,
                value: emp.NameThai
              });

            this.InfoValue.EmpCode = emp.EmpCode;
          });
      }
    });
  }
}
