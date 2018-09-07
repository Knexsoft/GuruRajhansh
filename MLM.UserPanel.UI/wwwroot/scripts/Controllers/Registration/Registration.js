app.controller("ctrRegistration", ['$scope', 'UserServices', function ($scope, UserServices) {
    var oUser = {};
    $scope.eml_add = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/;
    var _flag = true;
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
            window.location.href = 'user/Welcome';
        }, function (error) {
            $scope.$parent.Preloader = false;
        });
    }

    
    $scope.getParentSponserInfo = function () {
        $scope.$parent.Preloader = true;
        var _sponserID = $scope.User.ParentSponserID == null ? '' : $scope.User.ParentSponserID;
        if (_sponserID.length >= 6 && _sponserID != null) {
            UserServices.GetParentInfoBySponserID(_sponserID).then(function (response) {
                $scope.$parent.Preloader = false;
                if (response.data != null) {
                    var _fname = response.data == '' ? '' : response.data.firstName;
                    var _lname = response.data == '' ? '' : response.data.lastName;
                    $scope.User.SponserBy = _fname + ' ' + _lname;
                    $scope.isReadOnly();
                }
            }, function (error) {
                $scope.$parent.Preloader = false;
            });
        }
        $scope.$parent.Preloader = false;
    }

    $scope.isReadOnly = function () {
        return $scope._flag;
    }
}]);