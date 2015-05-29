mlearningApp.controller('seccionController', function ($scope, sectionService) {

    $scope.aviso = 'no se a Añadido Ninguna Seccion';
    $scope.sections = [];
    $scope.unidadActual = null;
    
    $scope.getUnidad = function () {
        $scope.unidadActual = currentLO;
        $scope.sections = currentLOsections;
        console.log('unidadActual :::',$scope.unidadActual);
    };
   
    $scope.addSeccion = function (data) {
       $scope.aviso= ''; 
       data.id = null;
       $scope.sections.push(data);
        console.log( $scope.sections);
    };
    
    $scope.ocultarMostar =  function () {
        console.log('ocultar o Mostrar ');
    };
    
     $scope.visualizarSeccion =  function () {
        console.log('visualizar seccion');
    };
    
     $scope.editarSeccion =  function () {
        console.log('editar seccion ');
    };
    
    
     $scope.eliminarSeccion =  function () {
        console.log('eliminar seccion ');
    };
      
    $scope.nuevaPagina = function (section) {
        if (section.id == null)
        {
            section.LO_id = $scope.unidadActual.id;
            section.id = 0;

            sectionService.createSection(section).
                success(function (data) {
                    if (data.errors.length == 0) {
                        $scope.redireccionar(data.url);
                    }
                });
        }
        else
            $scope.redireccionar('/Page/?sectionId=' + section.id);
    };
    
    $scope.removePage = function (page) {
        console.log("removing Page");
    }

    $scope.collapseSection = function (section, expanded) {
        if (!expanded || section.id==null) return;
        //console.log(section);
        sectionService.getSectionPages(section)
            .success(function (response) {
                console.log("Response sectionPages => ", response);
                section.pages = response;
            }).error(function (error){
                console.log(error);
            });
    }

    ///funciones q se ejecutan primero 
    
    $scope.getUnidad();
    
    
}).directive('seDirective', function () {
   return {
        templateUrl: '/Scripts/app/directives/seccion-editor.html'        
    };
}).directive('slSeccion', function () {
    return {
        templateUrl: '/Scripts/app/directives/seccionDirective.html'
      
    };
}).directive('pagePreview', function () {
    return {
        scope: true,
        templateUrl: '/Scripts/app/directives/pagePreview.html'
    };
});
