import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiftingPercautionTableComponent } from './lifting-percaution-table.component';

describe('LiftingPercautionTableComponent', () => {
  let component: LiftingPercautionTableComponent;
  let fixture: ComponentFixture<LiftingPercautionTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiftingPercautionTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiftingPercautionTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
