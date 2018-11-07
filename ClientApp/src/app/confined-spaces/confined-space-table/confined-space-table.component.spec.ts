import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfinedSpaceTableComponent } from './confined-space-table.component';

describe('ConfinedSpaceTableComponent', () => {
  let component: ConfinedSpaceTableComponent;
  let fixture: ComponentFixture<ConfinedSpaceTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfinedSpaceTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfinedSpaceTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
