import type { ProjectStatus } from './project-status.enum';
import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateUpdateProjectDto {
  name: string;
  code: string;
  startDate: string;
  endDate: string;
  description: string;
  status: ProjectStatus;
}

export interface GetProjectListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface ProjectDto extends AuditedEntityDto<string> {
  name: string;
  code: string;
  startDate: string;
  endDate: string;
  description?: string;
  status: ProjectStatus;
}
