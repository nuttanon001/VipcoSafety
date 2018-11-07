import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfinedSpaceMasterComponent } from './confined-space-master.component';

describe('ConfinedSpaceMasterComponent', () => {
  let component: ConfinedSpaceMasterComponent;
  let fixture: ComponentFixture<ConfinedSpaceMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfinedSpaceMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfinedSpaceMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
