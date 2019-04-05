(function (app) {
    app.controller('categoryParentAddController', categoryParentAddController)

    categoryParentAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','commonService'];

    function categoryParentAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.categoryParent = {
            CreatedDate: new Date(),
            State: true,
            CategoryParentName: 'Danh mục 1'
        }
        $scope.AddCategoryParent = AddCategoryParent;
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.categoryParent.Alias = commonService.getSeoTitle($scope.categoryParent.CategoryParentName)
        }
        function AddCategoryParent() {
            apiService.post('api/categoryparent/create', $scope.categoryParent,
                function (result) {
                    notificationService.displaySuccess(result.data.CategoryParentName + ' đã được thêm mới.')
                    $state.go('category_parents')
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.')
                });

        }
    }
})(angular.module('webbanhang.category_parents'));