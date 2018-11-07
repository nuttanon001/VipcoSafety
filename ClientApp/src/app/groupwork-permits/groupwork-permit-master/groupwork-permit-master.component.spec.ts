import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupworkPermitMasterComponent } from './groupwork-permit-master.component';

describe('GroupworkPermitMasterComponent', () => {
  let component: GroupworkPermitMasterComponent;
  let fixture: ComponentFixture<GroupworkPermitMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GroupworkPermitMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupworkPermitMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
