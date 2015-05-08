angular.module('mlearningApp').controller('unidadController', function ($scope, globales) {
    $scope.unidad = 'unidadController';
    $scope.unidades = [];
    $scope.pags = [];
    $scope.statusMsg = "";
    if (typeof currentLO !== 'undefined')
    {
        $scope.unidadActual = currentLO;
    }
    else
    {
        $scope.unidadActual = {};
    }
        
    ///////combobox/////////
    $scope.etiquetas = [
        {id:1,name:'fisica1'},
        {id:2,name:'fisica2'},
        {id:3,name:'fisica3'}
    ];
  
    ///funciones
    
    $scope.crearUnidad = function () {
        $scope.statusMsg = "Enviando...";
        $.ajax(
        {
            url: saveUnitURL,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify($scope.unidadActual),
            
            success: function (data, textStatus, jqXHR) {
                console.log(data);
                if( data.errors != null, data.errors.length==0)
                {
                    $scope.redireccionar(data.url);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
        $scope.status = "";
        console.log('crear Unidad', $scope.unidadActual);


        $scope.unidades.push($scope.unidadActual);
         globales.save('unidadActual',$scope.unidadActual);
        //$('#unitForm').submit();
         
    }
    $scope.cancelarUnidad = function () {
        //console.log('cancelar Unidad', 'Regresar a crear Unidad');
        window.history.back();
    }
});

