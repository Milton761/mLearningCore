mlearningApp.service('sectionService', ['$http', function ($http) {
    var urlBase = '/Publisher';

    this.getSectionPages = function (section) {
        return $http.post(urlBase + '/Read_SectionPages/'+section.id);
    };

    this.createSection = function (section) {
        return $http.post(urlBase + '/CreateLOsection',section);
    };

}]);