'use strict';

/**
 * @ngdoc function
 * @name mlearningApp.controller:AdminInstitucionesCtrl
 * @description
 * # AdminInstitucionesCtrl
 * Controller of the mlearningApp
 */
angular.module('mlearningApp')
    .controller('AdminInstitucionesCtrl', function ($scope,institucionesService) {

    $scope.instituciones = institucionesService.getInstituciones();
    $scope.hola = 'hola';


    //////////////paginador/////////


    $scope.numeroRegistros = 7;



 $scope.paginas = institucionesService.obtenerRegistros(0,$scope.numeroRegistros);

    $scope.selected = 0;

    $scope.crearPagina = function(pagina){
         $scope.paginas = institucionesService.crearPagina($scope.numeroRegistros);

        var inicio = $scope.numeroRegistros*(pagina.nombre-1);
        var fin = $scope.numeroRegistros*pagina.nombre;
        $scope.instituciones = institucionesService.obtenerRegistros(inicio,fin);
        $scope.selected = pagina.nombre;
    }

///////////////////////////////////////////botones de la tabla ///////////////////////

    $scope.visualizarInstitucion  = function (institucion) {
    console.log('visualizar',institucion);
    };

    $scope.editarInstitucion  = function (institucion) {
    console.log('editar',institucion);
    };

     $scope.eliminarInstitucion  = function (institucion) {
    console.log('eliminar',institucion);
    };

  ///////////////////////////////////////////botones de la tabla ///////////////////////

    $scope.nuevaInstitucion = function (size) {
    console.log('nueva isntitucion');

        console.log('size');

 /*
        var modalInstance = $modal.open({
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrlInstitucion',
            size: size,
            resolve: {

                institucion:  function (){
                    return null;
                }
            }
        });
 */


    };


    $scope.visualizarInstitucion  = function (institucion) {
        console.log('visualizar',institucion);
    };

    $scope.editarInstitucion  = function (institucion) {
        console.log('editar',institucion);

        var modalInstance = $modal.open({
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrlInstitucion',

            resolve: {

                institucion:  function (){
                    return institucion;
                }

            }
        });

    };

    $scope.eliminarInstitucion  = function (institucion) {
        console.log('eliminar',institucion);
    };

    ///////////////////////




});



///////////////////////////////////controlador del modal///////////////////////



angular.module('mlearningApp').controller('ModalInstanceCtrlInstitucion', function ($scope, $modalInstance,institucion,institucionesService){






    $scope.institucionActual = angular.copy(institucion);

 /*
    if( $scope.entidadActual.vistaEstado == 'creado') {

        $scope.tituloModal = "Nuevo Entidad";
    }
    else {
        $scope.tituloModal = "Editar Entidad";
    }
*/

    $scope.guardarModal = function () {
        console.log('guardar modal',$scope.institucionActual);

        /*if($scope.tituloModal == 'Nuevo Entidad') {
            entidadService.addVista($scope.entidadActual);
            entidadService.save(mensaje);

        }
        else {

            entidad.nombre = $scope.entidadActual.nombre;
            entidad.descripcion = $scope.entidadActual.descripcion;
            entidad.vistaEstado = 'modificado';
            entidadService.save(mensaje);
        }

*/


        $modalInstance.close();
    };

    $scope.cancel = function () {
        console.log('cancel modal');
        $modalInstance.dismiss('cancel');

    };



});


