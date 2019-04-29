(function (app) {
    app.controller('productAddController', productAddController)

    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            RegisterDate: new Date(),
            State: true
        }
        $scope.AddProduct = AddProduct;
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.DeleteImage = function (s) {
            $scope.moreImages.splice($scope.moreImages.indexOf(s), 1);
        };
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name)
        }
        function AddProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.post('api/product/create', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.')
                    $state.go('products')
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.')
                });

        }
        function loadCategoryChild() {
            apiService.get('api/categorychild/getallchilds', null, function (result) {
                $scope.cagetoryChilds = result.data;
            }, function () {
                console.log('Cannot get list child');
            });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }
        $scope.moreImages = [];
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                if ($scope.moreImages.indexOf(fileUrl) > -1) {

                } else {
                    $scope.$apply(function () {
                        $scope.moreImages.push(fileUrl);
                    })
                }

            };
            finder.popup();
        }
        loadCategoryChild();
    }
})(angular.module('webbanhang.products'));