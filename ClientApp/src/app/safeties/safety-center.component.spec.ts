import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SafetyCenterComponent } from './safety-center.component';

describe('SafetyCenterComponent', () => {
  let component: SafetyCenterComponent;
  let fixture: ComponentFixture<SafetyCenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SafetyCenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SafetyCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
