import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SafetyMasterComponent } from './safety-master.component';

describe('SafetyMasterComponent', () => {
  let component: SafetyMasterComponent;
  let fixture: ComponentFixture<SafetyMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SafetyMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SafetyMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
