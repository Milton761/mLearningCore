angular.module('mlearningApp').controller('unidadController', function ($scope, globales,loService) {
    $scope.unidad = 'unidadController';
    $scope.unidades = [];
    $scope.pags = [];
    $scope.statusMsg = "";
    if (currentLO != null)
    {
        $scope.unidadActual = currentLO;
        $scope.message = "EDITANDO ";
        $scope.unidadActual.tags = LOtagsIds;
    }
    else
    {
        $scope.unidadActual = {};
        $scope.unidadActual.id = null;
        $scope.message = "CREAR UNA NUEVA ";
        $scope.unidadActual.tags = [];
    }
    
    

    ///////combobox/////////
    //$scope.etiquetas = [];
  
    ///funciones
    
    $scope.onCoverUploadSuccess = function (e) {
        console.log(e.response);
        $scope.$apply(function () {
            $scope.unidadActual.url_cover = e.response.url;
        });
    }

    $scope.onBackgroundUploadSuccess = function (e) {
        $scope.$apply(function () {
            $scope.unidadActual.url_background = e.response.url;
        });
    }

    $scope.onAdditionalData = function(){
        return {
            text: $("#loTags").val()
        };
    }

    $scope.crearUnidad = function () {  
        //$scope.statusMsg = "Enviando...";
        if (!$scope.unitForm.$valid) {
            console.log("Invalid fields in form!");
            return;
        }
        console.log($scope.unidadActual.tags);
        loService.createLO($scope.unidadActual)
        .success(function (data) {
            if (data.errors == null) {
                $scope.redireccionar(data.url);
            } else {
                console.log(data.errors);
            }
        })
        .error(function (data) {
            console.log(data);
        });
       
        $scope.status = "";
        console.log('crear Unidad', $scope.unidadActual);         
    }

    $scope.updateLO = function () {
        if (!$scope.unitForm.$valid) {
            console.log("Invalid fields in form!");
            return;
        }
        loService.updateLO($scope.unidadActual)
        .success(function (data) {
            if (data.errors == null) {
                $scope.redireccionar('/Publisher/LearningObjects/'+circleID);
            } else {
                console.log(data.errors);
            }
        })
        .error(function (data) {
            console.log(data);
        });
    }

    $scope.cancelarUnidad = function () {
        //console.log('cancelar Unidad', 'Regresar a crear Unidad');
        window.history.back();
    }
});

