// Angular Core
import { Injectable, ViewContainerRef } from "@angular/core";
import { MatDialogRef, MatDialog, MatDialogConfig } from "@angular/material";
// rxjs
import { Observable } from "rxjs";
// module
import { Employee } from "../../employees/shared/employee.model";
import { ProjectSub } from "../../projects/shared/project-sub.model";
import { ProjectMaster } from "../../projects/shared/project-master.model";
import { EmployeeGroup } from "../../employees/shared/employee-group.model";
import { EmployeeGroupMis } from "../../employees/shared/employee-group-mis.model";
// components
import { ErrorDialog } from "../error-dialog/error-dialog.component";
import { ConfirmDialog } from "../confirm-dialog/confirm-dialog.component";
import { ContextDialog } from "../context-dialog/context-dialog.component";
import { GroupDialogComponent } from "../group-dialog/group-dialog.component";
import { ProjectDialogComponent } from "../project-dialog/project-dialog.component";
import { GroupmisDialogComponent } from "../groupmis-dialog/groupmis-dialog.component";
import { EmployeeDialogComponent } from "../employee-dialog/employee-dialog.component";
import { ProjectSubDialogComponent } from "../project-sub-dialog/project-sub-dialog.component";
import { ConfirmMessageDialogComponent } from "../confirm-message-dialog/confirm-message-dialog.component";
import { CheckList } from "../../groupwork-permits/shared/check-list.model";
import { CheckListDialogComponent } from "../check-list-dialog/check-list-dialog.component";
import { Equipment } from "../../groupwork-permits/shared/equipment.model";
import { EquipmentDialogComponent } from "../equipment-dialog/equipment-dialog.component";
import { LocationDialogComponent } from "../location-dialog/location-dialog.component";
import { Location } from "../../locations/shared/location.model";

@Injectable()
export class DialogsService {
  // width and height > width and height in scss master-dialog
  width: string = "80vh";
  height: string = "80vw";

  constructor(private dialog: MatDialog) { }

  public confirm(title: string, message: string, viewContainerRef: ViewContainerRef): Observable<boolean> {

    let dialogRef: MatDialogRef<ConfirmDialog>;
    let config: MatDialogConfig = new MatDialogConfig();
    config.viewContainerRef = viewContainerRef;

    dialogRef = this.dialog.open(ConfirmDialog, config);

    dialogRef.componentInstance.title = title;
    dialogRef.componentInstance.message = message;

    return dialogRef.afterClosed();
  }

  public context(title: string, message: string, viewContainerRef: ViewContainerRef): Observable<boolean> {

    let dialogRef: MatDialogRef<ContextDialog>;
    let config: MatDialogConfig = new MatDialogConfig();
    config.viewContainerRef = viewContainerRef;

    dialogRef = this.dialog.open(ContextDialog, config);

    dialogRef.componentInstance.title = title;
    dialogRef.componentInstance.message = message;

    return dialogRef.afterClosed();
  }

  public error(title: string, message: string, viewContainerRef: ViewContainerRef): Observable<boolean> {

    let dialogRef: MatDialogRef<ErrorDialog>;
    let config: MatDialogConfig = new MatDialogConfig();
    config.viewContainerRef = viewContainerRef;

    dialogRef = this.dialog.open(ErrorDialog, config);

    dialogRef.componentInstance.title = title;
    dialogRef.componentInstance.message = message;

    return dialogRef.afterClosed();
  }

  public confirmMessage(title: string, message: string, viewContainerRef: ViewContainerRef): Observable<{ result: boolean, message: string }> {

    let dialogRef: MatDialogRef<ConfirmMessageDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();
    config.viewContainerRef = viewContainerRef;

    dialogRef = this.dialog.open(ConfirmMessageDialogComponent, config);

    dialogRef.componentInstance.title = title;
    dialogRef.componentInstance.message = message;

    return dialogRef.afterClosed();
  }

