import { NgxLoggerLevel } from 'ngx-logger';

export const environment = {
  helpUrl: '',
  reportUrl: '',
  apiUrlDynamic: {
    oldValue: '',
    newValue: '',
  },
  apiUrl: 'http://localhost/BIATemplate/WebApi/api',
  hubUrl: 'http://localhost/BIATemplate/WebApi/HubForClients',
  useXhrWithCred: true,
  production: false,
  logging: {
    conf: {
      serverLoggingUrl: 'http://localhost/BIATemplate/WebApi/api/logs',
      level: NgxLoggerLevel.DEBUG,
      serverLogLevel: NgxLoggerLevel.ERROR,
      withCredentials: true,
    },
  },
};
