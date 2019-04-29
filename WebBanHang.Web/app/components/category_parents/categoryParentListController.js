(function (app) {
    app.controller('categoryParentListController', categoryParentListController);

    categoryParentListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function categoryParentListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.categoryParents = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;
        $scope.getListCategoryParents = getListCategoryParents;
        $scope.deleteCategoryParent = deleteCategoryParent;
        $scope.selectAll = selectAll;

        $scope.deleteMultiple = deleteMultiple;
        $scope.propertyName = '';
        $scope.reverse = true;
        $scope.sortBy = function (propertyName) {
            $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
            $scope.propertyName = propertyName;
        };

        function deleteMultiple() {
            var listID = [];
            $.each($scope.selected, function (i, item) {
                listID.push(item.CategoryParentID);
            })
            var config = {
                params: {
                    listItem: JSON.stringify(listID)
                }
            }
            apiService.del('api/categoryparent/deleteMulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                search();

            }, function (error) {
                notificationService.displayError('Xóa không thành công');

            })
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.categoryParents, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.categoryParents, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("categoryParents", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteCategoryParent(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/categoryparent/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa thất bại');
                });
            })


        }

        function search() {
            getListCategoryParents();
        }



        function getListCategoryParents(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 7
                }
            }
            apiService.get('/api/categoryparent/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy!');
                }
                else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi')
                }
                $scope.categoryParents = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;

            }, function () {
                console.log('Load categoryParent failed.');
            });
        }
        $scope.getListCategoryParents();
    }
})(angular.module('webbanhang.category_parents'));