import { Component, OnInit, Inject } from '@angular/core';
import { Equipment } from '../../groupwork-permits/shared/equipment.model';
import { EquipmentService } from '../../groupwork-permits/shared/equipment.service';
import { BaseDialogEntryComponent } from '../../shared/base-dialog-entry.component';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { StatusModel } from '../../groupwork-permits/shared/groupwork-permit.model';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-equipment-dialog',
  templateUrl: './equipment-dialog.component.html',
  styleUrls: ['./equipment-dialog.component.scss'],
  providers: [EquipmentService]
  
})
export class EquipmentDialogComponent
  extends BaseDialogEntryComponent<Equipment, EquipmentService> {
  /** employee-dialog ctor */
  constructor(
    service: EquipmentService,
    serviceAuth:AuthService,
    public dialogRef: MatDialogRef<EquipmentDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public mode: number
  ) {
    super(
      service,
      serviceAuth,
      dialogRef
    );
  }

  // on init
  onInit(): void {
    this.fastSelectd = this.mode === 0 ? true : false;
  }

  // on new entity
  onNewEntity(): void {
    this.InfoValue = {
      SafetyEquipmentId: 0,
      Status: StatusModel.Open
    };
  }
}
