import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckListInfoDialogComponent } from './check-list-info-dialog.component';

describe('CheckListInfoDialogComponent', () => {
  let component: CheckListInfoDialogComponent;
  let fixture: ComponentFixture<CheckListInfoDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CheckListInfoDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckListInfoDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
