import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },

      // Add the new Project Management parent route
      {
        path: '/project-management',
        name: '::Menu:ProjectManagement',
        iconClass: 'fas fa-tasks',
        order: 2,
        layout: eLayoutType.application,
      },
      // Project Management
      {
        path: '/projects',
        name: '::Menu:Projects',
        parentName: '::Menu:ProjectManagement',
        layout: eLayoutType.application,
      },
      {
        path: '/tasks',
        name: '::Menu:ProjectTasks',
        parentName: '::Menu:ProjectManagement',
        layout: eLayoutType.application,
      },
    ]);
  };
}
