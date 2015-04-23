'use strict';

/**
 * @ngdoc overview
 * @name mlearningApp
 * @description
 * # mlearningApp
 *
 * Main module of the application.
 */
angular
    .module('mlearningApp', [
    'ngResource',
    'ngRoute',
    'ngAnimate'
])
    .config(function ($routeProvider) {
    $routeProvider
        .when('/', {
        templateUrl: '/Home/Index0',
        controller: 'MainCtrl'
    })
        .when('/about', {
        templateUrl: 'views/about.html',
        controller: 'AboutCtrl'
    })
        .when('/admin/instituciones', {
        templateUrl: 'views/admin/instituciones&',
        controller: 'AdminInstitucionesCtrl'
    })
        .when('/admin/unidades', {
        templateUrl: 'views/admin/unidades.html',
        controller: 'AdminUnidadesCtrl'
    })
        .when('/admin/administrador', {
        templateUrl: 'views/admin/administrador.html',
        controller: 'AdminAdministradorCtrl'
    })
        .when('/director/home', {
        templateUrl: 'views/director/home.html',
        controller: 'DirectorHomeCtrl'
    })
        .when('/director/profesores', {
        templateUrl: 'views/director/profesores.html',
        controller: 'DirectorProfesoresCtrl'
    })
        .when('/director/alumnos', {
        templateUrl: 'views/director/alumnos.html',
        controller: 'DirectorAlumnosCtrl'
    })
        .when('/director/circulos', {
        templateUrl: 'views/director/circulos.html',
        controller: 'DirectorCirculosCtrl'
    })
        .otherwise({
        redirectTo: '/'
    });
});


var mlearningApp = angular.module('mlearningApp');

angular.module('mlearningApp').factory('flickr', function ($resource) {
    return $resource('http://api.flickr.com/services/feeds/photos_public.gne',
                     { format: 'json',
                      jsoncallback: 'JSON_CALLBACK'
                     }, {
        'load': { 'method': 'JSONP' } });
});



angular.module('mlearningApp')
    .controller('indexCtrl', function ($scope,$location,administradorService,flickr) {

    $scope.mensaje = "MLearning";
    $scope.showMenu = true;
    $scope.items = [
        /*{codigo: 0},
        {codigo: 1},
        {codigo: 2},
        {codigo: 3},
        {codigo: 4},
        {codigo: 5},
        {codigo: 6},*/
    ];
    $scope.redireccionar = function(path){
        //$location.path(path);
        window.location.href = path;
    };

    $scope.openProfile = function () {
        //console.log("openProfile");
        editProfile();
    }
    $scope.logout = function () {
        $("#logoutForm").submit();
    }

    $scope.crearUnidad = function () {
        console.log('crear Unidad 222', $scope.unidadActual);
    }
});



