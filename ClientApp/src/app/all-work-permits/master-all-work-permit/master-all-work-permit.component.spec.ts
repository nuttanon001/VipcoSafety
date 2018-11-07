import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MasterAllWorkPermitComponent } from './master-all-work-permit.component';

describe('MasterAllWorkPermitComponent', () => {
  let component: MasterAllWorkPermitComponent;
  let fixture: ComponentFixture<MasterAllWorkPermitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MasterAllWorkPermitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MasterAllWorkPermitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
