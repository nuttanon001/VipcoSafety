import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfinedSpaceEmphelpTableComponent } from './confined-space-emphelp-table.component';

describe('ConfinedSpaceEmphelpTableComponent', () => {
  let component: ConfinedSpaceEmphelpTableComponent;
  let fixture: ComponentFixture<ConfinedSpaceEmphelpTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfinedSpaceEmphelpTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfinedSpaceEmphelpTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
