import { Component, OnInit } from '@angular/core';
import { BaseTableMk2Component } from '../../shared/base-table-mk2.component';
import { GroupworkPermit } from '../shared/groupwork-permit.model';
import { GroupworkPermitService } from '../shared/groupwork-permit.service';
import { AuthService } from '../../core/auth/auth.service';
import * as moment from "moment";

@Component({
  selector: 'app-groupwork-permit-table',
  templateUrl: './groupwork-permit-table.component.html',
  styleUrls: ['./groupwork-permit-table.component.scss']
})

export class GroupworkPermitTableComponent extends BaseTableMk2Component<GroupworkPermit, GroupworkPermitService>{

  constructor(service: GroupworkPermitService, serviceAuth: AuthService) {

    super(service, serviceAuth);
    this.columns = [
      { columnName: "", columnField: "select", cell: undefined },
      { columnName: "Name.", columnField: "Name", cell: (row: GroupworkPermit) => row.Name },
      { columnName: "Description.", columnField: "Description", cell: (row: GroupworkPermit) => row.Description },
      { columnName: "Date", columnField: "CreateDate", cell: (row: GroupworkPermit) => moment(row.CreateDate).format("DD-MM-YYYY") },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");

    this.isDisabled = false;
  }
}
