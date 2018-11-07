import { Component, OnInit } from '@angular/core';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';
import { PermitHasChecklist } from '../shared/permit-has-checklist';

@Component({
  selector: 'app-permit-has-checklist',
  templateUrl: './permit-has-checklist.component.html',
  styleUrls: ['./permit-has-checklist.component.scss']
})
export class PermitHasChecklistComponent extends BaseTableDetailMk2Component<PermitHasChecklist>{

  constructor() {
    super();
    this.columns = [
      { columnName: "No", columnField: "SequenceNo", cell: (row: PermitHasChecklist) => row.SequenceNo },
      { columnName: "Thai", columnField: "CheckListNameThai", cell: (row: PermitHasChecklist) => row.CheckListNameThai },
      { columnName: "English", columnField: "CheckListNameEng", cell: (row: PermitHasChecklist) => row.CheckListNameEng },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");
  }

  // on blur
  onMoveUp(rowData?: PermitHasChecklist): void {
    if (rowData) {
      rowData.UpdateSequenceNo = rowData.SequenceNo - 1;
      this.returnSelectedWith.emit({
        data: rowData,
        option: 2
      });
    }
  }

  onMoveDown(rowData?: PermitHasChecklist): void {
    if (rowData) {
      rowData.UpdateSequenceNo = rowData.SequenceNo + 1;
      this.returnSelectedWith.emit({
        data: rowData,
        option: 2
      });
    }
  }
}
