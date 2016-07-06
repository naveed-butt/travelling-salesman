$(document).ready(function () {
    bindClicks();
    preloadImages();
    calculateAll();
});

// Binds the calculate buttons to their respective function
function bindClicks() {
    $('#calculate-distance').click(calculateDistance);
    $('#calculate-available').click(calculateAvailable);
    $('#calculate-shortest').click(calculateShortest);
}

// Preload the loading image so it doesn't take time before showing it up
function preloadImages() {
    new Image().src = '../Images/loading.gif';
}

// Request all calculations (used on page load)
function calculateAll() {
    calculateDistance();
    calculateAvailable();
    calculateShortest();
}

// Do the request of calculating the total distance
function calculateDistance() {
    var graph = $('#graph').val();
    var path = $('#distance-path').val();

    var $answer = $('#distance-answer');
    var url = '../api/' + graph + '/TotalDistance';
    var params = {
        path: path
    };

    doRequest(url, params, $answer);
}

// Do the request of listing the available routes
function calculateAvailable() {
    var graph = $('#graph').val();
    var origin = $('#available-origin').val();
    var destiny = $('#available-destiny').val();
    var maxStops = $('#available-maxstops').val();

    var $answer = $('#available-answer');
    var url = '../api/' + graph + '/AvailableRoute';
    var params = {
        origin: origin,
        destiny: destiny,
        maxStops: maxStops
    };

    doRequest(url, params, $answer);
}

// Do the request of finding the shortest route
function calculateShortest() {
    var graph = $('#graph').val();
    var origin = $('#shortest-origin').val();
    var destiny = $('#shortest-destiny').val();

    var $answer = $('#shortest-answer');
    var url = '../api/' + graph + '/ShortestRoute';
    var params = {
        origin: origin,
        destiny: destiny
    };

    doRequest(url, params, $answer);
}

// Common request function used by all calculations
function doRequest(url, params, $answer) {
    $answer.html('<img alt="loading..." src="../Images/loading.gif" />');

    var start = Date.now();

    // Making sure the request takes a while so the 'loading' image doesn't 'blink' on screen
    var toWait = 1500;

    $.getJSON(url, params)
        .always(function () {
            var elapsed = Date.now() - start;
            toWait -= elapsed;
        })
        .done(function (data) {
            setTimeout(function () {
                if ($.isArray(data)) {
                    $answer.html(formatArray(data));
                } else {
                    $answer.text(data);
                }
            }, toWait);
        })
        .fail(function (data) {
            setTimeout(function () {
                $answer.text('n/a');
                ajaxError(data);
            }, toWait);
        });
}

// Request error handling
function ajaxError(data) {
    if (data.responseText) {
        var response = JSON.parse(data.responseText);
        if (response.ExceptionMessage && response.ExceptionType) {
            if (response.ExceptionType.indexOf('CSharpRemoteChallenge.Domain.Exceptions') === 0) {
                // When a domain exception happens displays it to the user
                alert(response.ExceptionMessage);
                return;
            } else {
                // If it is other kind of exception, logs it in the console
                console.error('Exception: ' + response.ExceptionType + '\nException Message: ' + response.ExceptionMessage);
            }
        } else {
            // If the response is not in the exception format, logs the response object to console
            console.dir(response);
        }
    } else {
        // If there is no response at all, logs the whole ajax return to the console
        console.dir(data);
    }
    alert('An error has occurred... sorry about that. Further information on browser console.');
}

// Formats an array to a <li> list for displaying on page
function formatArray(array) {
    var list = '';
    if (array.length) {
        $.each(array, function (i, value) {
            list += '<li>' + value + '</li>';
        });
    } else {
        list = '<li>none</li>';
    }
    return list;
}