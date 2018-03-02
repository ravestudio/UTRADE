angular.module('TradeApp.Charts.Controllers', []).controller('ChartController', function($scope)
{
    $scope.securities = [{
        id: 'GMKN',
        desc: 'Norilsk Nickel'
    }, {
        id: 'LKOH',
        desc: 'Lukoil'
    }, {
        id: 'NLMK',
        desc: 'NLMK'
    }];

    $scope.security = "GMKN";

    $scope.$watch('security', function (newValue, oldValue) {

        var url = '/chart/getData/?security='+newValue;

        $.getJSON(url, function (data) {

            chart.update({

                series: [{
                    name: 'AAPL',
                    type: 'candlestick',
                    data: data,
                    tooltip: {
                        valueDecimals: 2
                    }
                }]

            });

            //chart.series[0].setData(data);

        });
    });

});