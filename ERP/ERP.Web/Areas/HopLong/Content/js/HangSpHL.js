

app.controller('hangspCtrl', hangspCtrl);
//function nhom hang



//function hang hoa
function hangspCtrl($scope, $http) {
    // lấy dữ liệu từ server(nhóm hàng)
    $scope.get_hangsp = function (id) {
        $http.get("/api/Api_HangsanphamHL")
                .then(function (response) {
                    $scope.danhsachsp = response.data;
                });

    }

    $scope.get_hangsp();
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
            MA_NHOM_HANG: $scope.manhomhang,
            TEN_NHOM_HANG: $scope.tennhomhang,
            MA_NHOM_HANG_CHA: $scope.manhomhangcha,
            GHI_CHU: $scope.ghichu,
        }
        $http.post("/api/Api_HangsanphamHL", data_add).then(function (response) {
            $scope.get_hangsp();

        });
    }
    //-------------------------------------------------------------
    // Update data
    $scope.edit = function (item) {
        $scope.item = item;
    }

    $scope.save = function (nhomhang) {
        var data_update = {
            MA_NHOM_HANG: $scope.item.MA_NHOM_HANG,
            TEN_NHOM_HANG: $scope.item.TEN_NHOM_HANG,
            MA_NHOM_HANG_CHA: $scope.item.MA_NHOM_HANG_CHA,
            GHI_CHU: $scope.item.GHI_CHU,
        }
        $http.put("/api/Api_HangsanphamHL/" + nhomhang, data_update).then(function (response) {
            $scope.get_hangsp();

        });
    }
    //-------------------------------------------------------------
    // Xóa 
    $scope.delete = function (nhomhang) {

        var data_delete = {
            MA_NHOM_HANG: nhomhang
        }


        $http.delete("/api/Api_HangsanphamHL/" + nhomhang, data_delete)
            .then(function (response) {
                $scope.get_hangsp();
            });
    }

}

