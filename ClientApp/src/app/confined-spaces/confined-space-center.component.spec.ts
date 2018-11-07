import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfinedSpaceCenterComponent } from './confined-space-center.component';

describe('ConfinedSpaceCenterComponent', () => {
  let component: ConfinedSpaceCenterComponent;
  let fixture: ComponentFixture<ConfinedSpaceCenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfinedSpaceCenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfinedSpaceCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
