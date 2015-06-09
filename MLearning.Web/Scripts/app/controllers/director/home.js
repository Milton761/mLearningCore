'use strict';

/**
 * @ngdoc function
 * @name mlearningApp.controller:DirectorHomeCtrl
 * @description
 * # DirectorHomeCtrl
 * Controller of the mlearningApp
 */
angular.module('mlearningApp')
  .controller('DirectorHomeCtrl', function ($scope) {
    $scope.$parent.items = [
        {codigo: 3},
        {codigo: 4},
        {codigo: 5},
        {codigo: 6}
    ];
  });
