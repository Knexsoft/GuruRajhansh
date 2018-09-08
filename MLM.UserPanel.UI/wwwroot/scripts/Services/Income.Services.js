app.service('IncomeServices', ['$http', function ($http) {
    var rm = this;

    // get singleleg income
    rm.getSingleLegIncome = function (userID) {
        return $http({
            method: 'GET',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: "/SingleLegIncome/GetSingleLegIncome?userID=" + userID
        });
    }

    // get Level income
    rm.getLevelIncome = function (userId) {
        return $http({
            method: 'GET',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            url: "/LevelIncome/GetLevelIncome?userId=" + userId
        });
    }

}])