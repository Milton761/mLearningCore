'use strict';

/**
 * @ngdoc directive
 * @name mlearningApp.directive:selectImagen
 * @description
 * # selectImagen
 */

/******************
$scope.photos = flickrPhotos.load({ tags: 'gato',lang:'es-us'},function(){
    console.log($scope.photos);
});
******************/
angular.module('mlearningApp')
    .directive('selectImagen', function () {
    return {
        scope: true,
        templateUrl: 'views/directives/select-image.html',
        restrict: 'E',
        link: function postLink(scope, element, attrs) {
            //element.text('this is the selectImagen directive');
        }
    };
});
