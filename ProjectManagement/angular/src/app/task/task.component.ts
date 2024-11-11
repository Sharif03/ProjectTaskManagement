import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ProjectTaskService, ProjectTaskDto, projectTaskStatusOptions, ProjectLookupDto} from '@proxy/project-tasks'; // Sservice for fetching tasks
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { ProjectFilterRequest } from '../shared/projectFilterRequest'

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrl: './task.component.scss',
  providers: [ListService],
})
export class TaskComponent implements OnInit {
  projectTask = { items: [], totalCount: 0 } as PagedResultDto<ProjectTaskDto>;

  // Store selected projects from dropdown
  selectedProjectIds: string[] = [];

  // text filtering object
  filterRequest: ProjectFilterRequest = new ProjectFilterRequest();

  // declare selectedProjectTask
  selectedProjectTask = {} as ProjectTaskDto;

  // Search term bound to the input field
  searchTerm: string = ''; 

  form: FormGroup;

  // projectStatus as a list of ProjectTaskStatus enum members
  projectTaskStatuses = projectTaskStatusOptions;

  // Projects name lookup
  projectList: ProjectLookupDto[] = [];

  // Sorting state
  sortingField: string = 'name';   // Default sorting by name
  sortingDirection: string = 'asc'; // Default sorting direction

  isModalOpen = false;

  constructor(
    public readonly list: ListService,
    private projectTaskService: ProjectTaskService,
    private fb: FormBuilder, // inject FormBuilder
    private confirmation: ConfirmationService, // inject the ConfirmationService
  ) {}

  ngOnInit(): void {
    debugger;
    const projectTaskCreator = (query) => this.projectTaskService.getList({ 
      ...query, 
      ...this.filterRequest
    });

    this.list.hookToQuery(projectTaskCreator).subscribe((response) => {
      this.projectTask = response;
    });

    this.projectTaskService.getProjectLookup().subscribe(( resp => {
      this.projectList = resp.items;
    }));
  }

   // createProjectTask method
  createProjectTask() {
    this.selectedProjectTask = {} as ProjectTaskDto; // reset the selected project
    this.buildForm();
    this.isModalOpen = true;
  }

    // editProjectTask method
  editProjectTask(id: string) {
    this.projectTaskService.get(id).subscribe((projectTask) => {
      this.selectedProjectTask = projectTask;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

   // deleteProjectTask method
  deleteProjectTask(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure')
        .subscribe((status) => {
          if (status === Confirmation.Status.confirm) {
            this.projectTaskService.delete(id).subscribe(() => this.list.get());
          }
	    });
  }

  // Handle multi-select project change
  searchProjectTasks() {
    this.filterRequest.filter = this.searchTerm;
    this.filterRequest.projectIds = this.selectedProjectIds;
    this.list.getWithoutPageReset();
  }

  // approveProjectTask method
  approveProjectTask(id: string) {
    this.confirmation.warn('::AreYouSureToApprove', '::AreYouSure')
        .subscribe((status) => {
          if (status === Confirmation.Status.confirm) {
            this.projectTaskService.approveTask(id).subscribe(() => this.list.get());
          }
	    });
  }

  // Set sorting field and direction
sortTasks(field: string) {
  // Toggle sorting field and direction
  if (this.list.sortKey === field) {
    this.list.sortOrder = this.list.sortOrder === 'desc' ? 'asc' : 'desc';  // Toggle order
  } else {
    this.list.sortKey = field;  // Set new sort field
    this.list.sortOrder = 'asc';  // Default to ascending order
  }

  // Refresh the task list with the new sorting order
  this.list.getWithoutPageReset();
}


  // buildForm method
  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedProjectTask.name || null, Validators.required],
      code: [this.selectedProjectTask.code || null, Validators.required],
      projectId: [this.selectedProjectTask.projectId || null, Validators.required],
      status: [this.selectedProjectTask.status || null, Validators.required],
    });
  }

  // save method
  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedProjectTask.id) {
      this.projectTaskService.update(this.selectedProjectTask.id, this.form.value)
        .subscribe(() => {this.isModalOpen = false; this.form.reset();this.list.get();});
    } 
    else {
      this.projectTaskService.create(this.form.value)
        .subscribe(() => {this.isModalOpen = false; this.form.reset(); this.list.get();});
    }
  }

}
