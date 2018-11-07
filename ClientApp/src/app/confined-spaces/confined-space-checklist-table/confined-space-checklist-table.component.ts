import { Component, OnInit } from '@angular/core';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';
import { ConfinedSpaceCheck } from '../shared/confined-space-check.model';

@Component({
  selector: 'app-confined-space-checklist-table',
  templateUrl: './confined-space-checklist-table.component.html',
  styleUrls: ['./confined-space-checklist-table.component.scss']
})
export class ConfinedSpaceChecklistTableComponent extends BaseTableDetailMk2Component<ConfinedSpaceCheck>{

  constructor() {
    super();
    this.columns = [
      { columnName: "Check", columnField: "HasCheck", cell: (row: ConfinedSpaceCheck) => row.HasCheck },
      { columnName: "Thai", columnField: "CheckListNameThai", cell: (row: ConfinedSpaceCheck) => row.CheckListNameThai },
      { columnName: "English", columnField: "CheckListNameEng", cell: (row: ConfinedSpaceCheck) => row.CheckListNameEng },
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
  onHasCheck(checkBox?: any, rowData?: ConfinedSpaceCheck): void {
    //Debug here
    if (checkBox && rowData) {
      this.returnSelectedWith.emit({
        data: rowData,
        option: 2
      });
    }
  }
}
