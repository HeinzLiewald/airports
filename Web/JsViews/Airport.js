updateAirportsList = function (successCallback) {
    successCallback = successCallback || function () { }

    ajaxDispatcher(
        'Airport/GetAirports',
        {},
        function (data, textStatus, response) {
            if (data.success) {
                var fromFeed = response.getResponseHeader("from-feed");
                if (fromFeed != null) {
                    $("#from-feed").val(fromFeed);
                }

                $("#filter-airport").replaceWith(data.FilterAirport);
                $("#list-airports").replaceWith(data.ListAirports);

                successCallback();
            } else {
                console.error(data.msg);
            }
        });
}

mustUpdateFeed = function () {
    var fromFeed = $("#from-feed").val();
    if (typeof fromFeed != "undefined" && fromFeed !== null && fromFeed !== '') {
        var fromFeedDate = new Date(fromFeed);
        var fiveMinutesAgo = new Date(new Date() - 5 * 60000);
        return fromFeedDate < fiveMinutesAgo;
    } else {
        return false;
    }
}

filterList = function (selectElement) {
    function filterFunction() {
        var airportIso = selectElement.options[selectElement.selectedIndex].value;
        if (typeof airportIso == "undefined" || airportIso === null || airportIso === '') {
            $(".airport-row").show();
        } else {
            $(".airport-row").hide();
            $(`*[data-iso="${airportIso}"]`).show();
        }
    }

    if (mustUpdateFeed()) {
        updateAirportsList(filterFunction);
        console.log("Airports list updated from feed.")
    } else {
        filterFunction();
    }
}

load = function () {
    updateAirportsList();
}

$(load);
