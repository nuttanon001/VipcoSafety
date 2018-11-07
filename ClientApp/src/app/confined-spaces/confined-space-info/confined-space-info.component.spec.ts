import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfinedSpaceInfoComponent } from './confined-space-info.component';

describe('ConfinedSpaceInfoComponent', () => {
  let component: ConfinedSpaceInfoComponent;
  let fixture: ComponentFixture<ConfinedSpaceInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfinedSpaceInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfinedSpaceInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
