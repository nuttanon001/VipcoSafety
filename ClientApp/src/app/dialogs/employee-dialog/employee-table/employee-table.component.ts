// Angular Core
import { Component } from "@angular/core";
// Components
import { BaseTableComponent } from "../../../shared/base-table.component";
// Models
import { Employee } from "../../../employees/shared/employee.model";
// Services
import { EmployeeService } from "../../../employees/shared/employee.service";
import { AuthService } from "../../../core/auth/auth.service";
import { BaseTableMk2Component } from "../../../shared/base-table-mk2.component";

@Component({
  selector: "dialog-employee-table",
  templateUrl: "./employee-table.component.html",
  styleUrls: ["./employee-table.component.scss"]
})
export class EmployeeTableComponent extends BaseTableMk2Component<Employee, EmployeeService> {

  constructor(service: EmployeeService, serviceAuth: AuthService) {
    super(service, serviceAuth);
    this.displayedColumns = ["select", "EmpCode", "NameThai", "GroupName"];
    this.columns = [
      { columnName: "", columnField: "select", cell: undefined },
      { columnName: "EmpCode.", columnField: "EmpCode", cell: (row: Employee) => row.EmpCode },
      { columnName: "NameThai.", columnField: "NameThai", cell: (row: Employee) => row.NameThai },
      { columnName: "GroupName.", columnField: "GroupName", cell: (row: Employee) => row.GroupName },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");
    this.isKeyIndex = "EmpCode";
    this.isDisabled = true;
  }
}
