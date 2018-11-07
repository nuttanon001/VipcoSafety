import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiftingChecklistTableComponent } from './lifting-checklist-table.component';

describe('LiftingChecklistTableComponent', () => {
  let component: LiftingChecklistTableComponent;
  let fixture: ComponentFixture<LiftingChecklistTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiftingChecklistTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiftingChecklistTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
