import { Component, OnInit } from '@angular/core';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';
import { ConfinedSpaceEmphelp } from '../shared/confined-space-emphelp.model';

@Component({
  selector: 'app-confined-space-emphelp-table',
  templateUrl: './confined-space-emphelp-table.component.html',
  styleUrls: ['./confined-space-emphelp-table.component.scss']
})
export class ConfinedSpaceEmphelpTableComponent extends BaseTableDetailMk2Component<ConfinedSpaceEmphelp> {
  constructor() {
    super();
    this.columns = [
      { columnName: "Employee Code", columnField: "EmpCode", cell: (row: ConfinedSpaceEmphelp) => row.EmpCode },
      { columnName: "Name", columnField: "EmpNameThai", cell: (row: ConfinedSpaceEmphelp) => row.EmpNameThai },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");
  }
}
