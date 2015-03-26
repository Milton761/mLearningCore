'use strict';

/**
 * @ngdoc directive
 * @name mlearningApp.directive:slidesEditor
 * @description
 * # slidesEditor
 */
angular.module('mlearningApp')

    .directive('slidesEditor', function () {
    return {
        scope: true,
        templateUrl: 'views/directives/slides-editor.html',
        link: function (scope, element, attrs) {
            //element.text('this is the slidesEditor directive');
        },
        controller: function($scope){
            $scope.saludar = function(){
                console.log("Hola :D");
            }
        }
    };
})

    .directive('slide', function () {
    return {
        scope: true,
        templateUrl: function (element, attrs) {
            var tipo = attrs.tipo || 'slide';
            console.log(element,attrs,tipo);
            return 'views/directives/' + tipo + '.html';
        },
        link: function (scope, element, attrs) {
            console.log('#',attrs);
            scope.hola = function () {
                scope.saludar();
            };
        }
    };
})





















/*
return {
			scope: {
				messages: '=hsInbox'
			},
			templateUrl: 'partials/inbox.html',
			controller: function ($scope) {

				// Delete message
				this.remove = function (index) {
					$scope.messages.splice(index, 1);
				};

				// Add new message
				this.add = function (newMessage) {
					$scope.messages.unshift({
						id: $scope.messages.length,
						to: newMessage.to,
						body: newMessage.body
					});
				};

			}
		};
*/
