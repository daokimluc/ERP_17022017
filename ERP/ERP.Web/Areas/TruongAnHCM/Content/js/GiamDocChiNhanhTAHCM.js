var app = angular.module("giamdocApp", []);

app.controller("giamdocCtrl", function ($http,$scope) {
    $scope.push = function (username) {
        $http.get("/api/Api_GiamDocChiNhanhTAHCM/" + username).then(function (response) {
            $scope.listgiamdoc = response.data;
        });
    }
});