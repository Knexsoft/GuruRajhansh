app.controller("ctrSingleLeg", ['$scope', 'IncomeServices', function ($scope, IncomeServices) {
    $scope._singleLeg = {};

    $scope.getSingleLeg = function () {
        $scope.$parent.Preloader = true;
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            var userID = oUser.userID;
            IncomeServices.getSingleLegIncome(userID).then(function (response) {
                if (response.data != null) {
                    $scope._singleLeg = response.data;
                }
            },
                function (error) {
                    alert(JSON.stringify(error));
                });
        }
    }
}]);