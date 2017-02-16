/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />


var app = angular.module('khoApp', ['angularUtils.directives.dirPagination']);
app.controller('khoCtrl', khoCtrl);
//function nhom hang

//function hang hoa
function khoCtrl($scope, $http) {

    $scope.get_kho = function () {
        $http.get("/api/Api_KhoTAHCM")
                .then(function (response) {
                    $scope.danhsachkho = response.data;
                });

    }
    $scope.get_kho();
    //-------------------------------------------------------------

    //-------------------------------------------------------------



    //Insert data

    $scope.add = function () {
        var data_add = {
            MA_KHO: $scope.makho,
            TEN_KHO: $scope.tenkho,
            DIA_CHI_KHO: $scope.diachikho,
            MA_KHO_CHA: $scope.makhocha,
            TRUC_THUOC: $scope.tructhuoc,
            GHI_CHU: $scope.ghichu,

        }
        $http.post("/api/Api_KhoTAHCM", data_add).then(function (response) {
            $scope.get_kho();
            $scope.makho = "";
            $scope.tenkho = "";
            $scope.diachikho = "";
            $scope.makhocha = "";
            $scope.tructhuoc = "";
            $scope.ghichu = "";
        });
    }
    //-------------------------------------------------------------
    // Update data
    $scope.edit = function (item) {
        $scope.item = item;
    }

    $scope.save = function (makho) {
        var data_update = {
            MA_KHO: $scope.item.MA_KHO,
            TEN_KHO: $scope.item.TEN_KHO,
            DIA_CHI_KHO: $scope.item.DIA_CHI_KHO,
            MA_KHO_CHA: $scope.item.MA_KHO_CHA,
            TRUC_THUOC: $scope.item.TRUC_THUOC,
            GHI_CHU: $scope.item.GHI_CHU,
        }
        $http.put("/api/Api_KhoTAHCM/" + makho, data_update).then(function (response) {
            $scope.get_kho();
        });
    }
    //-------------------------------------------------------------
    // Xóa 
    $scope.delete = function (makho) {

        var data_delete = {
            MA_KHO: makho
        }


        $http.delete("/api/Api_KhoTAHCM/" + makho, data_delete)
            .then(function (response) {
                $scope.get_hanghoa();
            });
    }

}
