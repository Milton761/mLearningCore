'use strict';

/**
 * @ngdoc function
 * @name mlearningApp.controller:AdminAdministradorCtrl
 * @description
 * # AdminAdministradorCtrl
 * Controller of the mlearningApp
 */
angular.module('mlearningApp')
    .controller('AdminAdministradorCtrl', function ($scope,administradorService) {

    $scope.admin = administradorService.hola;

    $scope.$parent.items = [
        {codigo: 0},
        {codigo: 1},
        {codigo: 2}
    ];



});
