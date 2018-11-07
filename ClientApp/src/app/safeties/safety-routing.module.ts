import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SafetyCenterComponent } from './safety-center.component';
import { SafetyMasterComponent } from './safety-master/safety-master.component';

const routes: Routes = [{
  path: "",
  component: SafetyCenterComponent,
  children: [
    {
      path: ":key",
      component: SafetyMasterComponent,
    },
    {
      path: "",
      component: SafetyMasterComponent,
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SafetyRoutingModule { }
