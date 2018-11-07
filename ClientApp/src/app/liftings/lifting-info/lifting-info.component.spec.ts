import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiftingInfoComponent } from './lifting-info.component';

describe('LiftingInfoComponent', () => {
  let component: LiftingInfoComponent;
  let fixture: ComponentFixture<LiftingInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiftingInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiftingInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
