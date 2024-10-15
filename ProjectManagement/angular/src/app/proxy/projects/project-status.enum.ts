import { mapEnumToOptions } from '@abp/ng.core';

export enum ProjectStatus {
  Undefined = 0,
  New = 1,
  Ongoing = 2,
  Postponed = 3,
  Finished = 4,
  Cancelled = 5,
}

export const projectStatusOptions = mapEnumToOptions(ProjectStatus);
