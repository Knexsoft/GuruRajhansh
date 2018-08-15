app.controller("ctrRegistration", function ($scope, $http) {
    var oUser = {};

    $scope.register = function () {
        var _user = $scope.User;
        User = {
            ParentSponserID = getUrlParameter('sponserid'),
            
        }
    }

    function getUrlParameter(param, dummyPath) {
        var sPageURL = dummyPath || window.location.search.substring(1),
            sURLVariables = sPageURL.split(/[&||?]/),
            res;

        for (var i = 0; i < sURLVariables.length; i += 1) {
            var paramName = sURLVariables[i],
                sParameterName = (paramName || '').split('=');

            if (sParameterName[0] === param) {
                res = sParameterName[1];
            }
        }

        return res;
    }
});