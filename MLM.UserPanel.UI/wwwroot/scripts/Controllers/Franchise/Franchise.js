app.controller("ctrFranchise", ['$scope', 'UserServices', function ($scope, UserServices) {
    var oFranchise = {};
    $scope.Pins = {};
    $scope.data = {};
    $scope.franchises = {};

    $scope.franchiseIncomeTypesList = function () {
        $scope.$parent.Preloader = true;
        UserServices.FranchiseIncomeTypesList().then(function (response) {
            $scope.$parent.Preloader = false;
            if (response.data != null) {
                $scope.Pins = response.data;
            }
        }, function (error) {
            $scope.$parent.Preloader = false;
        });
    }

    $scope.getFranchiseIncomeType = function () {
        $scope.$parent.Preloader = true;
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            UserServices.GetFranchiseIncomeTypes(oUser.userID).then(function (response) {
                $scope.$parent.Preloader = false;
                if (response.data != null) {
                    $scope.data = response.data;
                }
            }, function (error) {
                $scope.$parent.Preloader = false;
            });
        }
    }

    // pin list by frenchise Id
    $scope.getPinListByFrenchiseID = function () {
        $scope.$parent.Preloader = true;
        var _queryString = location.search;
        var _id = _queryString.split('=')[1];
        UserServices.GetPinListByFrenchiseID(_id).then(function (response) {
            $scope.$parent.Preloader = false;
            if (response.data != null) {
                $scope.franchises = response.data;
            }
        }, function (error) {
            $scope.$parent.Preloader = false;
        });
    }

    $scope.addFranchise = function () {
        $scope.$parent.Preloader = true;
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