(function (app) {
    app.controller('homeController', homeController);
    homeController.$inject = ['$scope', 'apiService'];

    function homeController($scope, apiService) {
        $scope.orders = [];
        $scope.totalOrder = 0;
        $scope.getOrders = getOrders;
        function getOrders() {
            var params = {};
            apiService.get('api/order/totalorders', params, function (result) {
                $scope.orders = result.data.Items;
                $scope.totalOrder = result.data.totalCount;
            }, function (error) {
                console.log('Load totalOrders failure.');
            });
        };

    }
})(angular.module('webbanhang'));