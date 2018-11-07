import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ApprovedCenterComponent } from './approved-center.component';
import { ApprovedMasterComponent } from './approved-master/approved-master.component';

const routes: Routes = [{
  path: "", 
  component: ApprovedCenterComponent,
  children: [
    {
      path: ":key",
      component: ApprovedMasterComponent,
    },
    {
      path: "",
      component: ApprovedMasterComponent,
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApprovedFlowRoutingModule { }
