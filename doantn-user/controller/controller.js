
app.controller('myCtrl', function ($scope, $http) {
    $scope.Message = "Hello To AngularJS QuickStart";
    $http({
        method: "GET",
        url: "https://doantotnghiephutech.azurewebsites.net/api/Posts"
    }).then(function mySuccess(response) {
        $scope.favourited = true;
       $scope.records=response.data;
    }, function myError(response) {
        $scope.myWelcome = response.statusText;
    });
});