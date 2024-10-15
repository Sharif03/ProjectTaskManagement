import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { ProjectRoutingModule } from './project-routing.module';
import { ProjectComponent } from './project.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap'; // add this line



@NgModule({
  declarations: [
    ProjectComponent
  ],
  imports: [
    SharedModule,
    ProjectRoutingModule,
    NgbDatepickerModule
  ]
})
export class ProjectModule { }
