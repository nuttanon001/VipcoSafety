import { Component, OnInit } from '@angular/core';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';
import { PermitHasEquipment } from '../shared/permit-has-equipment';

@Component({
  selector: 'app-permit-has-equipment',
  templateUrl: './permit-has-equipment.component.html',
  styleUrls: ['./permit-has-equipment.component.scss']
})
export class PermitHasEquipmentComponent extends BaseTableDetailMk2Component<PermitHasEquipment>{

  constructor() {
    super();
    this.columns = [
      { columnName: "No", columnField: "SequenceNo", cell: (row: PermitHasEquipment) => row.SequenceNo },
      { columnName: "Thai", columnField: "SafetyEquipmentNameThai", cell: (row: PermitHasEquipment) => row.SafetyEquipmentNameThai },
      { columnName: "English", columnField: "SafetyEquipmentNameEng", cell: (row: PermitHasEquipment) => row.SafetyEquipmentNameEng },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");
  }

  // on blur
  onMoveUp(rowData?: PermitHasEquipment): void {
    if (rowData) {
      rowData.UpdateSequenceNo = rowData.SequenceNo - 1;
      this.returnSelectedWith.emit({
        data: rowData,
        option: 2
      });
    }
  }

  onMoveDown(rowData?: PermitHasEquipment): void {
    if (rowData) {
      rowData.UpdateSequenceNo = rowData.SequenceNo + 1;
      this.returnSelectedWith.emit({
        data: rowData,
        option: 2
      });
    }
  }
}
