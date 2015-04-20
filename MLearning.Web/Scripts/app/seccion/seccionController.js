mlearningApp.controller('seccionController', function($scope,globales) {

    $scope.aviso = 'no se a Añadido Ninguna Seccion';
    $scope.secciones = [];
    $scope.unidadActual = null;
    
    $scope.getUnidad = function () {
        $scope.unidadActual = globales.get('unidadActual');
        console.log('unidadActual :::',$scope.unidadActual);
    };
    
    
    
    
    
    $scope.addSeccion = function (data) {
       $scope.aviso= ''; 
        
        $scope.secciones.push(data);
        console.log( $scope.secciones);
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
     console.log('nueva Pagina************* ',data);
     globales.save('seccionActual',data);
    };
    
    
    ///funciones q se ejecutan primero 
    
    $scope.getUnidad();
    
    
    
}).directive('seDirective', function () {
   return {
        templateUrl: '/views/directives/seccion-editor.html'        
    };
}).directive('slSeccion', function () {
    return {
         templateUrl: '/views/directives/seccionDirective.html' 
      
    };
});
