import { Component, OnInit } from '@angular/core';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';
import { ConfinedSpacePer } from '../shared/confined-space-per.model';

@Component({
  selector: 'app-confined-space-precaution-table',
  templateUrl: './confined-space-precaution-table.component.html',
  styleUrls: ['./confined-space-precaution-table.component.scss']
})
export class ConfinedSpacePrecautionTableComponent extends BaseTableDetailMk2Component<ConfinedSpacePer>{

  constructor() {
    super();
    this.columns = [
      { columnName: "Risk", columnField: "Risk", cell: (row: ConfinedSpacePer) => row.Risk },
      { columnName: "Measure", columnField: "Measure", cell: (row: ConfinedSpacePer) => row.Measure },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");
  }

  // on blur
  onBlurText(rowData?: ConfinedSpacePer): void {
    //Debug here
    if (rowData) {
      this.returnSelectedWith.emit({
        data: rowData,
        option: 2
      });
    }
  }
}
