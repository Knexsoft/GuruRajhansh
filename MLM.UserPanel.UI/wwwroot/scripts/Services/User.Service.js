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

    // added by SB 29-28-2018
    rm.GetAllUserBySponserID = function (sponserID) {
        return $http({
            method: 'GET',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: "/user/GetUserBySponserID?sponserID=" + sponserID 
        });
    }

    // get francise pin list
    rm.GetFranchiseIncomeTypes = function () {
        return $http({
            method: 'GET',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: "/FranchiseIncome/GetFranchiseIncomeTypes"
        });
    }

    // add new francise
    rm.AddNewFranchise = function (oFranchise) {
        return $http({
            method: 'POST',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: "/FranchiseIncome/AddFranchise",
            params: oFranchise
        });
    }

    // Get franchiseDetail by pin 
    rm.FranchiseDetail  = function (oPin) {
        return $http({
            method: 'GET',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: "/FranchiseIncome/GetFranchiseDetailByPin?oPin=" + oPin,
        });
    }

    // Get pins Detail by userID 
    rm.GetPinsDetailByUserID = function (userID) {
        return $http({
            method: 'GET',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: "/FranchiseIncome/PinsList?userID=" + userID,
        });
    }
}])