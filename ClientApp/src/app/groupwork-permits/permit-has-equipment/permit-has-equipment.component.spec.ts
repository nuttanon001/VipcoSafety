import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PermitHasEquipmentComponent } from './permit-has-equipment.component';

describe('PermitHasEquipmentComponent', () => {
  let component: PermitHasEquipmentComponent;
  let fixture: ComponentFixture<PermitHasEquipmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PermitHasEquipmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PermitHasEquipmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
