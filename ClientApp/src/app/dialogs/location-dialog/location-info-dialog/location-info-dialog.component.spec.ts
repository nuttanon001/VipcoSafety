import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LocationInfoDialogComponent } from './location-info-dialog.component';

describe('LocationInfoDialogComponent', () => {
  let component: LocationInfoDialogComponent;
  let fixture: ComponentFixture<LocationInfoDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LocationInfoDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LocationInfoDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
