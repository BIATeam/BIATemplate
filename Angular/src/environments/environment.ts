import { NgxLoggerLevel } from 'ngx-logger';

export const environment = {
  helpUrl: '',
  reportUrl: '',
  apiUrl: 'http://localhost:54321/BIATemplate/WebApi/api',
  hubUrl: 'http://localhost:54321/BIATemplate/WebApi/HubForClients',
  urlErrorPage: 'http://localhost/static/error.htm',
  useXhrWithCred: true,
  production: false,
  logging: {
    conf: {
      serverLoggingUrl: 'http://localhost:54321/BIATemplate/WebApi/api/logs',
      level: NgxLoggerLevel.DEBUG,
      serverLogLevel: NgxLoggerLevel.ERROR
    }
  }
};
