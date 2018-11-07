import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SafetyInfoComponent } from './safety-info.component';

describe('SafetyInfoComponent', () => {
  let component: SafetyInfoComponent;
  let fixture: ComponentFixture<SafetyInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SafetyInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SafetyInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
