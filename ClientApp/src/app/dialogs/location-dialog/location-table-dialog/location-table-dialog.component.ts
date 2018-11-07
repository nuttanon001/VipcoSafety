import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../core/auth/auth.service';
import { Location } from '../../../locations/shared/location.model';
import { LocationService } from '../../../locations/shared/location.service';
import { BaseTableMk2Component } from '../../../shared/base-table-mk2.component';

@Component({
  selector: 'app-location-table-dialog',
  templateUrl: './location-table-dialog.component.html',
  styleUrls: ['./location-table-dialog.component.scss']
})
export class LocationTableDialogComponent extends BaseTableMk2Component<Location, LocationService>{
  constructor(service: LocationService, serviceAuth: AuthService) {
    super(service, serviceAuth);
    this.columns = [
      { columnName: "", columnField: "select", cell: undefined },
      { columnName: "Name.", columnField: "Name", cell: (row: Location) => row.Name },
      { columnName: "Description.", columnField: "Description", cell: (row: Location) => row.Description },
    ];
    this.displayedColumns = this.columns.map(x => x.columnField);
    this.displayedColumns.splice(0, 0, "Command");

    this.isKeyIndex = "LocationId";
    this.isDisabled = true;
  }
}
