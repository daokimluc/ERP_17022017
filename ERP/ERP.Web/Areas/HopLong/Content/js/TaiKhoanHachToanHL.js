/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />

var taikhoan = angular.module("taikhoanApp", ['angularUtils.directives.dirPagination']);

taikhoan.controller('taikhoanCtrl', taikhoanCtrl);
//function nhom hang



//function hang hoa
function taikhoanCtrl($scope, $http) {
    // lấy dữ liệu từ server(nhóm hàng)
    $scope.get_taikhoan = function (id) {
        $http.get("/api/Api_TaiKhoanHachToanHL")
                .then(function (response) {
                    $scope.danhsachtk = response.data;
                });

    }

    $scope.get_taikhoan();
    //-------------------------------------------------------------

    //-------------------------------------------------------------

    $scope.whatclass = function (somevalue) {
        if (somevalue != null) {
            return "text-center"
        }
    };


    //Insert data

    $scope.add = function () {
        var data_add = {
            SO_TK: $scope.stk,
            TEN_TK: $scope.tentaikhoan,
            TINH_CHAT: $scope.tinhchat,
            TEN_TA: $scope.tentienganh,
            TK_CAP_CHA: $scope.tk_capcha,
            DIEN_GIAI: $scope.diengiai,
        }
        $http.post("/api/Api_TaiKhoanHachToanHL", data_add).then(function (response) {
            $scope.get_taikhoan();

        });
    }
    //-------------------------------------------------------------
    // Update data
    $scope.edit = function (item) {
        $scope.item = item;
    }

    $scope.save = function (taikhoan) {
        var data_update = {
            SO_TK: $scope.item.SO_TK,
            TEN_TK: $scope.item.TEN_TK,
            TINH_CHAT: $scope.item.TINH_CHAT,
            TEN_TA: $scope.item.TEN_TA,
            TK_CAP_CHA: $scope.item.TK_CAP_CHA,
            DIEN_GIAI: $scope.item.DIEN_GIAI,
        }
        $http.put("/api/Api_TaiKhoanHachToanHL/" + taikhoan, data_update).then(function (response) {
            $scope.get_taikhoan();

        });
    }
    //-------------------------------------------------------------
    // Xóa 
    $scope.delete = function (taikhoan) {

        var data_delete = {
            SO_TK: taikhoan
        }


        $http.delete("/api/Api_TaiKhoanHachToanHL/" + taikhoan, data_delete)
            .then(function (response) {
                $scope.get_taikhoan();
            });
    }

}

