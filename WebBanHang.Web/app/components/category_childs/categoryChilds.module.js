/// <reference path="../../../bower_components/angular/angular.js" />
(function () {
    angular.module('webbanhang.category_childs', ['webbanhang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('category_childs', {
            url: "/category_childs",
            parent: 'base',
            templateUrl: "/app/components/category_childs/categoryChildListView.html",
            controller: "categoryChildListController"
        }).state('add_category_child', {
            url: "/add_category_child",
            parent: 'base',
            templateUrl: "/app/components/category_childs/categoryChildAddView.html",
            controller: "categoryChildAddController"
        }).state('edit_category_child', {
            url: "/edit_category_child/:id",
            parent: 'base',
            templateUrl: "/app/components/category_childs/categoryChildEditView.html",
            controller: "categoryChildEditController"
        });

    }
})();