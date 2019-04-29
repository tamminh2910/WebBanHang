(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == true)
                return 'Đã giao';
            else return 'Chưa giao';
        }
    });
})(angular.module('webbanhang.common'));