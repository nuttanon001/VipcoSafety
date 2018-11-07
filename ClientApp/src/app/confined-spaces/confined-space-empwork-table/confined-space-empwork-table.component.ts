import { Component, OnInit } from '@angular/core';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';
import { ConfinedSpaceEmpwork } from '../shared/confined-space-empwork.model';

@Component({
  selector: 'app-confined-space-empwork-table',
  templateUrl: './confined-space-empwork-table.component.html',
  styleUrls: ['./confined-space-empwork-table.component.scss']
})

export class ConfinedSpaceEmpworkTableComponent extends BaseTableDetailMk2Component<ConfinedSpaceEmpwork> {
  constructor() {
    super();
    this.columns = [
      { columnName: "Employee Code", columnField: "EmpCode", cell: (row: ConfinedSpaceEmpwork) => row.EmpCode },
      { columnName: "Name", columnField: "EmpNameThai", cell: (row: ConfinedSpaceEmpwork) => row.EmpNameThai },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");
  }
}
