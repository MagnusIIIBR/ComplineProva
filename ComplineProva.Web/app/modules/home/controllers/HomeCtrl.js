(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeCtrl', HomeCtrl);

    HomeCtrl.$inject = ['$scope', '$http', 'TarefaRepository'];

    function HomeCtrl($scope, $http, TarefaRepository) {
        $scope.tarefa = {
            id: 0,
            titulo: '',
            prioridade: 0,
            importante: false
        }

        $scope.tarefas = [];

        loadGrid();

        $scope.saveOrUpdate = function (tarefa) {
            tarefa = format(tarefa);
            if (tarefa.id == 0) {
                $scope.save(tarefa);
            } else {
                $scope.update(tarefa);
            }
            New();
            loadGrid();
        }

        function format(tarefa) {
            tarefa.id = parseInt(tarefa.id);
            tarefa.prioridade = parseInt(tarefa.prioridade);
            return tarefa;
        }

        $scope.new = function () {
            New();
        }

        $scope.delete = function (tarefa) {
            var index = $scope.tarefas.indexOf(tarefa)
            TarefaRepository
                .deletar(tarefa.id)
                .then(
                function (result) {
                    $scope.tarefas.splice(index, 1);
                    toastr.info(result.data, "Registro excluído com sucesso")
                },
                function (error) {
                    toastr.error(error.data, "Falha ao excluir o registro");
                });

        }

        $scope.save = function (tarefa) {
            TarefaRepository
                .adicionar(tarefa)
                .then(
                function (result) {
                    toastr.info(result.data, "Registro criado com sucesso")
                    tarefa.id = $scope.tarefas.length + 1;
                    $scope.tarefas.push(tarefa);
                },
                function (error) {
                    toastr.error(error.data, "Falha na criação do registro");
                });
        }

        $scope.update = function (tarefa) {
            TarefaRepository
                .atualizar(tarefa)
                .then(
                function (result) {
                    toastr.info(result.data, "Registro atualizado com sucesso!")
                    var index = $scope.tarefas.indexOf(tarefa);
                    $scope.tarefas[index] = tarefa;
                },
                function (error) {
                    toastr.error(error.data, "Falha na atualização do registro");
                });
        }

        $scope.setImportant = function (tarefa) {
            tarefa.importante ? tarefa.importante = false : tarefa.importante = true;

            TarefaRepository
                .atualizar(tarefa)
                .then(
                function (result) {
                    toastr.info(result.data, "Registro atualizado com sucesso")
                },
                function (error) {
                    toastr.error(error.data, "Falha na atualização do registro");
                });
        }

        $scope.select = function (tarefa) {
            $scope.tarefa = tarefa;
        }

        function New() {
            $scope.tarefa = {
                id: 0,
                titulo: '',
                prioridade: 0,
                importante: false
            }
        }

        function loadGrid() {
            TarefaRepository
                .getTarefas()
                .then(
                function (result) {
                    $scope.tarefas = null;
                    $scope.tarefas = result.data;
                    console.log(result.data);
                },
                function (error) {
                    toastr.error(error.data, "Falha ao carregar os registros");
                });
        }

    }
})();

