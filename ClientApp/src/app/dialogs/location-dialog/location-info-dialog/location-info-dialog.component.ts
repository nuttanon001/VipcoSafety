import { Component, OnInit } from '@angular/core';
import { BaseInfoDialogComponent } from '../../../shared/base-info-dialog-component';
import { Location } from '../../../locations/shared/location.model';
import { FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-location-info-dialog',
  templateUrl: './location-info-dialog.component.html',
  styleUrls: ['./location-info-dialog.component.scss']
})
export class LocationInfoDialogComponent extends BaseInfoDialogComponent<Location> {
  constructor(
    private fb: FormBuilder
  ) { super() }
  // Build Form
  buildForm(): void {
    this.InfoValueForm = this.fb.group({
      SafetyEquipmentId: [this.InfoValue.LocationId],
      Name: new FormControl(
        {
          value: this.InfoValue.Name,
          disabled: this.denySave,
        },
        [Validators.required, Validators.maxLength(150)]
      ),
      Description: new FormControl(
        {
          value: this.InfoValue.Description,
          disabled: this.denySave,
        },
        [Validators.maxLength(200)]
      ),
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
