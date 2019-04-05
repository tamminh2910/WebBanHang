(function (app) {
    app.controller('categoryParentEditController', categoryParentEditController)

    categoryParentEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function categoryParentEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.categoryParent = {
            CreatedDate: new Date(),
            State: true,
        }

        $scope.UpdateCategoryParent = UpdateCategoryParent;
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.categoryParent.Alias = commonService.getSeoTitle($scope.categoryParent.CategoryParentName)
        }
        function loadCategoryParentDetail() {
            apiService.get('api/categoryparent/getbyid/' + $stateParams.id, null, function (result) {
                $scope.categoryParent = result.data;
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công.')
            });
        }

        function UpdateCategoryParent() {
            apiService.put('api/categoryparent/update', $scope.categoryParent,
                function (result) {
                    notificationService.displaySuccess(result.data.CategoryParentName + ' đã được cập nhật.')
                    $state.go('category_parents')
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.')
                });
        }
        loadCategoryParentDetail();
    }
})(angular.module('webbanhang.category_parents'));