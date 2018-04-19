(function () {
    'use strict';

    var id = 'app';

    var app = angular.module('app', ['ngResource', 'ngRoute', 'ngAnimate', 'ui.bootstrap']);

    app.filter('enumPrioridades', function () {
        return function (input) {
            switch (parseInt(input)) {
                case 0:
                    return 'Baixa';
                case 1:
                    return 'Média';
                case 2:
                    return 'Alta';
                default:
                    return '--';
            }
        }
    });

    app.config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', {
                controller: 'HomeCtrl',
                templateUrl: 'modules/home/views/index.html',
                requireLogin: true
            });
    });

    app.run(['$http', '$rootScope', '$location', function ($http, $rootScope, $location) {
    }]);
})();