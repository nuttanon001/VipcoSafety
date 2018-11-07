import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupworkPermitInfoComponent } from './groupwork-permit-info.component';

describe('GroupworkPermitInfoComponent', () => {
  let component: GroupworkPermitInfoComponent;
  let fixture: ComponentFixture<GroupworkPermitInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GroupworkPermitInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupworkPermitInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
