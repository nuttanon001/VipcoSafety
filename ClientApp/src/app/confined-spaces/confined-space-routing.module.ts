import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConfinedSpaceCenterComponent } from './confined-space-center.component';
import { ConfinedSpaceMasterComponent } from './confined-space-master/confined-space-master.component';

const routes: Routes = [{
  path: "",
  component: ConfinedSpaceCenterComponent,
  children: [
    {
      path: ":key",
      component: ConfinedSpaceMasterComponent,
    },
    {
      path: "",
      component: ConfinedSpaceMasterComponent,
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConfinedSpaceRoutingModule { }
