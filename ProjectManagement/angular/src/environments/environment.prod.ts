import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'ProjectManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44342/',
    redirectUri: baseUrl,
    clientId: 'ProjectManagement_App',
    responseType: 'code',
    scope: 'offline_access ProjectManagement',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44342',
      rootNamespace: 'ProjectManagement',
    },
  },
} as Environment;
