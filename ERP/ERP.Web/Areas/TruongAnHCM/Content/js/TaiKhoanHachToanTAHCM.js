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
        $http.get("/api/Api_TaiKhoanHachToanTAHCM")
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



    

}

