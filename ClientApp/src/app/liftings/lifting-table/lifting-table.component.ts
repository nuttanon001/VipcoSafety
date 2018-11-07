import { Component, OnInit } from '@angular/core';
import { BaseTableMk2Component } from '../../shared/base-table-mk2.component';
import { Lifting } from '../shared/lifting.model';
import { LiftingService } from '../shared/lifting.service';
import { AuthService } from '../../core/auth/auth.service';
import { StatusWorkPermit } from '../../shared/basemodel/status-work-permit.enum';
import * as moment from "moment";

@Component({
  selector: 'app-lifting-table',
  templateUrl: './lifting-table.component.html',
  styleUrls: ['./lifting-table.component.scss']
})
export class LiftingTableComponent extends BaseTableMk2Component<Lifting, LiftingService>{

  constructor(service: LiftingService, serviceAuth: AuthService) {

    super(service, serviceAuth);
    this.columns = [
      //{ columnName: "", columnField: "select", cell: undefined },
      { columnName: "RequireBy.", columnField: "RequireByEmpName", cell: (row: Lifting) => row.RequireByEmpName },
      { columnName: "WorkGroup.", columnField: "WorkGroup", cell: (row: Lifting) => row.WorkGroup },
      { columnName: "Location.", columnField: "Location", cell: (row: Lifting) => row.Location },
      { columnName: "WorkingDate", columnField: "WpStartDate", cell: (row: Lifting) => moment(row.LiftDate).format("DD-MM-YYYY THH:mm") },
      {
        columnName: "Status", columnField: "StatusWorkPermit",
        cell: (row: Lifting) => row.StatusWorkPermit === StatusWorkPermit.Require ? "Require" :
          (row.StatusWorkPermit === StatusWorkPermit.Approved ? "Approved" : "Cencel")
      },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "select");
    this.displayedColumns.splice(0, 0, "Command");

    this.isDisabled = false;
  }
}
