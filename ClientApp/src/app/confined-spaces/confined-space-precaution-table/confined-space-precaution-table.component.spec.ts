import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfinedSpacePrecautionTableComponent } from './confined-space-precaution-table.component';

describe('ConfinedSpacePrecautionTableComponent', () => {
  let component: ConfinedSpacePrecautionTableComponent;
  let fixture: ComponentFixture<ConfinedSpacePrecautionTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfinedSpacePrecautionTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfinedSpacePrecautionTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
