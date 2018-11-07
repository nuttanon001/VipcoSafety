import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PermitHasChecklistComponent } from './permit-has-checklist.component';

describe('PermitHasChecklistComponent', () => {
  let component: PermitHasChecklistComponent;
  let fixture: ComponentFixture<PermitHasChecklistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PermitHasChecklistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PermitHasChecklistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
