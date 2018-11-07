import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiftingTableComponent } from './lifting-table.component';

describe('LiftingTableComponent', () => {
  let component: LiftingTableComponent;
  let fixture: ComponentFixture<LiftingTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiftingTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiftingTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
