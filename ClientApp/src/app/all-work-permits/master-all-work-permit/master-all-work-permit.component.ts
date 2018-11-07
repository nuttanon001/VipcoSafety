import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { BaseScheduleComponent } from '../../shared/base-schedule.component';
import { AllWorkPermit } from '../shared/all-work-permit.model';
import { AllWorkPermitService } from '../shared/all-work-permit.service';
import { FormBuilder } from '@angular/forms';
import { DialogsService } from '../../dialogs/shared/dialogs.service';
import { Scroll } from '../../shared/scroll.model';
import { ScrollData } from '../../shared/scroll-data.model';
import { ColumnType } from '../../shared/my-colmun.model';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-master-all-work-permit',
  templateUrl: './master-all-work-permit.component.html',
  styleUrls: ['./master-all-work-permit.component.scss']
})
export class MasterAllWorkPermitComponent extends BaseScheduleComponent<AllWorkPermit,AllWorkPermitService> {

  constructor(
    service: AllWorkPermitService,
    fb: FormBuilder,
    viewCon: ViewContainerRef,
    serviceDialogs: DialogsService,
    private serviceAuth:AuthService,
  ) {
    super(service, fb, viewCon, serviceDialogs);
    const toDay = new Date;
    this.scroll = {
      EDate: new Date(toDay.getFullYear(), toDay.getMonth() + 1, 0),
      SDate: new Date(toDay.getFullYear(), toDay.getMonth() - 1, 1),
    };
  }

  // get request data
  onGetData(schedule: Scroll): void {
    this.service.getAllWithScroll(schedule)
      .subscribe((dbData: ScrollData<AllWorkPermit>) => {
        if (!dbData) {
          this.totalRecords = 0;
          this.columns = new Array;
          this.datasource = new Array;
          this.reloadData();
          this.loading = false;
          return;
        }

        if (dbData.Scroll) {
          this.totalRecords = dbData.Scroll.TotalRow || 0;
        } else {
          this.totalRecords = 0;
        }

        // new Column Array
        this.columns = new Array;
        this.columns = [
          { field: 'Command', header: '', width: 75, type: ColumnType.Option },
          { field: 'GroupWPName', header: 'WorkPermit', width: 175, type: ColumnType.Show },
          { field: 'RequireByName', header: 'RequireBy', width: 125, type: ColumnType.Show },
          { field: 'WorkPermitDateString', header: 'Date', width: 90, type: ColumnType.Show },
          { field: 'StatusWorkPermitString', header: 'Status', width: 90, type: ColumnType.Show },
          { field: 'ComplateString', header: 'ComplateBy', width: 125, type: ColumnType.Show },
          { field: 'ComplateDateString', header: 'ComplateDate', width: 100, type: ColumnType.Show },
        ];

        if (dbData.Data) {
          this.datasource = dbData.Data.slice();
        } else {
          this.datasource = new Array;
        }

        if (this.needReset) {
          this.first = 0;
          this.needReset = false;
        }

        this.reloadData();
      }, error => {
        this.totalRecords = 0;
        this.columns = new Array;
        this.datasource = new Array;
        this.reloadData();
      }, () => this.loading = false);
  }

  // reset
  resetFilter(): void {
    this.datasource = new Array;
    const toDay = new Date;
    this.scroll = {
      EDate: new Date(toDay.getFullYear(), toDay.getMonth() + 1, 0),
      SDate: new Date(toDay.getFullYear(), toDay.getMonth() - 1, 1),
    };
    // this.loading = true;
    this.buildForm();
    this.onGetData(this.scroll);
  }

  // Open Dialog
  onShowDialog(type?: string): void {
    if (type.indexOf("Employee") !== -1) {
      this.serviceDialogs.dialogSelectEmployee(this.viewCon)
        .subscribe(employee => {
          this.reportForm.patchValue({
            Where: employee.EmpCode,
            Where2: employee.NameThai,
          });
        });
    }
  }

  onComplate(rowData?: AllWorkPermit,value?:boolean):void {
    if (rowData) {
      this.loading = true;
      rowData.IsCancel = value;
      rowData.ComplateString = this.serviceAuth.getAuth.NameThai;
      rowData.ComplateBy = this.serviceAuth.getAuth.UserName;
      // debug here
      console.log(JSON.stringify(rowData));

      this.service.setComplate(rowData)
        .subscribe(result => {
          this.onGetData(this.scroll);
        }, () => { }, () => this.loading = false);
    }
  }
}
