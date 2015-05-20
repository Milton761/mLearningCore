
mlearningApp.controller('paginaController', function ($scope,globales,lopageService) {

    $scope.pagina = 'soy controlador de pagina';
    $scope.unidadActual = null;
    $scope.seccionActual = null;
    $scope.loslide = []; //[{ lotype: 0 }, { lotype: 1 }, { lotype: 2 }, { lotype: 3 }, { lotype: 4 }, { lotype: 5 }, { lotype: 6 }];
    

    $scope.getUnidadSeccion = function () {
        $scope.unidadActual = currentLO;
        $scope.seccionActual = currentLOSection;
        if(currentPage != null)
            $scope.currentPage = currentPage;
         else
            $scope.currentPage = {};
        console.log('actual seccion::',$scope.seccionActual);

    };



    ////////////////////funciones////////////////////
    $scope.addPagina = function (pagina) {

        $scope.loslide.push(pagina);
        console.log($scope.loslide);
    }

    $scope.onUploadSuccess = function (e) {

    }

    //botones
    $scope.guardarPagina = function () {
        
        var isNew = false;
        if (typeof $scope.currentPage.id == 'undefined')
        {
            $scope.currentPage.id = 0;
            isNew = true;
        }
        
        $scope.currentPage.lo_id = $scope.seccionActual.LO_id;
        $scope.currentPage.url_img = "URL";
        $scope.currentPage.LOsection_id = $scope.seccionActual.id;

        var content = {};
        content.lopage = {};
        content.lopage.loslide = $scope.loslide;

        $scope.currentPage.content = JSON.stringify(content);

        lopageService.createPage($scope.currentPage).success(function (data) {
            console.log(data);
            if (data.errors != null && isNew) {
                $scope.redireccionar(data.url);
            }
        });

        console.log('saving page:::', $scope.currentPage);
    };


    $scope.cancelarPagina= function () {
        console.log('cancelar pagina');
    };




    ////////////funcion q se ejecutan al iniciar /////////

    $scope.getUnidadSeccion();
});

mlearningApp.directive('pgEditor', function () {
    return {
        scope: true,
        templateUrl: '/Scripts/app/directives/pagina-editor.html',
        link: function (scope, element, attrs) {
            //element.text('this is the slidesEditor directive');
        },
        controller: function($scope){
            $scope.saludar = function(){
                console.log("Hola :D");
            }
        }
    };
});
mlearningApp.directive('pgSlide', function () {
    return {
        scope: true,
        /*scope: {
            ngModel: '='
        },*/
        templateUrl: function (element, attrs) {
            var tipo = attrs.tipo || 'pagina-slide';
            return '/Scripts/app/directives/' + tipo + '.html';
        },
        link: function (scope, element, attrs) {
            //console.log('#',attrs);
            scope.hola = function () {
                scope.saludar();
            };
        }
    };
});

mlearningApp.directive('ngEnter', function () {
    return function (scope, element, attrs) {
        console.log(attrs);
        element.bind("keydown keypress", function (event) {

            if(event.which === 13 && scope.newItem.length>0) {
                scope.$apply(function (){
                    scope.$eval(attrs.ngEnter);
                    scope.newItem='';
                });

                event.preventDefault();
            }
        });
    };
});


