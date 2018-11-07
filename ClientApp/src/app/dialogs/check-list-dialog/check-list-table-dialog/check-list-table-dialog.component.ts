import { Component, OnInit } from '@angular/core';
import { BaseTableMk2Component } from '../../../shared/base-table-mk2.component';
import { CheckList } from '../../../groupwork-permits/shared/check-list.model';
import { CheckListService } from '../../../groupwork-permits/shared/check-list.service';
import { AuthService } from '../../../core/auth/auth.service';
import * as moment from "moment";

@Component({
  selector: 'app-check-list-table-dialog',
  templateUrl: './check-list-table-dialog.component.html',
  styleUrls: ['./check-list-table-dialog.component.scss']
})
export class CheckListTableDialogComponent extends BaseTableMk2Component<CheckList, CheckListService>{

  constructor(service: CheckListService, serviceAuth: AuthService) {
    super(service, serviceAuth);

    this.columns = [
      { columnName: "", columnField: "select", cell: undefined },
      { columnName: "NameThai.", columnField: "NameThai", cell: (row: CheckList) => row.NameThai },
      { columnName: "NameEng.", columnField: "NameEng", cell: (row: CheckList) => row.NameEng },
      //{ columnName: "Description.", columnField: "Description", cell: (row: CheckList) => row.Description },
      { columnName: "Date", columnField: "CreateDate", cell: (row: CheckList) => moment(row.CreateDate).format("DD-MM-YYYY") },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");

    this.isKeyIndex = "CheckListId";
    this.isDisabled = true;
  }
}
