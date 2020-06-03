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

                        
                        if (parseFloat(buy) != 0 && parseFloat(sell) != 0) {
                                $("#buy").val(0);
                                $("#sell").val(0);
                        } else if(parseFloat(buy) != 0) {
                                var res = "" + calculateAmount(buy, 0);
                                $("#sell").val(res);
                        } else if (parseFloat(sell) != 0) {
                                var res = "" + calculateAmount(sell, 1);
                                $("#buy").val(res);
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
        var res = "" + calculateAmount(sell, 1);
        $("#buy").val(res);
    });

    $("#comment-holder").change(function () {
        var fromCurrency = $("#from-data").val();
        var toCurrency = $("#to-data").val()
        var buy = $("#buy").val();
        var sell = $("#sell").val();
        var comment = $("#comment-holder").val();

        if (parseFloat(buy) != 0 && parseFloat(sell) != 0 && fromCurrency && toCurrency && comment != "") {
            document.getElementById("dis").disabled = false;
        }
    });

    $("#buy").change(function () {
        var buy = $("#buy").val();
        var res = "" + calculateAmount(buy, 0);
        $("#sell").val(res);
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
        if (result != 0) {
            var am = checkAmount(amount);
            if (parseFloat(am) < 3000 || $("#comment-holder").val() != "") {
                document.getElementById("dis").disabled = false;
            } else {
                document.getElementById("dis").disabled = true;
            }
        }
        return result;
    }

    function checkAmount(amount) {
        var fromCurrency = $("#from-data").val();
        var result = 0;
        $.ajax({
            type: 'POST',
            url: '/Calculator/getRateToGel',
            data: {
                'fromCurrency': fromCurrency
            },
            dataType: 'json',
            async: false,
            success: function (data) {
                result = parseFloat(amount) * data.rate;
                callback(result);
            },
            error: function () {
                alert("error while inserting data!");
            }
        });
        return result;
    }
});