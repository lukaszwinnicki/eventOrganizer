basePath = '../';

files = [
  JASMINE,
  JASMINE_ADAPTER,
  'Libraries/Angular/angular.js',
  //'Libraries/Angular/angular-*.js',
  'Libraries/Angular/angular-loader.js',
  'Libraries/Angular/angular-resource.js',
  'Libraries/Angular/angular-mocks.js',
  /*'angular-bootstrap.js',
  'angular-loader.js',
  'angular-resource.js',
  'angular-sanitize.js',
  'Tests/Lib/Angular/angular-mocks.js',*/
  'App/Controllers/*.js',
  'Tests/Unit/Controllers/*.js'
];

autoWatch = true;

browsers = ['Chrome'];
