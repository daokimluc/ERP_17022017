var app = angular.module('khoApp', []);
app.controller('khoCtrl', function ($scope, $http) {

    // lấy dữ liệu từ server
    $scope.get_kho = function () {
        $http.get("/api/Api_KhoDN")
                .then(function (response) {
                    $scope.danhsachkho = response.data;
                });

    }

    // init dữ liệu
    $scope.get_kho();
    //-------------------------------------------------------------

    // thêm mới
    $scope.add = function () {
        var data_add = {
            MA_KHO: $scope.ma_kho,
            TEN_KHO: $scope.ten_kho,
            DIA_CHI_KHO: $scope.dia_chi,
            MA_KHO_CHA: $scope.ma_kho_cha,
            TRUC_THUOC: "TADAN",
            GHI_CHU: $scope.ghi_chu
            
        }
        $http.post("/api/Api_KhoDN", data_add).then(function (response) {
            $scope.get_kho();
           
        });
    }
    //-----------------------------------------
    // Sửa
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
            GHI_CHU: $scope.item.GHI_CHU
            
        }
        $http.put("/api/Api_KhoDN/" + makho, data_update).then(function (response) {
            $scope.get_kho();
            
        });
    }

    //-----------------------------------------
    // Xóa 
    $scope.delete = function (makho) {

        var data_delete = {
            MA_KHO: makho
        }


        $http.delete("/api/Api_KhoDN/" + makho, data_delete)
            .then(function (response) {
                $scope.get_kho();
            });
    }

});
