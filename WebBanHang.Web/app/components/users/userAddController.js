(function (app) {
    app.controller('userAddController', userAddController)

    userAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','commonService'];

    function userAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.user = {
            CreatedDate: new Date()
        }
        $scope.AddUser = AddUser;
        function AddUser() {
            apiService.post('api/user/create', $scope.user,
                function (result) {
                    notificationService.displaySuccess(result.data.FullName + ' đã được thêm mới.')
                    $state.go('users')
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.')
                });

        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.user.Image = fileUrl;
                })
            }
            finder.popup();
        }
    }
})(angular.module('webbanhang.users'));