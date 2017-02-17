var app = angular.module('phanquyen', ['ui-listView']);
app.controller('phanquyenCtrl', function ($scope, $http) {

    //Infinite Scrolling
    $scope.$watch("listOptions.range", function (range) {
        if (range && range.index + range.length === range.total) {
            loadMoreItems(range);
        }
    });

    // lấy dữ liệu từ server
    $scope.get_nghiepvu = function () {
        $http.get("/api/Api_Nghiepvu")
                .then(function (response) {
                    $scope.danhsachnghiepvu = response.data;
                });

    }
   
    // init dữ liệu
    $scope.get_nghiepvu();

    $scope.check = function(id) {
        $scope.check_click = true;
        $http.get("/api/Api_Chitietnghiepvu/"+id)
                .then(function (response) {
                    $scope.chitietnghiepvu = response.data;
                });

    }
});