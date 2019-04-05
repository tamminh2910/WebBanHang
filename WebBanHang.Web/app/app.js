﻿/// <reference path="../bower_components/angular/angular.js" />
(function () {
    angular.module('webbanhang',
        ['webbanhang.products',
            'webbanhang.category_parents',
            'webbanhang.category_childs',
            'webbanhang.common'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise("/admin");
    }
})();