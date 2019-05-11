(function (app) {
    app.controller('orderEditController', orderEditController)

    orderEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function orderEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.order = {
            RegisterDate: new Date(),
            State: true,
        }
        $scope.orderDetails = [];
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.UpdateOrder = UpdateOrder;
        $scope.getTotal = getTotal;

        function getTotal() {
            var total = 0;
            for (var i = 0; i < $scope.orderDetails.length; i++) {
                var orderdetail = $scope.orderDetails[i];
                total += (orderdetail.UnitPrice * orderdetail.Quantity);
            }
            return total;
        }
        $scope.DeleteImage = function (s) {
            $scope.moreImages.splice($scope.moreImages.indexOf(s), 1);
        };

        function loadOrder() {
            apiService.get('api/order/getbyid/' + $stateParams.id, null, function (result) {
                $scope.order = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        function UpdateOrder() {
            apiService.put('api/order/update', $scope.order,
                function (result) {
                    notificationService.displaySuccess('Đơn hàng đã được cập nhật.')
                    $state.go('orders')
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.')
                });
        }
        function loadOrderDetail() {
            apiService.get('api/orderdetail/getbyid/' + $stateParams.id, null, function (result) {
                $scope.orderDetails = result.data;
            }, function () {
                console.log('Cannot get list orderdetail');
            });
        }


        loadOrder();
        loadOrderDetail();
    }
})(angular.module('webbanhang.orders'));