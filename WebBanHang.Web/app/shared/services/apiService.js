﻿/// <reference path="../../../bower_components/angular/angular.js" />
(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService'];
    function apiService($http, notificationService) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
        }
        function del(url, data, success, failure) {
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.state === '401') {
                    notificationService.displayError('Authenticate is required');
                }
                failure(error);
            });
        }
        function put(url, data, success, failure) {
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.state ==='401') {
                    notificationService.displayError('Authenticate is required');
                }
                failure(error);
            });
        }
        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.state === '401') {
                    notificationService.displayError('Authenticate is required');
                }
                failure(error);
            });
        }
        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    }
})(angular.module('webbanhang.common'));