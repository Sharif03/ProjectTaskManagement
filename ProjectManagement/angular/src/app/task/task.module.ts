import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { TaskRoutingModule } from './task-routing.module';
import { TaskComponent } from './task.component';

import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';  // Required for [(ngModel)] and reactive forms
import { NgSelectModule } from '@ng-select/ng-select';  // Import NgSelectModule for multi-select functionality


@NgModule({
  declarations: [TaskComponent],
  imports: [
    SharedModule,
    TaskRoutingModule,
    NgbDatepickerModule,
    FormsModule, 
    ReactiveFormsModule, 
    NgSelectModule
  ]
})
export class TaskModule { }
