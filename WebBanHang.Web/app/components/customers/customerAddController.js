(function (app) {
    app.controller('customerAddController', customerAddController)

    customerAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','commonService'];

    function customerAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.customer = {
            CreatedDate: new Date()
        }
        $scope.AddCustomer = AddCustomer;
        function AddCustomer() {
            apiService.post('api/customer/create', $scope.customer,
                function (result) {
                    notificationService.displaySuccess(result.data.CustomerName + ' đã được thêm mới.')
                    $state.go('customers')
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.')
                });

        }
    }
})(angular.module('webbanhang.customers'));