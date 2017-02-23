


var app = angular.module('hanghoaApp', ['angularUtils.directives.dirPagination']);
app.controller('hangHoaCtrl', hangHoaCtrl);
//function nhom hang

app.controller('tonkhoCtrl', tonkhoCtrl);

function tonkhoCtrl($scope, $http) {

        $scope.get_tonkho = function (id) {
            $http.get("/api/Api_TonKhoDaiLy/" + id + "/DAI_LY_1").then(function (response) {

                $scope.danhsachtonkho = response.data
            });
        }
    
    $scope.getTotal = function (type) {
        var total = 0;
        angular.forEach($scope.danhsachtonkho, function (el) {
            total += el[type];
        });
        return total;
    };
}

//function hang hoa
function hangHoaCtrl($scope, $http) {

    

    // lấy dữ liệu từ server(hàng hóa)
    $scope.get_hanghoa = function () {
        $http.get("/api/Api_HangHoaDaiLy")
                .then(function (response) {
                    $scope.danhsachhanghoa = response.data;
                });

    }
    // init dữ liệu
    $scope.get_hanghoa();
    //-------------------------------------------------------------


}

