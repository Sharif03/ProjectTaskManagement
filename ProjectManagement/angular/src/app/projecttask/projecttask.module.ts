import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ProjecttaskRoutingModule } from './projecttask-routing.module';
import { ProjecttaskComponent } from './projecttask.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';  // Required for [(ngModel)] and reactive forms
import { NgSelectModule } from '@ng-select/ng-select';  // Import NgSelectModule for multi-select functionality


@NgModule({
  declarations: [ProjecttaskComponent],
  imports: [SharedModule, ProjecttaskRoutingModule, NgbDatepickerModule, FormsModule, 
    ReactiveFormsModule, NgSelectModule], 
})
export class ProjecttaskModule { }
