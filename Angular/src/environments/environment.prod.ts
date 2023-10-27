import { NgxLoggerLevel } from 'ngx-logger';

export const environment = {
  helpUrl: '',
  reportUrl: '',
  apiUrlDynamic: {
    oldValue: '',
    newValue: ''
  },
  apiUrl: '../WebApi/api',
  hubUrl: '../WebApi/HubForClients',
  urlErrorPage: '/static/error.htm',
  useXhrWithCred: false,
  production: true,
  logging: {
    conf: {
      serverLoggingUrl: '../WebApi/api/logs',
      level: NgxLoggerLevel.DEBUG,
      serverLogLevel: NgxLoggerLevel.ERROR
    }
  }
};