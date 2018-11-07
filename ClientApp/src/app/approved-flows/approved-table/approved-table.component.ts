import { Component, OnInit } from '@angular/core';
import { BaseTableMk2Component } from '../../shared/base-table-mk2.component';
import { ApprovdFlow } from '../shared/approvd-flow.model';
import { ApprovdFlowService } from '../shared/approvd-flow.service';
import { AuthService } from '../../core/auth/auth.service';
import * as moment from "moment";

@Component({
  selector: 'app-approved-table',
  templateUrl: './approved-table.component.html',
  styleUrls: ['./approved-table.component.scss']
})
export class ApprovedTableComponent extends BaseTableMk2Component<ApprovdFlow, ApprovdFlowService>{

  constructor(service: ApprovdFlowService, serviceAuth: AuthService) {

    super(service, serviceAuth);
    this.columns = [
      { columnName: "", columnField: "select", cell: undefined },
      { columnName: "ApprovedBy.", columnField: "ApprovedByNameThai", cell: (row: ApprovdFlow) => row.ApprovedByNameThai },
      { columnName: "Date", columnField: "CreateDate", cell: (row: ApprovdFlow) => moment(row.CreateDate).format("DD-MM-YYYY") },
    ];

    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");

    this.isDisabled = false;
  }
}
