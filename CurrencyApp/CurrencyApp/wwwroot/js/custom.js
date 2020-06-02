$(document).ready(function () {

        
        $("#from-data,#to-data").change(function () {
            var fromCurrency = $("#from-data").val();
            var toCurrency = $("#to-data").val()
           
            if (fromCurrency && toCurrency) {
                $.ajax({
                    type: 'POST',
                    url: '/Calculator/getCurrencyRate',
                    data: {
                        'fromCurrency': fromCurrency,
                        'toCurrency': toCurrency
                    },
                    dataType: 'json',
                    success: function (data) {
                        $("#rate-holder").val(data);
                        var buy = $("#buy").val();
                        var sell = $("#sell").val();
                        if (buy == "0,00" && sell == "0,00") {
                            $("#buy").val("0,00");
                            $("#sell").val("0,00");
                        }else if (buy != "0,00") {
                            $("#sell").val(calculateAmount(buy, 0));
                        } else if (sell != "0,00") {
                            $("#buy").val(calculateAmount(sell, 1));
                        } 
                    },
                    error: function () {
                        alert("error while inserting data!");
                    }
                });
            }
        });

    $("#sell").change(function () {
        var sell = $("#sell").val();
        $("#buy").val(calculateAmount(sell, 1));
    });

    $("#buy").change(function () {
        var buy = $("#buy").val();
        $("#sell").val(calculateAmount(buy, 0));
    });

    function calculateAmount(amount, mult) {
        var rate = $("#rate-holder").val();
        var result = 0;

        var fromCurrency = $("#from-data").val();
        var toCurrency = $("#to-data").val()
        if (fromCurrency && toCurrency) {
            if (mult == 1) {
                result = amount * rate;
            } else {
                result = amount / rate;
            }
        }
        return result;
    }

    $("#dis").click(function () {
        alert("heeeeererereASdsad");

        var fromCurrency = $("#from-data").val();
        var toCurrency = $("#to-data").val()
        var sell = $("#sell").val();
        var buy = $("#buy").val();

        if (fromCurrency && toCurrency && sell != "0,00" && buy != "0,00") {
            $.ajax({
                type: 'POST',
                url: '/Calculator/convert',
                data: {
                    'fromCurrency': fromCurrency,
                    'toCurrency': toCurrency,
                    'sell': sell,
                    'buy': buy
                },
                dataType: 'json'
            });
        }
    });
});