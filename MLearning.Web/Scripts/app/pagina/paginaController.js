
mlearningApp.controller('paginaController', function ($scope,globales) {

    $scope.pagina = 'soy controlador de pagina';
    $scope.unidadActual = null;
    $scope.seccionActual = null;
    $scope.loslide = [];
    

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


    //botones
    $scope.guardarPagina = function () {
        
        $scope.currentPage.id = 0;

        //TODO generate json from slides
        $scope.currentPage.content = "_";
        $scope.currentPage.lo_id = $scope.seccionActual.LO_id;
        $scope.currentPage.url_img = "URL";
        $scope.currentPage.LOsection_id = $scope.seccionActual.id;

        $.ajax(
        {
            url: savePageURL,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify($scope.currentPage),
            success: function (data, textStatus, jqXHR) {
                console.log(data);
                if (data.errors != null) {
                    //$scope.redireccionar(data.url);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });

        console.log('saving page:::',$scope.currentPage);
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
        //scope: true,
        scope: {
            ngModel: '='
        },
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


