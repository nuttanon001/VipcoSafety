import { Component, OnInit, Inject } from '@angular/core';
import { BaseMasterDialogComponent } from '../../shared/base-master-dialog.component';
import { CheckList } from '../../groupwork-permits/shared/check-list.model';
import { CheckListService } from '../../groupwork-permits/shared/check-list.service';
import { AuthService } from '../../core/auth/auth.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { BaseDialogEntryComponent } from '../../shared/base-dialog-entry.component';
import { StatusModel } from '../../groupwork-permits/shared/groupwork-permit.model';

@Component({
  selector: 'app-check-list-dialog',
  templateUrl: './check-list-dialog.component.html',
  styleUrls: ['./check-list-dialog.component.scss'],
  providers: [CheckListService]
})
export class CheckListDialogComponent
  extends BaseDialogEntryComponent<CheckList, CheckListService> {
  /** employee-dialog ctor */
  constructor(
    service: CheckListService,
    serviceAuth: AuthService,
    public dialogRef: MatDialogRef<CheckListDialogComponent>,
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
      CheckListId: 0,
      Status: StatusModel.Open
    };
  }
}
