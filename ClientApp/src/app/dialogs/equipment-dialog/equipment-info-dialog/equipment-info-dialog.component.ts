import { Component, OnInit } from '@angular/core';
import { BaseInfoDialogComponent } from '../../../shared/base-info-dialog-component';
import { Equipment } from '../../../groupwork-permits/shared/equipment.model';
import { FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-equipment-info-dialog',
  templateUrl: './equipment-info-dialog.component.html',
  styleUrls: ['./equipment-info-dialog.component.scss']
})
export class EquipmentInfoDialogComponent
  extends BaseInfoDialogComponent<Equipment> {
  constructor(
    private fb: FormBuilder
  ) { super() }
  // Build Form
  buildForm(): void {
    this.InfoValueForm = this.fb.group({
      SafetyEquipmentId: [this.InfoValue.SafetyEquipmentId],
      NameThai: new FormControl(
        {
          value: this.InfoValue.NameThai,
          disabled: this.denySave,
        },
        [Validators.required, Validators.maxLength(250)]
      ),
      NameEng: new FormControl(
        {
          value: this.InfoValue.NameEng,
          disabled: this.denySave,
        },
        [Validators.required, Validators.maxLength(250)]
      ),
      Description: new FormControl(
        {
          value: this.InfoValue.Description,
          disabled: this.denySave,
        },
        [Validators.maxLength(200)]
      ),
      Status: [this.InfoValue.Status],
      //BaseMode
      CreateDate: [this.InfoValue.CreateDate],
      Creator: [this.InfoValue.Creator],
      ModifyDate: [this.InfoValue.ModifyDate],
      Modifyer: [this.InfoValue.Modifyer],
    });

    if (this.InfoValueForm) {
      Object.keys(this.InfoValueForm.controls).forEach(field => {
        const control = this.InfoValueForm.get(field);
        control.markAsTouched({ onlySelf: true });
      });
    }
  }
}
