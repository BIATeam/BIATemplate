import { AllEnvironments } from '@bia-team/bia-ng/models';

export const allEnvironments: AllEnvironments & { [key: string]: any } = {
  appTitle: 'BIATemplate',
  companyName: 'TheBIADevCompany',
  enableNotifications: true,
  enableWorkerService: false,
  enableAnnouncements: true,
  urlAuth: '/api/Auth',
  urlLog: '/api/logs',
  urlEnv: '/api/AppSettings/Environment',
  urlAppSettings: 'api/AppSettings',
  urlAppIcon: 'assets/bia/img/AppIcon.svg',
  urlErrorPage: './assets/bia/html/error.html',
  version: '0.0.0',
};
