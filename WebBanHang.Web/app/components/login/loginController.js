﻿(function (app) {
    app.controller('loginController', ['$scope', 'loginService', '$injector', 'notificationService',
        function ($scope, loginService, $injector, notificationService) {

            $scope.loginData = {
                userName: "",
                password: ""
            };
            $scope.loginSubmit = function () {
                loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                    if (response == null) {
                        var stateService = $injector.get('$state');
                        stateService.go('home');

                    }
                    else {
                        notificationService.displayError("Đăng nhập không đúng.");
                    }
                });
            }
        }]);
})(angular.module("webbanhang")); 