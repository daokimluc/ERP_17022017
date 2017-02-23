
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />


var app = angular.module('phongbanApp', ['angularUtils.directives.dirPagination']);
app.controller('phongbanCtrl', phongbanCtrl);

//function nhom hang
app.controller('nhanvienCtrl', nhanvienCtrl);
function nhanvienCtrl($scope, $http) {

    $scope.get_listnhanvien = function (maphongban) {
        $http.get("/api/Api_NhanvienphongbanTADAN/" + maphongban).then(function (response) {
            $scope.listnhanvien = response.data;
        });
    }
    $scope.pass = function (nhanvien) {
        $scope.nhanvien = nhanvien;
    }
}


function phongbanCtrl($scope, $http) {

    $scope.get_phongban = function () {
        $http.get("/api/Api_PhongbanDN")
                .then(function (response) {
                    $scope.danhsachphongban = response.data;

                });

    }
    $scope.get_phongban();
    //-------------------------------------------------------------

    //Insert data

    $scope.add = function () {

        var data_add = {
            MA_PHONG_BAN: $scope.maphongban,
            TEN_PHONG_BAN: $scope.tenphongban,
            SDT: $scope.sdt,
            MA_CONG_TY: "TADAN",
            GHI_CHU : $scope.ghichu,
        }
        $http.post("/api/Api_PhongbanDN/", data_add).then(function (response) {
            $scope.get_phongban();
            $scope.maphongban ="";
            $scope.tenphongban ="";
            $scope.sdt ="";
            $scope.ghichu ="";               
        });
    }
    //-------------------------------------------------------------
    // Update data
    $scope.edit = function (item) {
        $scope.item = item;
    }

    $scope.save = function (phongban) {
        var data_update = {
            MA_PHONG_BAN : phongban,
            TEN_PHONG_BAN: $scope.item.TEN_PHONG_BAN,
            SDT: $scope.item.SDT,         
            MA_CONG_TY: "TADAN",
            GHI_CHU: $scope.item.GHI_CHU,
        }
        $http.put("/api/Api_PhongbanDN/" + phongban, data_update).then(function (response) {
            $scope.get_phongban();

        });
    }
    //-------------------------------------------------------------
    // Xóa 
    $scope.delete = function (phongban) {

        var data_delete = {
            MA_PHONG_BAN : phongban,
        }


        $http.delete("/api/Api_PhongbanDN/" + phongban, data_delete)
            .then(function (response) {
                $scope.get_phongban();
            });
    }

}
