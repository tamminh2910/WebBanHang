/// <reference path="../../../bower_components/angular/angular.js" />
(function () {
    angular.module('webbanhang.employees', ['webbanhang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('employees', {
            url: "/employees",
            parent: 'base',
            templateUrl: "/app/components/employees/employeeListView.html",
            controller: "employeeListController"
        }).state('add_employee', {
            url: "/add_employee",
            parent: 'base',
            templateUrl: "/app/components/employees/employeeAddView.html",
            controller: "employeeAddController"
        }).state('edit_employee', {
            url: "/edit_employee/:id",
            parent: 'base',
            templateUrl: "/app/components/employees/employeeEditView.html",
            controller: "employeeEditController"
        });

    }
})();