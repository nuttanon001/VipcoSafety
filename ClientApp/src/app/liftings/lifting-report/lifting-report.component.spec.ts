import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiftingReportComponent } from './lifting-report.component';

describe('LiftingReportComponent', () => {
  let component: LiftingReportComponent;
  let fixture: ComponentFixture<LiftingReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiftingReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiftingReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
