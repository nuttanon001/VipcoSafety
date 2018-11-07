import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfinedSpaceChecklistTableComponent } from './confined-space-checklist-table.component';

describe('ConfinedSpaceChecklistTableComponent', () => {
  let component: ConfinedSpaceChecklistTableComponent;
  let fixture: ComponentFixture<ConfinedSpaceChecklistTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfinedSpaceChecklistTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfinedSpaceChecklistTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
