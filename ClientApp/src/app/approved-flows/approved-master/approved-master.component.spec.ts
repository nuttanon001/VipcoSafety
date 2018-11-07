import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovedMasterComponent } from './approved-master.component';

describe('ApprovedMasterComponent', () => {
  let component: ApprovedMasterComponent;
  let fixture: ComponentFixture<ApprovedMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApprovedMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApprovedMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
