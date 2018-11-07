import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiftingCenterComponent } from './lifting-center.component';

describe('LiftingCenterComponent', () => {
  let component: LiftingCenterComponent;
  let fixture: ComponentFixture<LiftingCenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiftingCenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiftingCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
