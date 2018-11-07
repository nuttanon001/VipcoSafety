import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupworkPermitTableComponent } from './groupwork-permit-table.component';

describe('GroupworkPermitTableComponent', () => {
  let component: GroupworkPermitTableComponent;
  let fixture: ComponentFixture<GroupworkPermitTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GroupworkPermitTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupworkPermitTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
