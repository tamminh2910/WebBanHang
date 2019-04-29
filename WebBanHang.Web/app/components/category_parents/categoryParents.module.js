/// <reference path="../../../bower_components/angular/angular.js" />
(function () {
    angular.module('webbanhang.category_parents', ['webbanhang.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('category_parents', {
            url: "/category_parents",
            parent: 'base',
            templateUrl: "/app/components/category_parents/categoryParentListView.html",
            controller: "categoryParentListController"
        }).state('add_category_parents', {
            url: "/add_category_parents",
            parent: 'base',
            templateUrl: "/app/components/category_parents/categoryParentAddView.html",
            controller: "categoryParentAddController"
        }).state('edit_category_parent', {
            url: "/edit_category_parent/:id",
            parent: 'base',
            templateUrl: "/app/components/category_parents/categoryParentEditView.html",
            controller: "categoryParentEditController"
        });

    }
})();