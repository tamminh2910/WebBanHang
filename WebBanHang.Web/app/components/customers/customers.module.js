/// <reference path="../../../bower_components/angular/angular.js" />
(function () {
    angular.module('webbanhang.customers', ['webbanhang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('customers', {
            url: "/customers",
            templateUrl: "/app/components/customers/customerListView.html",
            controller: "customerListController"
        }).state('add_customer', {
            url: "/add_customer",
            templateUrl: "/app/components/customers/customerAddView.html",
            controller: "customerAddController"
        }).state('edit_customer', {
            url: "/edit_customer/:id",
            templateUrl: "/app/components/customers/customerEditView.html",
            controller: "customerEditController"
        });

    }
})();