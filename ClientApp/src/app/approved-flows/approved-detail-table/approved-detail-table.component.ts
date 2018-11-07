import { Component, OnInit } from '@angular/core';
import { BaseTableDetailMk2Component } from '../../shared/base-table-detail-mk2.component';
import { ApprovdFlowDetail } from '../shared/approvd-flow-detail.model';

@Component({
  selector: 'app-approved-detail-table',
  templateUrl: './approved-detail-table.component.html',
  styleUrls: ['./approved-detail-table.component.scss']
})
export class ApprovedDetailTableComponent extends BaseTableDetailMk2Component<ApprovdFlowDetail>{

  constructor() {
    super();
    this.columns = [
      { columnName: "", columnField: "select", cell: undefined },
      { columnName: "Code.", columnField: "ApprovedByNameThai", cell: (row: ApprovdFlowDetail) => row.GroupMis },
      { columnName: "GroupName", columnField: "CreateDate", cell: (row: ApprovdFlowDetail) => row.GroupMisName },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");
  }
}
