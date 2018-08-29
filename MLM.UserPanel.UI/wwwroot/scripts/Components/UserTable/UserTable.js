
app.component('userTable', {
    bindings: {},
    templateUrl: 'scripts/Components/UserTable/userTable.html',
    controllerAs: 'vm',
    controller: ['$scope', 'UserService', function ($scope, UserService) {
        var vm = this;
        if (('localStorage' in $window) && $window['localStorage'] !== null)
        {

        }
        let sponserId;
        if ($localStorage.getItem('user')) {
            sponserId = JSON.parse($localStorage.getItem('user'));
        } else {
            sponserId = 0;
        }
        UserService.GetAllUserBySponserID(sponserId).then(function (response) {
            if (response.data != null) {
                $scope.data = response.data;
            }
        }, function (error) {
            alert(error);
        });

        $scope.dataTableOpt = {
            //custom datatable options 
            // or load data through ajax call also
            "aLengthMenu": [[10, 50, 100, -1], [10, 50, 100, 'All']],
        };
    }]
});
