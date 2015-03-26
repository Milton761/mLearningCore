'use strict';

/**
 * @ngdoc function
 * @name mlearningApp.controller:AboutCtrl
 * @description
 * # AboutCtrl
 * Controller of the mlearningApp
 */
angular.module('mlearningApp')
  .controller('AboutCtrl', function ($scope) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];

     $scope.campos = [
        {name:'primero',tipo:'primero'},
        {name:'segundo',tipo:'segundo'},
        {name:'tercero',tipo:'tercero'},
        {name:'cuarto',tipo:'cuarto'},
        {name:'quinto',tipo:'quinto'},
        {name:'sexto',tipo:'sexto'}



    ];


    $scope.mensaje = "^_^";
    $scope.colores = [
        {name:'VERDE',tipo:'green'},
        {name:'NARANJA',tipo:'orange'},
        {name:'VERDE',tipo:'green'},
        {name:'NARANJA',tipo:'orange'},
        {name:'VERDE',tipo:'green'},
        {name:'NARANJA',tipo:'orange'},
        {name:'VERDE',tipo:'green'},
        {name:'NARANJA',tipo:'orange'},
        {name:'VERDE',tipo:'green'},
        {name:'NARANJA',tipo:'orange'},
        {name:'VERDE',tipo:'green'},
        {name:'NARANJA',tipo:'orange'},
        {name:'VERDE',tipo:'green'},
        {name:'NARANJA',tipo:'orange'},
        {name:'VERDE',tipo:'green'},
        {name:'NARANJA',tipo:'orange'},
        {name:'VERDE',tipo:'green'},
        {name:'NARANJA',tipo:'orange'},
        {name:'VERDE',tipo:'green'},
        {name:'NARANJA',tipo:'orange'},
        {name:'VERDE',tipo:'green'},
        {name:'NARANJA',tipo:'orange'},

    ];
    $scope.sc = 'orange';
  });
