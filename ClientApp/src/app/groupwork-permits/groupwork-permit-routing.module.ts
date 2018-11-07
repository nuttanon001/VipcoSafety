import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GroupworkPermitCenterComponent } from './groupwork-permit-center.component';
import { GroupworkPermitMasterComponent } from './groupwork-permit-master/groupwork-permit-master.component';

const routes: Routes = [{
  path: "",
  component: GroupworkPermitCenterComponent,
  children: [
    {
      path: ":key",
      component: GroupworkPermitMasterComponent,
    },
    {
      path: "",
      component: GroupworkPermitMasterComponent,
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GroupworkPermitRoutingModule { }
