app.controller("ctrLogin", ['$scope', '$window', 'UserServices', function ($scope, $window, UserServices) {
    var oUser = {};
    $scope.Login = function () {
        $scope.$parent.Preloader = true;
        var _user = $scope.Login;
        oUser = {
            UserID: _user.PhoneNumber,
            Password: _user.Password
        };
        UserServices.Login(oUser).then(function (respone) {
            $scope.$parent.Preloader = false;
            if (respone.data != null) { 
                localStorage.removeItem("user");
                localStorage.setItem("user", JSON.stringify(respone.data));
                $window.location.href = '/dashboard';
            }
        }, function (error) {
            $scope.$parent.Preloader = false;
            alert(error)
        });
    }
}]);