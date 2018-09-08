app.controller("ctrPin", ['$scope', 'UserServices', function ($scope, UserServices) {
    $scope.ActivatePin = function () {
        $scope.$parent.Preloader = true;
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            var userID = oUser.userID;
            var _pin = $scope.pin;
            UserServices.ActivateAccountPin(_pin, userID).then(function (response) {
                
                if (response.status == 200) {
                    window.location.href = '/dashboard/Index';
                    alert('Your account is successfully activated !');
                    $scope._userpin = this._pin;
                }
            },
                function (error) {
                    if (error.status == 400) {
                        alert('Entered pin is not exist. Enter connect pin !');
                    }
                });
        }
    }
}]);