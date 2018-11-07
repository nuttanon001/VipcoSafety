import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CenterAllWorkPermitComponent } from './center-all-work-permit.component';

describe('CenterAllWorkPermitComponent', () => {
  let component: CenterAllWorkPermitComponent;
  let fixture: ComponentFixture<CenterAllWorkPermitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CenterAllWorkPermitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CenterAllWorkPermitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
