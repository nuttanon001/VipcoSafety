import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiftingEquipmentTableComponent } from './lifting-equipment-table.component';

describe('LiftingEquipmentTableComponent', () => {
  let component: LiftingEquipmentTableComponent;
  let fixture: ComponentFixture<LiftingEquipmentTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiftingEquipmentTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiftingEquipmentTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
