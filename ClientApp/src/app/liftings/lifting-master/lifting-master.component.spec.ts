import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiftingMasterComponent } from './lifting-master.component';

describe('LiftingMasterComponent', () => {
  let component: LiftingMasterComponent;
  let fixture: ComponentFixture<LiftingMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiftingMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiftingMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
