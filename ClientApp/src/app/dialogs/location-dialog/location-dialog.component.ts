import { Component, OnInit, Inject } from '@angular/core';
import { BaseDialogEntryComponent } from '../../shared/base-dialog-entry.component';
import { LocationService } from '../../locations/shared/location.service';
import { AuthService } from '../../core/auth/auth.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Location } from '../../locations/shared/location.model';

@Component({
  selector: 'app-location-dialog',
  templateUrl: './location-dialog.component.html',
  styleUrls: ['./location-dialog.component.scss'],
  providers: [LocationService]
})
export class LocationDialogComponent extends BaseDialogEntryComponent<Location, LocationService> {
  /** employee-dialog ctor */
  constructor(
    service: LocationService,
    serviceAuth: AuthService,
    public dialogRef: MatDialogRef<LocationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public mode: number
  ) {
    super(
      service,
      serviceAuth,
      dialogRef
    );
  }

  // on init
  onInit(): void {
    this.fastSelectd = this.mode === 0 ? true : false;
  }

  // on new entity
  onNewEntity(): void {
    this.InfoValue = {
      LocationId: 0,
    };
  }

}
