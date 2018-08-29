var app = angular.module("GuruRajhanshApp", []);

app.controller("ctrLayout", ["$scope", "$window", "UserServices", function ($scope, $window, UserServices) {
    $scope.Logout = function () {
        var isLogout = confirm("Are you sure you want to logout?");
        if (isLogout === true) {
            localStorage.clear();
            UserServices.Logout().then(function (response) {
                debugger;
                if (response.status == 200) {
                    $window.location.href = 'user/Login';
                }
            }, function (error) {
                alert(error);
            })
        }
    }
}]);
