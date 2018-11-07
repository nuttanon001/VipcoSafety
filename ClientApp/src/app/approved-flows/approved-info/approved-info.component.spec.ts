import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovedInfoComponent } from './approved-info.component';

describe('ApprovedInfoComponent', () => {
  let component: ApprovedInfoComponent;
  let fixture: ComponentFixture<ApprovedInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApprovedInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApprovedInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
