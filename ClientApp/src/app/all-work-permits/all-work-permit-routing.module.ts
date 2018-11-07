import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CenterAllWorkPermitComponent } from './center-all-work-permit.component';
import { MasterAllWorkPermitComponent } from './master-all-work-permit/master-all-work-permit.component';

const routes: Routes = [{
  path: "",
  component: CenterAllWorkPermitComponent,
  children: [
    {
      path: ":key",
      component: MasterAllWorkPermitComponent,
    },
    {
      path: "",
      component: MasterAllWorkPermitComponent,
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AllWorkPermitRoutingModule { }
