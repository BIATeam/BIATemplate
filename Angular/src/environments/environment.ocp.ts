import { NgxLoggerLevel } from 'ngx-logger';

export const environment = {
  helpUrl: '',
  reportUrl: '',
  apiUrlDynamic: {
    oldValue: 'biatemplate',
    newValue: 'biatemplate-api'
  },
  apiUrl: '/api',
  hubUrl: '/HubForClients',
  urlErrorPage: 'http://localhost/static/error.htm',
  useXhrWithCred: false,
  production: true,
  logging: {
    conf: {
      serverLoggingUrl: '/api/logs',
      level: NgxLoggerLevel.DEBUG,
      serverLogLevel: NgxLoggerLevel.ERROR
    }
  }
};
