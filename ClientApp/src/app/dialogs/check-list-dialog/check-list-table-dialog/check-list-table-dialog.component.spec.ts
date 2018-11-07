import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckListTableDialogComponent } from './check-list-table-dialog.component';

describe('CheckListTableDialogComponent', () => {
  let component: CheckListTableDialogComponent;
  let fixture: ComponentFixture<CheckListTableDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CheckListTableDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckListTableDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
