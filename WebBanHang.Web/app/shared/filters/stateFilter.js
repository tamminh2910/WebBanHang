(function (app) {
    app.filter('stateFilter', function () {
        return function (input) {
            if (input == true)
                return 'Kích hoạt';
            else return 'Khóa';
        }
    });
})(angular.module('webbanhang.common'));