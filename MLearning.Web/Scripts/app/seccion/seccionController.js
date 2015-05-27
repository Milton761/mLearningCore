mlearningApp.controller('seccionController', function($scope,globales) {

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
    
    //es para poder guardar el seccion actual  
    $scope.nuevaPagina = function (data) {
     //console.log('nueva Pagina************* ',data);
        //globales.save('seccionActual',data);
        data.LO_id = $scope.unidadActual.id;
        data.id = 0;
        $.ajax(
        {
            url: saveSectionURL,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            success: function (data, textStatus, jqXHR) {
                console.log(data);
                if (data.errors.length == 0) {
                    $scope.redireccionar(data.url);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });

    };
    
    
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
});
