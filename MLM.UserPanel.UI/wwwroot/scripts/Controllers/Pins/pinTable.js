app.component('pinTable', {
    bindings: {},
    templateUrl: 'scripts/Controllers/Pins/pinTable.html',
    controllerAs: 'vm',
    controller: ['$scope', 'UserServices', function ($scope, UserServices) {
        var vm = this;
        $scope.data = null;
        let userID = 0;
        if (localStorage.getItem("user") != null) {
            var oUser = JSON.parse(localStorage.getItem('user'));
            this.userID = oUser.userID;
            UserServices.GetPinsDetailByUserID(this.userID).then(function (response) {
                if (response.data != null) {
                    $scope.data = response.data;
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