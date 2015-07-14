mlearningApp.service('quizService', ['$http', function ($http) {

    var urlBase = '/Publisher';

    this.createLO = function (lo) {
        return $http.post(urlBase + '/CreateLO', lo);
    };

    this.updateLO = function (lo) {
        return $http.post(urlBase + '/UpdateLO', lo);
    };

}]);