  /**
   * 
   * @param viewContainerRef
   * @param type = mode of project dialog
   */
  public dialogSelectProject(viewContainerRef: ViewContainerRef, type: number = 0): Observable<ProjectMaster | ProjectSub> {
    let dialogRef: MatDialogRef<ProjectDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = type;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(ProjectDialogComponent, config);
    return dialogRef.afterClosed();
  }
  /**
   * Group Mis
   * @param viewContainerRef
   * @param type = mode 0:fastSelected
   */
  public dialogSelectGroupMis(viewContainerRef: ViewContainerRef, type: number = 0): Observable<EmployeeGroupMis> {
    let dialogRef: MatDialogRef<GroupmisDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = type;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(GroupmisDialogComponent, config);
    return dialogRef.afterClosed();
  }
  /**
   * Group Mis
   * @param viewContainerRef
   * @param type = mode 0:fastSelected
   */
  public dialogSelectGroupMises(viewContainerRef: ViewContainerRef, type: number = 1): Observable<Array<EmployeeGroupMis>> {
    let dialogRef: MatDialogRef<GroupmisDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = type;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(GroupmisDialogComponent, config);
    return dialogRef.afterClosed();
  }
  /**
   * @param viewContainerRef
   * @param type = mode 0:fastSelected
   */
  public dialogSelectEmployee(viewContainerRef: ViewContainerRef, type: number = 0): Observable<Employee> {
    let dialogRef: MatDialogRef<EmployeeDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = {
      groupCode: "",
      mode: type
    };
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(EmployeeDialogComponent, config);
    return dialogRef.afterClosed();
  }
  /**
   * @param viewContainerRef
   * @param type = mode 0:fastSelected
   */
  public dialogSelectEmployees(viewContainerRef: ViewContainerRef, groupCode:string = "" ,type: number = 1): Observable<Array<Employee>> {
    let dialogRef: MatDialogRef<EmployeeDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = {
      groupCode: groupCode,
      mode: type
    };
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(EmployeeDialogComponent, config);
    return dialogRef.afterClosed();
  }
  /**
   * @param viewContainerRef
   * @param projectSub = ProjectSub
   */
  public dialogProjectSubInfo(viewContainerRef: ViewContainerRef, projectSub: ProjectSub = undefined): Observable<ProjectSub> {
    let dialogRef: MatDialogRef<ProjectSubDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = projectSub;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(ProjectSubDialogComponent, config);
    return dialogRef.afterClosed();
  }

  /**
 * Group
 * @param viewContainerRef
 * @param type = mode 0:fastSelected
 */
  public dialogSelectGroup(viewContainerRef: ViewContainerRef, type: number = 0): Observable<EmployeeGroup|Array<EmployeeGroup>> {
    let dialogRef: MatDialogRef<GroupDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = type;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(GroupDialogComponent, config);
    return dialogRef.afterClosed();
  }

  /**
* @param viewContainerRef
* @param type = mode 0:fastSelected
*/
  public dialogInfoCheckList(viewContainerRef: ViewContainerRef, mode: number = 0): Observable<CheckList|Array<CheckList>> {
    let dialogRef: MatDialogRef<CheckListDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = mode;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(CheckListDialogComponent, config);
    return dialogRef.afterClosed();
  }

  /**
* @param viewContainerRef
* @param type = mode 0:fastSelected
*/
  public dialogInfoEquipment(viewContainerRef: ViewContainerRef, mode: number = 0): Observable<Equipment| Array<Equipment>> {
    let dialogRef: MatDialogRef<EquipmentDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = mode;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(EquipmentDialogComponent, config);
    return dialogRef.afterClosed();
  }

  /**
  * @param viewContainerRef
  * @param type = mode 0:fastSelected
  */
  public dialogInfoLocation(viewContainerRef: ViewContainerRef, mode: number = 0): Observable<Location | Array<Location>> {
    let dialogRef: MatDialogRef<LocationDialogComponent>;
    let config: MatDialogConfig = new MatDialogConfig();

    // config
    config.viewContainerRef = viewContainerRef;
    config.data = mode;
    // config.height = this.height;
    // config.width= this.width;
    config.hasBackdrop = true;

    // open dialog
    dialogRef = this.dialog.open(LocationDialogComponent, config);
    return dialogRef.afterClosed();
  }
}
