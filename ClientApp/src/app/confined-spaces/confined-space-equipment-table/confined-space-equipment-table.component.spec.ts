import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfinedSpaceEquipmentTableComponent } from './confined-space-equipment-table.component';

describe('ConfinedSpaceEquipmentTableComponent', () => {
  let component: ConfinedSpaceEquipmentTableComponent;
  let fixture: ComponentFixture<ConfinedSpaceEquipmentTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfinedSpaceEquipmentTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfinedSpaceEquipmentTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
