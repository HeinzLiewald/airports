function ajaxDispatcher(controller, data, callback) {
    var canvasLoader;

    try { canvasLoader = new CanvasLoader('heartcode-canvasloader-container'); } catch { }

    if (canvasLoader !== undefined) {
        canvasLoader.show();
    }

    function alwaysCallback() {
        if (typeof canvasLoader !== "undefined") { canvasLoader.hide(); }
    }

    function errorCallback(jqXHR, textStatus, errorThrown) {
        console.warn(textStatus, errorThrown, jqXHR);
        $.ajax({
            type: 'POST',
            url: baseUrl + '/Error/Log',
            data: { textStatus: textStatus, errorThrown: errorThrown, responseText: jqXHR.responseText }
        });
    }

    $.ajax({
        type: 'POST',
        url: baseUrl + '/' + controller,
        data: data
    })
        .done(callback)
        .fail(errorCallback)
        .always(alwaysCallback);
}
