import { Component, OnInit } from '@angular/core';
import { BaseTableMk2Component } from '../../shared/base-table-mk2.component';
import { ConfinedSpace } from '../shared/confined-space.model';
import { ConfinedSpaceService } from '../shared/confined-space.service';
import { AuthService } from '../../core/auth/auth.service';
import * as moment from "moment";
import { StatusWorkPermit } from '../../shared/basemodel/status-work-permit.enum';
@Component({
  selector: 'app-confined-space-table',
  templateUrl: './confined-space-table.component.html',
  styleUrls: ['./confined-space-table.component.scss']
})
export class ConfinedSpaceTableComponent extends BaseTableMk2Component<ConfinedSpace, ConfinedSpaceService>{

  constructor(service: ConfinedSpaceService, serviceAuth: AuthService) {

    super(service, serviceAuth);
    this.columns = [
      //{ columnName: "", columnField: "select", cell: undefined },
      { columnName: "RequireBy.", columnField: "RequireByEmpName", cell: (row: ConfinedSpace) => row.RequireByEmpName },
      { columnName: "SubContractor.", columnField: "SubContractor", cell: (row: ConfinedSpace) => row.SubContractor },
      { columnName: "Location.", columnField: "Location", cell: (row: ConfinedSpace) => row.Location },
      { columnName: "WorkingDate", columnField: "WpStartDate", cell: (row: ConfinedSpace) => moment(row.WpStartDate).format("DD-MM-YYYY THH:mm") },
      {
        columnName: "Status", columnField: "StatusWorkPermit",
        cell: (row: ConfinedSpace) => row.StatusWorkPermit === StatusWorkPermit.Require ? "Require" :
          (row.StatusWorkPermit === StatusWorkPermit.Approved ? "Approved" : "Cencel")
      },

    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "select");
    this.displayedColumns.splice(0, 0, "Command");

    this.isDisabled = false;
  }
}
