
app.controller('myCtrl', function ($scope, $http) {
    $http({
        method: "GET",
        url: "https://doantotnghiephutech.azurewebsites.net/api/Posts/Header"
    }).then(function mySuccess(response) {
        $scope.favourited = true;
        $scope.records = response.data;
            
    }, function myError(response) {
        $scope.myWelcome = response.statusText;
    });
  
    $scope.login = function (userName, passWord) {
        
        model = {
            Email: $scope.userName,
            Password: $scope.passWord,
            RememberMe:true,
        }
        $http({
            method: "POST",
            url: "https://doantotnghiephutech.azurewebsites.net/api/Test",
            data: model,
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(function mySuccess(response) {
            console.log(response);
        }, function myError(response) {
            $scope.myWelcome = response.statusText;
        });
    };
});
app.config(function ($httpProvider) {
    $httpProvider.defaults.headers.common = {};
    $httpProvider.defaults.headers.post = {};
    $httpProvider.defaults.headers.put = {};
    $httpProvider.defaults.headers.patch = {};
});