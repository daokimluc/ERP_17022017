/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />


app.controller('hangHoaCtrl', hangHoaCtrl);
//function nhom hang

app.controller('tonkhoCtrl', tonkhoCtrl);

function tonkhoCtrl($scope, $http) {
    $scope.get_tonkho = function (id) {
        $http.get("/api/Api_TonkhoTAHCM/"+id).then(function (response) {
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
    // lấy dữ liệu từ server(nhóm hàng)
    $scope.get_nhomhang = function () {
        $http.get("/api/Api_HanghoaTAHCM")
                .then(function (response) {
                    $scope.danhsachnhomhang = response.data;
                });

    }
    $scope.get_nhomhang();
    //-------------------------------------------------------------

    $scope.passing = function (item) {
        $scope.item = item;
    }


    // lấy dữ liệu từ server(hàng hóa)
    $scope.get_hanghoa = function () {
        $http.get("/api/Api_HanghoaTAHCM")
                .then(function (response) {
                    $scope.danhsachhanghoa = response.data;
                });

    }

    // init dữ liệu
    $scope.get_hanghoa();
    //-------------------------------------------------------------



    //Insert data

    $scope.add = function () {
        var data_add = {
            MA_HANG_HT: $scope.mahanght,
            MA_HANG_NHAP: $scope.mahangnhap,
            TEN_HANG: $scope.tenhang,
            MA_NHOM_HANG: $scope.manhomhang,
            SERI: $scope.seri,
            DON_VI_TINH: $scope.donvitinh,
            MODEL_DAC_BIET: $scope.modeldacbiet,
            HINH_ANH: $scope.hinhanh,
            DAC_TINH: $scope.dactinh,
            GHI_CHU: $scope.ghichu,
            TK_HACH_TOAN_KHO: $scope.tkhachtoankho,
            TK_DOANH_THU: $scope.tkdoanhthu,
            TK_CHI_PHI: $scope.tkchiphi

        }
        $http.post("/api/Api_HanghoaTAHCM", data_add).then(function (response) {
            $scope.get_hanghoa();

        });
    }
    //-------------------------------------------------------------
    // Update data
    $scope.edit = function (item) {
        $scope.item = item;

    }

    $scope.save = function (mahanght) {
        var data_update = {
            MA_HANG_HT: $scope.item.MA_HANG_HT,
            MA_HANG_NHAP: $scope.item.MA_HANG_NHAP,
            TEN_HANG: $scope.item.TEN_HANG,
            MA_NHOM_HANG: $scope.item.MA_NHOM_HANG,
            SERI: $scope.item.SERI,
            DON_VI_TINH: $scope.item.DON_VI_TINH,
            MODEL_DAC_BIET: $scope.item.MODEL_DAC_BIET,
            HINH_ANH: $scope.item.HINH_ANH,
            DAC_TINH: $scope.item.DAC_TINH,
            GHI_CHU: $scope.item.GHI_CHU,
            TK_HACH_TOAN_KHO: $scope.item.TK_HACH_TOAN_KHO,
            TK_DOANH_THU: $scope.item.TK_DOANH_THU,
            TK_CHI_PHI: $scope.item.TK_CHI_PHI,
        }
        $http.put("/api/Api_HanghoaTAHCM/" + mahanght, data_update).then(function (response) {
            $scope.get_hanghoa();

        });
    }
    //-------------------------------------------------------------
    // Xóa 
    $scope.delete = function (mahanght) {

        var data_delete = {
            MA_HANG_HT: mahanght
        }


        $http.delete("/api/Api_HanghoaTAHCM/" + mahanght, data_delete)
            .then(function (response) {
                $scope.get_hanghoa();
            });
    }

    $scope.mahangHT = false;
    $scope.ma_hang_nhap = false;
    $scope.ten_hang = false;
    $scope.ma_nhom_hang = false;
    $scope.don_vi_tinh = false;
    $scope.model_dac_biet = false;

    $scope.showmahangHT = {
        title: 'Mã đã quy chuẩn và duy nhất trong hợp long'
    };

    $scope.showmahangnhap = {
        title: 'Mã người dùng nhập vào'
    };

    $scope.showtenhang = {
        title: 'Tên hàng hóa'
    };

    $scope.showmanhomhang = {
        title: 'Tên hãng cung cấp'
    };

    $scope.showdonvitinh = {
        title: 'Đơn vị tính'
    };

    $scope.showmodeldacbiet = {
        title: 'Mã có giá đặc biệt'
    };

}

