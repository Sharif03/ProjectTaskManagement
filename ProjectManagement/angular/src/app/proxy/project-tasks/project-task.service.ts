import type { CreateProjectTaskDto, GetProjectTaskListDto, ProjectLookupDto, ProjectTaskDto, UpdateProjectTaskDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { ListResultDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ProjectTaskService {
  apiName = 'Default';
  

  approveTask = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/project-task/${id}/approve-task`,
    },
    { apiName: this.apiName,...config });
  

  create = (input: CreateProjectTaskDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ProjectTaskDto>({
      method: 'POST',
      url: '/api/app/project-task',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/project-task/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ProjectTaskDto>({
      method: 'GET',
      url: `/api/app/project-task/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetProjectTaskListDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ProjectTaskDto>>({
      method: 'GET',
      url: '/api/app/project-task',
      params: { projectIds: input.projectIds, filter: input.filter, pageNumber: input.pageNumber, pageSize: input.pageSize, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getProjectLookup = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<ProjectLookupDto>>({
      method: 'GET',
      url: '/api/app/project-task/project-lookup',
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UpdateProjectTaskDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/project-task/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
