import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjecttaskComponent } from './projecttask.component';

const routes: Routes = [{ path: '', component: ProjecttaskComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjecttaskRoutingModule { }
