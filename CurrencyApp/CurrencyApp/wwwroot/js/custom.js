$(document).ready(function () {

        
        $("#from-data,#to-data").change(function () {
            var data = {};
            data.fromCurrency = $("#from-data").val();
            data.toCurrency = $("#to-data").val();
           
            if (data.fromCurrency && data.toCurrency) {
                $.ajax({
                    type: "POST",
                    url: "/Calculator/Rate",
                    data: '{data: ' + JSON.stringify(data) + '}',
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        $("#rate-holder").val(data);
                    },
                    error: function () {
                        alert("error while inserting data!");
                    }
                });
            }
        });

});