import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LiftingCenterComponent } from './lifting-center.component';
import { LiftingMasterComponent } from './lifting-master/lifting-master.component';

const routes: Routes = [{
  path: "",
  component: LiftingCenterComponent,
  children: [
    {
      path: ":key",
      component: LiftingMasterComponent,
    },
    {
      path: "",
      component: LiftingMasterComponent,
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LiftingRoutingModule { }
