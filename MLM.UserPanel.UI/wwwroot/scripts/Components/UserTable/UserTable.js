
app.component('userTable', {
    bindings: {},
    templateUrl: 'scripts/Components/UserTable/userTable.html',
    controllerAs: 'vm',
    controller: ['$scope', '$window', 'UserServices', function ($scope, $window, UserServices) {
        var vm = this;
        $scope.Users = {};
        $scope.userRole = "";
        let sponserID = 0;
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            this.sponserID = oUser.sponserID;
            UserServices.GetAllUserBySponserID(this.sponserID).then(function (response) {
                if (response.data != null) {
                    $scope.Users = response.data;
                    $scope.userRole = oUser.userRole;
                }
            },
                function (error) {
                    alert(error);
                });
        }

        $scope.dataTableOpt = {
            //custom datatable options 
            // or load data through ajax call also
            "aLengthMenu": [[10, 50, 100, -1], [10, 50, 100, 'All']],
        };

        $scope.GenratePin = function (User) {
            UserServices.GenrateUserPinByUserID(User.userID).then(function (response) {
                if (response.status == 200) {
                    $window.location.reload();
                }
            }, function (error) {
                alert(error);
            });
        }
    }]
});
