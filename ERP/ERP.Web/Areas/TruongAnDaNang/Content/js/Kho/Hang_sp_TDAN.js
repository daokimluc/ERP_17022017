/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />


var app = angular.module('hangApp', ['angularUtils.directives.dirPagination']);
app.controller('hangCtrl', hangCtrl);

function hangCtrl($scope, $http)
{
    $scope.get_hang = function () {
        $http.get("/api/Api_HANG_SP_TADAN")
                .then(function (response) {
                    $scope.nhomhang = response.data;
                });

    }
    $scope.get_hang();
}

