import { Component, OnInit } from '@angular/core';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';
import { LiftingPercaution } from '../shared/lifting-percaution.model';

@Component({
  selector: 'app-lifting-percaution-table',
  templateUrl: './lifting-percaution-table.component.html',
  styleUrls: ['./lifting-percaution-table.component.scss']
})
export class LiftingPercautionTableComponent extends BaseTableDetailMk2Component<LiftingPercaution>{

  constructor() {
    super();
    this.columns = [
      { columnName: "Risk", columnField: "Risk", cell: (row: LiftingPercaution) => row.Risk },
      { columnName: "Measure", columnField: "Measure", cell: (row: LiftingPercaution) => row.Measure },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");
  }

  // on blur
  onBlurText(rowData?: LiftingPercaution): void {
    //Debug here
    if (rowData) {
      this.returnSelectedWith.emit({
        data: rowData,
        option: 2
      });
    }
  }

}
