import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentTableDialogComponent } from './equipment-table-dialog.component';

describe('EquipmentTableDialogComponent', () => {
  let component: EquipmentTableDialogComponent;
  let fixture: ComponentFixture<EquipmentTableDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EquipmentTableDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EquipmentTableDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
