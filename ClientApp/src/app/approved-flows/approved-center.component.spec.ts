import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovedCenterComponent } from './approved-center.component';

describe('ApprovedCenterComponent', () => {
  let component: ApprovedCenterComponent;
  let fixture: ComponentFixture<ApprovedCenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApprovedCenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApprovedCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
