mlearningApp.controller('quizController', function ($scope, globales,quizService) {

    $scope.quiz = {};
    $scope.quiz.questions = [{ type: 0 }, { type: 1 }, { type: 2 }, { type: 3 }, { type: 4 }];

});

mlearningApp.directive('question', function () {
    return {
        scope: true,
        /*scope: {
            ngModel: '='
        },*/
        templateUrl: function (element, attrs) {
            var type = attrs.type || 'pagina-slide';
            return '/Scripts/app/directives/quiz/' + type + '.html';
        },
        link: function (scope, element, attrs) {
            scope.onUploadSlideImageSuccess = function (e) {
                scope.$apply(function () {
                    scope.slide.loimage = e.response.url;
                });
            }
        }
    };
});
