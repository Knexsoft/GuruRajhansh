﻿app.controller("ctrRegistration", ['$scope', '$window', 'UserServices', function ($scope, $window, UserServices) {
    var oUser = {};
    $scope.Genders = [{
        Text: '--Select--',
        Value: null,
        Selected: true
    }, {
        Text: 'Male',
        Value: 'Male',
        Selected: false

    }, {
        Text: 'Female',
        Value: 'Female',
        Selected: false
    }];

    $scope.register = function () {
        $scope.$parent.Preloader = true;
        var _user = $scope.User;
        oUser = {
            ParentSponserID: _user.ParentSponserID,
            FirstName: _user.FirstName,
            LastName: _user.LastName,
            MobileNumber: _user.MobileNumber,
            EmailID: _user.EmailID,
            Gender: _user.Gender,
            City: _user.City,
            Password: _user.Password,
            ConfirmPassword: _user.ConfirmPassword
        };
        UserServices.CreateNewUser(oUser).then(function (response) {
            $scope.$parent.Preloader = false;
            $scope.User = null;
            $window.location.href = '/user/welcome';
        }, function (error) {
            $scope.$parent.Preloader = false;
        });
    }
}]);