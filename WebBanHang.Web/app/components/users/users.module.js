/// <reference path="../../../bower_components/angular/angular.js" />
(function () {
    angular.module('webbanhang.users', ['webbanhang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('users', {
            url: "/users",
            parent: 'base',
            templateUrl: "/app/components/users/userListView.html",
            controller: "userListController"
        }).state('add_user', {
            url: "/add_user",
            parent: 'base',
            templateUrl: "/app/components/users/userAddView.html",
            controller: "userAddController"
        }).state('edit_user', {
            url: "/edit_user/:id",
            parent: 'base',
            templateUrl: "/app/components/users/userEditView.html",
            controller: "userEditController"
        });

    }
})();