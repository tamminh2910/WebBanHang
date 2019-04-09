(function (app) {
    app.controller('employeeAddController', employeeAddController)

    employeeAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','commonService'];

    function employeeAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.employee = {
            CreatedDate: new Date()
        }
        $scope.AddEmployee = AddEmployee;
        function AddEmployee() {
            apiService.post('api/employee/create', $scope.employee,
                function (result) {
                    notificationService.displaySuccess(result.data.EmployeeName + ' đã được thêm mới.')
                    $state.go('employees')
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.')
                });

        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.employee.Image = fileUrl;
                })
            }
            finder.popup();
        }
    }
})(angular.module('webbanhang.employees'));