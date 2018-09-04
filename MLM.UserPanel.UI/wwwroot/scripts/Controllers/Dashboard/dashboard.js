app.controller("ctrDashboard", ["$scope", "$window", "UserServices", function ($scope, $window, UserServices) {

    $scope.GetTeamInfo = function () {
        debugger;
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            UserServices.GetTeamInfoBySponserID(oUser.sponserID).then(function (response) {
                if (response.data != null) {
                    $scope.ActiveUsers = response.data.activeUsers;
                    $scope.UnactiveUsers = response.data.deactiveUsers;
                    $scope.TotalIncome = response.data.totalAmount;
                }
            }, function (error) {
                alert(error);
            });
        }
    }
}]);