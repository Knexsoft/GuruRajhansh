app.controller("ctrUserProfile", ['$scope', 'UserServices', function ($scope, UserServices) {
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

    $scope.updateUserProfile = function () {
        $scope.$parent.Preloader = true;
        var _user = $scope.UserProfile;
        
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            oUser = {
                UserID: oUser.userID,
                FirstName: _user.FirstName,
                LastName: _user.LastName,
                MobileNumber: _user.MobileNumber,
                EmailID: _user.EmailID,
                Gender: _user.Gender,
                City: _user.City,
            };

            UserServices.UpdateUserProfile(oUser).then(function (response) {
                $scope.$parent.Preloader = false;
                $scope.UserProfile = null;
            }, function (error) {
                $scope.$parent.Preloader = false;
            });
        }
    }

    $scope.ViewProfile = function () {
        debugger;
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            this.userID = oUser.userID;
            UserServices.GetUserProfile(this.userID).then(function (response) {
                if (response.data != null) {
                    alert(JSON.stringify(response.data));
                    $scope.data = response.data;
                    UserProfile.SponserID = response.data.SponserID;
                    UserProfile.ParentSponserID = response.data.ParentSponserID;
                    UserProfile.FirstName = response.data.FirstName;
                    UserProfile.LastName = response.data.LastName;
                    UserProfile.MobileNumber = response.data.MobileNumber;
                    UserProfile.EmailID = response.data.EmailID;
                    UserProfile.Gender = response.data.Gender;
                    UserProfile.City = response.data.City;
                }
            },
                function (error) {
                    alert(error);
                });
        }
    }
}]);