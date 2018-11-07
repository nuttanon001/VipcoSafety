import { Component, OnInit } from '@angular/core';
import { BaseInfoDialogComponent } from '../../../shared/base-info-dialog-component';
import { CheckList } from '../../../groupwork-permits/shared/check-list.model';
import { FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-check-list-info-dialog',
  templateUrl: './check-list-info-dialog.component.html',
  styleUrls: ['./check-list-info-dialog.component.scss']
})
export class CheckListInfoDialogComponent extends BaseInfoDialogComponent<CheckList> {
  constructor(
    private fb: FormBuilder
  ) { super() }
  // Build Form
  buildForm(): void {
    this.InfoValueForm = this.fb.group({
      CheckListId: [this.InfoValue.CheckListId],
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
