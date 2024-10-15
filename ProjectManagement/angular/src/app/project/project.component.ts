import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ProjectService, ProjectDto, projectStatusOptions } from '@proxy/projects';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { ProjectFilterRequest } from '../shared/projectFilterRequest'// Custom filter request model


@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.scss'],
  providers: [ListService,  { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})

export class ProjectComponent implements OnInit {
  project = { items: [], totalCount: 0 } as PagedResultDto<ProjectDto>;

  // create filtering object
  filterRequest: ProjectFilterRequest = new ProjectFilterRequest();

  // declare selectedProject
  selectedProject = {} as ProjectDto; 

  // Search term bound to the input field
  searchTerm: string = ''; 

  form: FormGroup;

  // projectStatus as a list of ProjectStatus enum members
  projectStatuses = projectStatusOptions;

  isModalOpen = false;

  constructor(
    public readonly list: ListService, 
    private projectService: ProjectService,
    private fb: FormBuilder, // inject FormBuilder
    private confirmation: ConfirmationService // inject the ConfirmationService
  ) {}
  
  ngOnInit() {
    const projectCreator = (query) => this.projectService.getFiteredProjectList({ ...query, ...this.filterRequest });
    this.list.hookToQuery(projectCreator).subscribe((response) => {
      this.project = response;
    });
  }

  // createProject method
  createProject() {
    this.selectedProject = {} as ProjectDto; // reset the selected project
    this.buildForm();
    this.isModalOpen = true;
  }

  // editProject method
  editProject(id: string) {
    this.projectService.get(id).subscribe((project) => {
      this.selectedProject = project;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  // deleteProject method
  deleteProject(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure')
    .subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.projectService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  // searchProject method
  searchProject(searchTerm: string) {
    this.filterRequest.filter = searchTerm;
    this.list.getWithoutPageReset();
  }

  // buildForm method
  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedProject.name || '', Validators.required],
      code: [this.selectedProject.code || '', Validators.required],
      startDate: [this.selectedProject.startDate ? new Date(this.selectedProject.startDate) : null, Validators.required],
      endDate: [this.selectedProject.endDate ? new Date(this.selectedProject.endDate) : null, Validators.required],
      description: [this.selectedProject.description || '', Validators.required],
      status: [this.selectedProject.status || null, Validators.required],
    });
  }

  // save method
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedProject.id
      ? this.projectService.update(this.selectedProject.id, this.form.value)
      : this.projectService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}
