//app.factory('UserService', function ($http) {
//    CrateNewUser: function(oUser) {
//        $http({
//            method: "POST",
//            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
//            url:""
//        })
//    }
//})

app.service('UserServices', ['$http', function ($http) {
    var rm = this;
    rm.CreateNewUser = function (oUser) {
        return $http({
            method: 'POST',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: "/User/Register",
            params: oUser
        });
    }

    rm.Login = function (oUser) {
        return $http({
            method: 'POST',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: "/User/Login",
            params: oUser
        });
    }

    rm.Logout = function () {
        return $http({
            method: 'GET',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: "/user/Logout"
        });
    }
}])