import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LocationTableDialogComponent } from './location-table-dialog.component';

describe('LocationTableDialogComponent', () => {
  let component: LocationTableDialogComponent;
  let fixture: ComponentFixture<LocationTableDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LocationTableDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LocationTableDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
