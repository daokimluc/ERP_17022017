


var app = angular.module('userApp', ['angularUtils.directives.dirPagination', 'ui-listView', 'ngMask']);

app.controller('userCtrl', userCtrl);
app.controller('phanquyenCtrl', phanquyenCtrl);
app.controller('nhanvienCtrl', nhanvienCtrl);

//function nhân viên

function nhanvienCtrl($scope, $http) {

    
    $scope.get_nhanvien = function (username) {
        $http.get("/api/Api_NhanvienHL/" + username).then(function (response) {
            $scope.nhanvien = response.data;
        });
    }

    }

//function phân quyền

function phanquyenCtrl($scope, $http) {

    //Infinite Scrolling
    $scope.$watch("listOptions.range", function (range) {
        if (range && range.index + range.length === range.total) {
            loadMoreItems(range);
        }
    });


    // lấy dữ liệu danh sách nghiêp vụ từ server 

    $scope.get_nghiepvu = function () {
        $http.get("/api/Api_Nghiepvu")
                .then(function (response) {
                    $scope.danhsachnghiepvu = response.data;
                });

    }

    // init dữ liệu
    $scope.get_nghiepvu();


    $scope.check = function (id, username) {

        $scope.check_click = true;
        $http.get("/api/Api_Chitietnghiepvu/" + id)
                .then(function (response) {
                    $scope.chitietnghiepvu = response.data;
                });


    }


    
    //------------------end nghiệp vụ-------------------------


    // lấy dữ liệu danh sách nghiêp vụ nhân viên từ server 
    $scope.get_nghiepvunhanvien = function (username) {
        $http.get("/api/Api_NghiepvunhanvienHL/"+username)
                .then(function (response) {
                    $scope.danhsachnghiepvunhanvien = response.data;
                });

    }



    //Insert or update data

    $scope.Capnhatnghiepvu= function (id_ctnc, username, mota) {

        var data_capnhat = {
            ID_CHI_TIET_NGHIEP_VU: id,
            USERNAME: username,
            MO_TA: mota
        }
        $http.post("/api/Api_NghiepvunhanvienHL", data_capnhat).then(function (response) {
        });




    }


    //What class
    $scope.whatclass = function (somevalue) {
        if (somevalue != null) {
            return "text-center"
        }
    };


    //-------------------------------------------------------------

}

//function user
function userCtrl($scope, $http) {

    $scope.get_user = function () {
        $http.get("/api/Api_NguoidungHL")
                .then(function (response) {
                    $scope.danhsachuser = response.data;

                });

    }
    $scope.get_user();
    //-------------------------------------------------------------



    //Insert data

    $scope.add = function () {

        var data_add = {
            USERNAME: $scope.username,
            PASSWORD: $scope.password,
            HO_VA_TEN: $scope.hovaten,
            SDT: $scope.sdt,
            EMAIL: $scope.email,
            IS_ADMIN: $scope.admin,
            ALLOWED: $scope.allowed,
            MA_CONG_TY: "HOP_LONG"
        }
        $http.post("/api/Api_NguoidungHL", data_add).then(function (response) {
            $scope.get_user();
            var nhanvien_add = {
                USERNAME: $scope.username,
                GIOI_TINH: $scope.gioitinh,
                NGAY_SINH: $scope.ngaysinh,
                QUE_QUAN: $scope.quequan,
                TRINH_DO_HOC_VAN: $scope.trinhdohocvan,
                MA_PHONG_BAN: $scope.maphongban
            }
            $http.post("/api/Api_NhanvienHL", nhanvien_add).then(function (response) {
                $scope.get_user();
            });
        });




    }
    //-------------------------------------------------------------
    // Update data
    $scope.edit = function (item) {
        $scope.item = item;
    }

    $scope.update_nv = function (nhanvien) {
        $scope.nhanvien = nhanvien;
    }
    $scope.save = function (user) {
        var data_update = {
            ID: user,
            USERNAME: $scope.item.USERNAME,
            PASSWORD: $scope.item.PASSWORD,
            HO_VA_TEN: $scope.item.HO_VA_TEN,
            SDT: $scope.item.SDT,
            EMAIL: $scope.item.EMAIL,
            IS_ADMIN: $scope.item.IS_ADMIN,
            ALLOWED: $scope.item.ALLOWED,
            MA_CONG_TY: "HOP_LONG",
        }
        $http.put("/api/Api_NguoidungHL/" + user, data_update).then(function (response) {
            $scope.get_user();
            var nhanvien_update = {
                USERNAME: $scope.item.USERNAME,
                GIOI_TINH: $scope.nhanvien.GIOI_TINH,
                NGAY_SINH: $scope.nhanvien.NGAY_SINH,
                QUE_QUAN: $scope.nhanvien.QUE_QUAN,
                TRINH_DO_HOC_VAN: $scope.nhanvien.TRINH_DO_HOC_VAN,
                MA_PHONG_BAN: $scope.nhanvien.MA_PHONG_BAN
            }
            $http.put("/api/Api_NhanvienHL/" + $scope.item.USERNAME, nhanvien_update).then(function (response) {
                $scope.get_user();
            });
        });
    }
    //-------------------------------------------------------------
    // Xóa 
    $scope.delete = function (user) {

        var data_delete = {
            ID: user,
        }


        $http.delete("/api/Api_NguoidungHL/" + user, data_delete)
            .then(function (response) {
                $scope.get_user();
            });
    }


    


}
