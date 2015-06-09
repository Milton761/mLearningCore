mlearningApp.factory("globales", function ($rootScope) {
	var globales = {};

	return {
		save: function (llave, valor) {
			
			globales[llave] = valor;
		},
		get: function (llave) {
			return globales[llave];
		}
	};

});

