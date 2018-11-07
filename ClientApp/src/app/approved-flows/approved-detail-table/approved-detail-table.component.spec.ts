import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovedDetailTableComponent } from './approved-detail-table.component';

describe('ApprovedDetailTableComponent', () => {
  let component: ApprovedDetailTableComponent;
  let fixture: ComponentFixture<ApprovedDetailTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApprovedDetailTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApprovedDetailTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
