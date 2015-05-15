angular.module('mlearningApp').controller('unidadController', function ($scope, globales,loService) {
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
    $scope.etiquetas = [];
  
    ///funciones
    
    $scope.onCoverUploadSuccess = function (e) {
        console.log(e.response);
        $scope.$apply(function () {
            $scope.unidadActual.url_cover = e.response.url;
        //$("#coverImage").attr("src", e.response.url);
        });
    }

    $scope.crearUnidad = function () {  
        //$scope.statusMsg = "Enviando...";
        if (!$scope.unitForm.$valid) {
            // Submit as normal
            console.log("Invalid fields in form!");
            console.log($scope.unidadActual);
            return;
        }
        loService.createLO($scope.unidadActual)
        .success(function (data) {
            console.log(data);
            if (data.errors == null) {
                $scope.redireccionar(data.url);
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

