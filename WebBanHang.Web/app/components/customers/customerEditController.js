(function (app) {
    app.controller('customerEditController', customerEditController)

    customerEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function customerEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.customer = {
        }

        $scope.UpdateCustomer = UpdateCustomer;
        function loadCustomerDetail() {
            apiService.get('api/customer/getbyid/' + $stateParams.id, null, function (result) {
                $scope.customer = result.data;
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công.')
            });
        }

        function UpdateCustomer() {
            
            apiService.put('api/customer/update', $scope.customer,
                function (result) {
                    notificationService.displaySuccess(result.data.CustomerName + ' đã được cập nhật.')
                    $state.go('customers')
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.')
                });
        }
        loadCustomerDetail();
    }
})(angular.module('webbanhang.customers'));