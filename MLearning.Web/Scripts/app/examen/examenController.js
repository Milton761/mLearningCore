mlearningApp.controller('examenController', function ($scope,globales) {

$scope.examenes = [{lotype:'0'}];
   
    $scope.numero = 0;
    
    
$scope.addExamen = function (data) {
console.log('add Examen');
    
    $scope.examenes.push(data);
    
};
    $scope.guardarExamen = function () {
    console.log('guardar Examen');
        console.log($scope.examenes);
    }; 
    

    $scope.crearRespuestas = function (data){
        $scope.respuestas = [];

        
        
        console.log('llama enterClcick',$scope.numero,data);
    for(var i = 0;i< data.num;i++) {
        $scope.respuestas.push(i); 
    }
        
        console.log($scope.respuestas);
    };
    
    
});

mlearningApp.directive('exEditor', function () {
    return {
        scope: true,
        templateUrl: 'views/directives/examen-editor.html',
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
mlearningApp.directive('exSlide', function () {
    return {
        scope: true,
        templateUrl: function (element, attrs) {
            var tipo = attrs.tipo || 'pagina-slide';
            return 'views/directives/' + tipo + '.html';
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

            if(event.which === 13 && scope.numero.length>0) {
                scope.$apply(function (){
                    scope.$eval(attrs.ngEnter);
                    scope.newItem='';
                });

                event.preventDefault();
            }
        });
    };
});