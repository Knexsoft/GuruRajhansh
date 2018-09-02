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
                FirstName: $scope.FirstName,
                LastName: $scope.LastName,
                EmailID: $scope.EmailID,
                Gender: $scope.Gender,
                City: $scope.City
            };
            UserServices.UpdateUserProfile(oUser).then(function (response) {
                $scope.$parent.Preloader = false;
                window.location.reload(true);
                alert('Profile Updated Successfully !');
            }, function (error) {
                $scope.$parent.Preloader = false;
            });
        }
    }

    $scope.ViewProfile = function () {
        $scope.$parent.Preloader = true;
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            var userID = oUser.userID;
            UserServices.GetUserProfile(userID).then(function (response) {
                if (response.data != null) {
                    $scope.SponserID = response.data.sponserID;
                    $scope.ParentSponserID = response.data.parentSponserID;
                    $scope.FirstName = response.data.firstName;
                    $scope.LastName = response.data.lastName;
                    $scope.MobileNumber = response.data.mobileNumber;
                    $scope.EmailID = response.data.emailID;
                    $scope.Gender = response.data.gender;
                    $scope.City = response.data.city;
                }
            },
                function (error) {
                    alert(error);
                });
        }
    }
}]);