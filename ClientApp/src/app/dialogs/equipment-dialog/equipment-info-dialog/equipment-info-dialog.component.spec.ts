import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentInfoDialogComponent } from './equipment-info-dialog.component';

describe('EquipmentInfoDialogComponent', () => {
  let component: EquipmentInfoDialogComponent;
  let fixture: ComponentFixture<EquipmentInfoDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EquipmentInfoDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EquipmentInfoDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
