(function (app) {
    app.controller('categoryChildAddController', categoryChildAddController)

    categoryChildAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function categoryChildAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.categoryChild = {
            CreatedDate: new Date(),
            State: true
        }
        $scope.AddCategoryChild = AddCategoryChild;
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.categoryChild.Alias = commonService.getSeoTitle($scope.categoryChild.CategoryChildName)
        }
        function AddCategoryChild() {
            apiService.post('api/categorychild/create', $scope.categoryChild,
                function (result) {
                    notificationService.displaySuccess(result.data.CategoryChildName + ' đã được thêm mới.')
                    $state.go('category_childs')
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.')
                });

        }
        function loadCategoryParent() {
            apiService.get('api/categoryparent/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadCategoryParent();
    }
})(angular.module('webbanhang.category_childs'));