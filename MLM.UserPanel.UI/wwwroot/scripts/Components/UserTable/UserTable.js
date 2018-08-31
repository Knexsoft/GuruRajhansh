
app.component('userTable', {
    bindings: {},
    templateUrl: 'scripts/Components/UserTable/userTable.html',
    controllerAs: 'vm',
    controller: ['$scope', 'UserServices', function ($scope, UserServices) {
        var vm = this;
        $scope.data = null;
        $scope.userInRole = null;
        let sponserID = 0;
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            this.sponserID = oUser.sponserID;
            UserServices.GetAllUserBySponserID(this.sponserID).then(function (response) {
                if (response.data != null) {
                    $scope.data = response.data;
                    $scope.userInRole = oUser.userRole;
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
    }]
});
