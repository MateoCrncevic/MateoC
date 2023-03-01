
    function showStavkaPartialView(id) {
            var url = "/Customer/ShowStavke/"; 
            $.get(url, {id: id })              
                .done(function (response) {
        $("#getBillStavke").html(response);
                });
        }

