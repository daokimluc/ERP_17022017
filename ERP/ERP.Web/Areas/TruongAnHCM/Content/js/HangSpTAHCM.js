/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />
/// <reference path="../../Views/HangHoaHL/Create.cshtml" />



app.controller('hangspCtrl', hangspCtrl);
//function nhom hang



//function hang hoa
function hangspCtrl($scope, $http) {
    // lấy dữ liệu từ server(nhóm hàng)
    $scope.get_hangsp = function () {
        $http.get("/api/Api_HangSpTAHCM")
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

   

}

