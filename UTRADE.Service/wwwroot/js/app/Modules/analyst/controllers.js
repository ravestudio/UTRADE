angular.module('TradeApp.Module.Controllers', []).controller('AnalystController', function($scope,$http)
{



    var url = '/analyst/GetDecisions/';

    $http.get(url).then(function (resp) {
        $scope.data = resp.data;
    });



});