/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />


var app = angular.module('taikhoanApp', ['angularUtils.directives.dirPagination']);
app.controller('taikhoanCtrl', taikhoanCtrl);

function taikhoanCtrl($scope, $http)
{
    $scope.get_hang = function () {
        $http.get("/api/Api_TaikhoanhachtoanTADAN")
                .then(function (response) {
                    $scope.taikhoan = response.data;
                });

    }
    $scope.get_hang();
}

