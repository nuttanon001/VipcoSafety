import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupworkPermitCenterComponent } from './groupwork-permit-center.component';

describe('GroupworkPermitCenterComponent', () => {
  let component: GroupworkPermitCenterComponent;
  let fixture: ComponentFixture<GroupworkPermitCenterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GroupworkPermitCenterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupworkPermitCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
