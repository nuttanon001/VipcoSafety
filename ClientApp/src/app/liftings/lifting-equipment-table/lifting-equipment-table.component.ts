import { Component, OnInit } from '@angular/core';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';
import { LiftingEquip } from '../shared/lifting-equip.model';

@Component({
  selector: 'app-lifting-equipment-table',
  templateUrl: './lifting-equipment-table.component.html',
  styleUrls: ['./lifting-equipment-table.component.scss']
})
export class LiftingEquipmentTableComponent extends BaseTableDetailMk2Component<LiftingEquip>{

  constructor() {
    super();
    this.columns = [
      { columnName: "Check", columnField: "HasCheck", cell: (row: LiftingEquip) => row.HasCheck },
      { columnName: "Thai", columnField: "SafetyEquipmentNameThai", cell: (row: LiftingEquip) => row.SafetyEquipmentNameThai },
      { columnName: "English", columnField: "SafetyEquipmentNameEng", cell: (row: LiftingEquip) => row.SafetyEquipmentNameEng },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
  }

  // on init
  ngOnInit() {
    this.selection.onChange.subscribe(selected => {
      // Added
      if (selected.added && selected.added.length > 0) {
        if (selected.added[0]) {
          this.selectedRow = selected.added[0];

          if (!this.readOnly)
            this.selectedRow.HasCheck = true;

          this.returnSelectedWith.emit({ data: this.selectedRow, option: 1 });
        }
      }
      // Remove
      if (selected.removed && selected.removed.length > 0) {
        selected.removed.forEach(item => {
          if (item === this.selectedRow) {

            if (!this.readOnly)
              this.selectedRow.HasCheck = false;

            this.selectedRow = undefined;
          }
        });
      }
    });
  }

  // on blur
  onHasCheck(checkBox?: any, rowData?: LiftingEquip): void {
    //Debug here
    if (checkBox && rowData) {
      this.returnSelectedWith.emit({
        data: rowData,
        option: 2
      });
    }
  }
}
