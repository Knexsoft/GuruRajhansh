app.controller("ctrLevelIncome", ['$scope', 'IncomeServices', function ($scope, IncomeServices) {
    $scope._levelIncome = {};

    $scope.getLevelIncome = function () {
        $scope.$parent.Preloader = true;
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            var userID = oUser.userID;
            IncomeServices.getLevelIncome(userID).then(function (response) {
                if (response.data != null) {
                    $scope._levelIncome = response.data;
                }
            },
            function (error) {
                alert(JSON.stringify(error));
            });
        }
    }
}]);