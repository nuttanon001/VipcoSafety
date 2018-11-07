import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfinedSpaceEmpworkTableComponent } from './confined-space-empwork-table.component';

describe('ConfinedSpaceEmpworkTableComponent', () => {
  let component: ConfinedSpaceEmpworkTableComponent;
  let fixture: ComponentFixture<ConfinedSpaceEmpworkTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfinedSpaceEmpworkTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfinedSpaceEmpworkTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
