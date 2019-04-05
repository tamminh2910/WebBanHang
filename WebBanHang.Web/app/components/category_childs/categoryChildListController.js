(function (app) {
    app.controller('categoryChildListController', categoryChildListController);

    categoryChildListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function categoryChildListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.categoryChilds = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;
        $scope.getListCategoryChilds = getListCategoryChilds;
        $scope.deleteCategoryChild = deleteCategoryChild;
        $scope.selectAll = selectAll;

        $scope.deleteMultiple = deleteMultiple;

        function deleteMultiple() {
            var listID = [];
            $.each($scope.selected, function (i, item) {
                listID.push(item.CategoryChildID);
            })
            var config = {
                params: {
                    listItem: JSON.stringify(listID)
                }
            }
            apiService.del('api/categorychild/deleteMulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                search();

            }, function (error) {
                notificationService.displayError('Xóa không thành công');

            })
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.categoryChilds, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.categoryChilds, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("categoryChilds", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteCategoryChild(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/categorychild/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa thất bại');
                });
            })


        }

        function search() {
            getListCategoryChilds();
        }



        function getListCategoryChilds(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/categorychild/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy!');
                }
                else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi')
                }
                $scope.categoryChilds = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;

            }, function () {
                console.log('Load categoryChild failed.');
            });
        }
        $scope.getListCategoryChilds();
    }
})(angular.module('webbanhang.category_childs'));