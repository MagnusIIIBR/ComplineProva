(function () {
    'use strict';

    angular
        .module('app')
        .factory('TarefaRepository', TarefaRepository);

    TarefaRepository.$inject = ['$http', '$rootScope', '$location'];

    function TarefaRepository($http, $rootScope, $location) {
        return {
            getTarefas: function () {
                return $http.get("/api/tarefas");
            },
            atualizar: function (tarefa) {
                return $http.put("/api/tarefas/" + tarefa.id, tarefa);
            },
            adicionar: function (tarefa) {
                return $http.post("/api/tarefas", tarefa);
            },
            deletar: function (tarefaId) {
                return $http.delete("/api/tarefas/" + tarefaId);
            },
        };
    }
})();