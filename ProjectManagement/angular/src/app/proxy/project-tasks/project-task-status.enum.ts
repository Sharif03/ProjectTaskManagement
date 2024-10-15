import { mapEnumToOptions } from '@abp/ng.core';

export enum ProjectTaskStatus {
  New = 0,
  Inprogress = 1,
  Done = 2,
}

export const projectTaskStatusOptions = mapEnumToOptions(ProjectTaskStatus);
