(function (app) {
    app.controller('categoryChildEditController', categoryChildEditController)

    categoryChildEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function categoryChildEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.categoryChild = {
            CreatedDate: new Date(),
            State: true,
        }

        $scope.UpdateCategoryChild = UpdateCategoryChild;
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.categoryChild.Alias = commonService.getSeoTitle($scope.categoryChild.CategoryChildName)
        }
        function loadCategoryChildDetail() {
            apiService.get('api/categorychild/getbyid/' + $stateParams.id, null, function (result) {
                $scope.categoryChild = result.data;
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công.')
            });
        }

        function UpdateCategoryChild() {
            apiService.put('api/categorychild/update', $scope.categoryChild,
                function (result) {
                    notificationService.displaySuccess(result.data.CategoryChildName + ' đã được cập nhật.')
                    $state.go('category_childs')
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.')
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
        loadCategoryChildDetail();
    }
})(angular.module('webbanhang.category_childs'));