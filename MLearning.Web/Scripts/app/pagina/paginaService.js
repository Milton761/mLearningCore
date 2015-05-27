mlearningApp.service('lopageService', ['$http', function ($http) {

        var urlBase = '/Page';

        this.createPage = function (page) {
            page.id = 0;
            return $http.post(urlBase+'/Create', page);
        };

        this.updatePage = function (page) {
            return $http.post(urlBase + '/Update', page)
        };

    }]);