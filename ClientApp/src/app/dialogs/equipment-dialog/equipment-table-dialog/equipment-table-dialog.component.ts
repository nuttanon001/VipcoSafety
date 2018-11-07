import { Component, OnInit } from '@angular/core';
import { Equipment } from '../../../groupwork-permits/shared/equipment.model';
import { EquipmentService } from '../../../groupwork-permits/shared/equipment.service';
import { BaseTableMk2Component } from '../../../shared/base-table-mk2.component';
import { AuthService } from '../../../core/auth/auth.service';
import * as moment from "moment";

@Component({
  selector: 'app-equipment-table-dialog',
  templateUrl: './equipment-table-dialog.component.html',
  styleUrls: ['./equipment-table-dialog.component.scss']
})
export class EquipmentTableDialogComponent extends BaseTableMk2Component<Equipment, EquipmentService>{

  constructor(service: EquipmentService, serviceAuth: AuthService) {

    super(service, serviceAuth);
    this.columns = [
      { columnName: "", columnField: "select", cell: undefined },
      { columnName: "NameThai.", columnField: "NameThai", cell: (row: Equipment) => row.NameThai },
      { columnName: "NameEng.", columnField: "NameEng", cell: (row: Equipment) => row.NameEng },
      { columnName: "Description.", columnField: "Description", cell: (row: Equipment) => row.Description },
      { columnName: "Date", columnField: "CreateDate", cell: (row: Equipment) => moment(row.CreateDate).format("DD-MM-YYYY") },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");

    this.isKeyIndex = "SafetyEquipmentId";
    this.isDisabled = true;
  }
}
