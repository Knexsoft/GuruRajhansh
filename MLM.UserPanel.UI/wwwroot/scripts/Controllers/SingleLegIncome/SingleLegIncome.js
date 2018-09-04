app.controller("ctrSingleLeg", ['$scope', 'IncomeServices', function ($scope, UserServices) {
    var _singleLeg = {};
    $scope.getSingleLeg = function () {
        $scope.$parent.Preloader = true;
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            var userID = oUser.userID;
            UserServices.getSingleLegIncome(userID).then(function (response) {
                if (response.data != null) {
                    $scope._singleLeg = response.data;
                }
            },
                function (error) {
                    alert(error);
                });
        }
    }
}]);