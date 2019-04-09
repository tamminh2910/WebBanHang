(function (app) {
    app.controller('employeeEditController', employeeEditController)

    employeeEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function employeeEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.employee = {};

        $scope.UpdateEmployee = UpdateEmployee;
        function loadEmployeeDetail() {
            apiService.get('api/employee/getbyid/' + $stateParams.id, null, function (result) {
                $scope.employee = result.data;
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công.')
            });
        }

        function UpdateEmployee() {
            
            apiService.put('api/employee/update', $scope.employee,
                function (result) {
                    notificationService.displaySuccess(result.data.EmployeeName + ' đã được cập nhật.')
                    $state.go('employees')
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.')
                });
        }
        loadEmployeeDetail();
    }
})(angular.module('webbanhang.employees'));