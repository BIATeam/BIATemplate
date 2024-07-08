import { NgxLoggerLevel } from 'ngx-logger';

export const environment = {
  helpUrl: '',
  reportUrl: '',
  apiUrlDynamic: {
    oldValue: '',
    newValue: '',
  },
  apiUrl: 'http://localhost:32128/BIATemplate/WebApi/api',
  hubUrl: 'http://localhost:32128/BIATemplate/WebApi/HubForClients',
  useXhrWithCred: true,
  production: false,
  logging: {
    conf: {
      serverLoggingUrl: 'http://localhost:32128/BIATemplate/WebApi/api/logs',
      level: NgxLoggerLevel.DEBUG,
      serverLogLevel: NgxLoggerLevel.ERROR,
      withCredentials: true,
    },
  },
};
