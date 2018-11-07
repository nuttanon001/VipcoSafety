// angular
import { Component, Inject, ViewChild, OnDestroy } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material";
// models
import { Employee } from "../../employees/shared/employee.model";
// service
import { EmployeeService } from "../../employees/shared/employee.service";
// rxjs
import { Observable, Subscription } from "rxjs";
// base-component
import { BaseDialogComponent } from "../../shared/base-dialog.component";

@Component({
  selector: "employee-dialog",
  templateUrl: "./employee-dialog.component.html",
  styleUrls: ["../../shared/styles/master.style.scss"],
  providers: [
    EmployeeService,
  ]
})
/** employee-dialog component*/
export class EmployeeDialogComponent
  extends BaseDialogComponent<Employee, EmployeeService> {
  /** employee-dialog ctor */
  constructor(
    public service: EmployeeService,
    public dialogRef: MatDialogRef<EmployeeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {groupCode?:string,mode?:number}
  ) {
    super(
      service,
      dialogRef
    );
  }
  mode?: number;
  groupCode?: string;
  // on init
  onInit(): void {
    this.mode = this.data ? this.data.mode : 0;
    // debug here
    // console.log(this.mode);

    this.groupCode = this.data ? this.data.groupCode : "";
    this.fastSelectd = this.data.mode === 0 ? true : false;
  }
}
