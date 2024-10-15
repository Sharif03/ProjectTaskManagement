import type { ProjectTaskStatus } from './project-task-status.enum';
import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateProjectTaskDto {
  name: string;
  code: string;
  projectId?: string;
  status: ProjectTaskStatus;
  isApproved: boolean;
}

export interface GetProjectTaskListDto extends PagedAndSortedResultRequestDto {
  projectIds: string[];
  filter?: string;
  pageNumber: number;
  pageSize: number;
}

export interface ProjectLookupDto extends EntityDto<string> {
  name?: string;
}

export interface ProjectTaskDto extends EntityDto<string> {
  name: string;
  code: string;
  projectId?: string;
  projectName?: string;
  status: ProjectTaskStatus;
  isApproved: boolean;
}

export interface UpdateProjectTaskDto {
  name: string;
  code: string;
  projectId?: string;
  status: ProjectTaskStatus;
  isApproved: boolean;
}
