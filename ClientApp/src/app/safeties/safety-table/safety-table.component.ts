import { Component, OnInit } from '@angular/core';
import { BaseTableMk2Component } from '../../shared/base-table-mk2.component';
import { Safety } from '../shared/safety.model';
import { SafetyService } from '../shared/safety.service';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-safety-table',
  templateUrl: './safety-table.component.html',
  styleUrls: ['./safety-table.component.scss']
})
export class SafetyTableComponent extends BaseTableMk2Component<Safety, SafetyService>{
  constructor(service: SafetyService, serviceAuth: AuthService) {
    super(service, serviceAuth);
    this.columns = [
      //{ columnName: "", columnField: "select", cell: undefined },
      { columnName: "EmpCode", columnField: "EmpCode", cell: (row: Safety) => row.EmpCode },
      { columnName: "SafetyName", columnField: "SafetyName", cell: (row: Safety) => row.SafetyName },
      { columnName: "SafetyMail", columnField: "SafetyMail", cell: (row: Safety) => row.SafetyMail },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "select");
    this.displayedColumns.splice(0, 0, "Command");
    this.isDisabled = false;
  }
}
