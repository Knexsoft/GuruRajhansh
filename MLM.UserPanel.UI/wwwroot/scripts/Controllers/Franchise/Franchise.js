app.controller("ctrFranchise", ['$scope', 'UserServices', function ($scope, UserServices) {
    var oFranchise = {};
    $scope.Pins = {};

    $scope.getFranchiseIncomeType = function () {
        $scope.$parent.Preloader = true;
        UserServices.GetFranchiseIncomeTypes().then(function (response) {
            $scope.$parent.Preloader = false;
            if (response.data != null) {
                $scope.Pins = response.data;
            }
        }, function (error) {
            $scope.$parent.Preloader = false;
        });
    }

    $scope.addFranchise = function () {
        var _addFranchise = $scope.FranchiseIncomeReq;
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            oFranchise = {
                Pins: _addFranchise.Pins,
                FreePins: _addFranchise.FreePins,
                Amount: _addFranchise.Amount,
                FrenchiseIncomeTypeID: _addFranchise.FranchiseIncomeTypeID,
                UserID: oUser.userID
            };
            UserServices.AddNewFranchise(oFranchise).then(function (response) {
                $scope.$parent.Preloader = false;
                $scope.FranchiseIncomeReq = null;
            }, function (error) {
                $scope.$parent.Preloader = false;
            });
        }
    }

    $scope.changeItem = function (pin) {
        $scope.$parent.Preloader = true;
        UserServices.FranchiseDetail(pin).then(function (response) {
            $scope.$parent.Preloader = false;
            if (response.data != null) {
                $scope.FranchiseIncomeReq.FreePins = response.data.freePins;
                $scope.FranchiseIncomeReq.Amount = response.data.amount;
                $scope.FranchiseIncomeReq.FranchiseIncomeTypeID = response.data.frenchiseIncomeTypeID;
            }
        },
        function (error) {
            $scope.$parent.Preloader = false;
            console.log(JSON.stringify(error));
        });
    }

}]);