'use strict';

/**
 * @ngdoc service
 * @name mlearningApp.admin/instituciones
 * @description
 * # admin/instituciones
 * Service in the mlearningApp.
 */
angular.module('mlearningApp')
  .service('institucionesService', function () {
    // AngularJS will instantiate a singleton by calling "new" on this function

    //////////////////instituciones
    this.instituciones = [];

for(var i = 0 ;i< 10;i++) {
    var institucion = {
                       id:i,
                       nombre:'Nombre '+i,
                       pais:'Pais '+i,
                       ciudad:'Ciudad '+i,
                       director:'Director '+i
                       };

    this.instituciones.push(institucion);

}

    this.getInstituciones  = function () {
        return this.instituciones;
    };


    //////paginadores/////////
    this.crearPagina= function(numeroRegistros){
        this.paginas = [];

        for(var i = 0;i < this.instituciones.length/numeroRegistros;i++){
            var pagina =  {nombre:i+1};
            this.paginas.push(pagina);
        }

    return this.paginas;

    }

    this.obtenerRegistros = function(inicio,fin){

        this.registros = this.instituciones.slice(inicio,fin);
        return this.registros;
    }





});
