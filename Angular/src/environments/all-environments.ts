import { RoleMode, TeamTypeId } from 'src/app/shared/constants';

export const allEnvironments = {
  appTitle: 'BIATemplate',
  companyName: 'TheBIADevCompany',
  enableNotifications: true,
  enableWorkerService: false,
  urlAuth: '/api/Auth',
  urlLog: '/api/logs',
  urlEnv: '/api/Environment',
  urlAppIcon: 'assets/bia/img/AppIcon.svg',
  urlErrorPage: './assets/bia/html/error.html',
  version: '0.0.0',

  teams: [
    {
      teamTypeId: TeamTypeId.Site,
      roleMode: RoleMode.AllRoles,
      inHeader: true,
      label: 'site.headerLabel',
    },
    // BIAToolKit - Begin AllEnvironment
    // BIAToolKit - End AllEnvironment
  ],
};
