
mlearningApp.controller('paginaController', function ($scope,globales) {

    $scope.pagina = 'soy controlador de pagina';
    $scope.unidadActual = null;
    $scope.seccionActual = null;
    $scope.loslide = [];


    $scope.getUnidadSeccion = function () {
        $scope.unidadActual = currentLO;
        $scope.seccionActual = currentLOSection;

        console.log('actual seccion::',$scope.seccionActual);

    };



    ////////////////////funciones////////////////////
    $scope.addPagina = function (pagina) {

        $scope.loslide.push(pagina);
        console.log($scope.loslide);
    }


    //botones
    $scope.guardarPagina = function () {
        console.log('guardar pagina');
        console.log('todo el objeto json:::',$scope.loslide);
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


