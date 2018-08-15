app.factory('UserService', function ($http) {
    CrateNewUser: function(oUser) {
        $http({
            method: "POST",
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url:""
        })
    }
})