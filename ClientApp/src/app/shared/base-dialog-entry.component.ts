import { Component, OnInit, Inject, ViewChild } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material";
// models
import { Scroll } from "./scroll.model";
// rxjs
import { Observable, Subscription } from "rxjs";
import { BaseModel } from "./base-model.model";
import { BaseRestService } from "./base-rest.service";
import { AuthService } from "../core/auth/auth.service";
// 3rd party
// import { DatatableComponent, TableColumn } from "@swimlane/ngx-datatable";

/** base-dialog component*/
export abstract class BaseDialogEntryComponent<Model extends BaseModel, Service extends BaseRestService<Model>> implements OnInit {
  getValue: Model;
  getValues: Array<Model>;
  fastSelectd: boolean = false;
  /** cutting-plan-dialog ctor */
  constructor(
    protected service: Service,
    protected serviceAuth: AuthService,
    protected dialogRef: MatDialogRef<any>
  ) { }

  // Parameter
  InfoValue: Model;

  /** Called by Angular after cutting-plan-dialog component initialized */
  ngOnInit(): void {
    this.onInit();
  }

  // on Init data
  abstract onInit(): void;

  // Selected Value
  onSelectedValue(value?: Model): void {
    // console.log("OnSelectedValue", JSON.stringify(value));
    if (value) {
      this.getValue = value;
      if (this.fastSelectd) {
        this.onSelectedClick();
      }
    }
  }

  onSelectedValues(values?: Array<Model>): void {
    if (values) {
      this.getValues = new Array;
      this.getValues = [...values];
    }
  }

  // No Click
  onCancelClick(): void {
    this.dialogRef.close();
  }

  // Update Click
  onSelectedClick(): void {
    if (this.getValue) {
      this.dialogRef.close(this.getValue);
    } else if (this.getValues) {
      this.dialogRef.close(this.getValues);
    }
  }

  // on new entity
  abstract onNewEntity(): void;

  // on complate or cancel entity
  onComplateOrCancelEntity(infoValue?: { data: Model | undefined, force: boolean }): void {
    if (infoValue) {
      if (infoValue.data.CreateDate) {
        infoValue.data.Modifyer = this.serviceAuth.getAuth.UserName || "-";

        //debug here
        console.log(JSON.stringify(infoValue));

        this.service.updateModelWithKey(infoValue.data)
          .subscribe(dbData => {
            if (dbData) {
              if (this.fastSelectd) {
                this.dialogRef.close(dbData);
              } else {
                this.dialogRef.close([dbData]);
              }
            }
          });
      } else {
        infoValue.data.Creator = this.serviceAuth.getAuth.UserName || "-";
        this.service.addModel(infoValue.data)
          .subscribe(dbData => {
            if (dbData) {
              if (this.fastSelectd) {
                this.dialogRef.close(dbData);
              } else {
                this.dialogRef.close([dbData]);
              }
            }
          });
      }
    } else {
      this.InfoValue = undefined;
    }
  }

  // on detail view
  onEditInfo(value?: { data: Model, option: number }): void {
    if (value) {
      if (value.option === 1) {
        this.InfoValue = value.data;
      }
    }
  }
}
