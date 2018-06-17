$(function () {

    var band1Ctrl = $("select[name='band1Color']");
    var band2Ctrl = $("select[name='band2Color']");
    var band3Ctrl = $("select[name='band3Color']");
    var toleranceBandCtrl = $("select[name='toleranceBandColor']");

    // display elements
    var readout = $("#readout span.value");
    var minReadout = $("#readout span.min-value");
    var maxReadout = $("#readout span.max-value");

    var band1 = $("#band1");
    var band2 = $("#band2");
    var band3 = $("#band3");
    var toleranceBand = $("#tolerance-band");

    var errorContainer = $("#error-message-container");
    var error = $("#error-message");

    function calculateMin(value, tolerance) {
        return Math.round((1 - tolerance) * value * 1000) / 1000;
    }

    function calculateMax(value, tolerance) {
        return Math.round((1 + tolerance) * value * 1000) / 1000;
    }

    function updateResultDisplay(result, min, max) {
        readout.html(result + "&#8486");
        minReadout.html(min);
        maxReadout.html(max);

        band1.css('background-color', band1Ctrl.val());
        band2.css('background-color', band2Ctrl.val());
        band3.css('background-color', band3Ctrl.val());
        toleranceBand.css('background-color', toleranceBandCtrl.val());
    }

    function showErrorMessage(message) {
        error.html(message);
        errorContainer.removeClass('hidden');
    }

    function clearErrorMessage() {
        errorContainer.addClass('hidden');
        error.html('');
    }

    function disableCalculateButton() {
        $("button#calculate").attr('disabled', true);
    }

    function enableCalculateButton() {
        $("button#calculate").removeAttr('disabled');
    }

    function updateControlLocks() {
        // if band 2 is blank, disable band 3
        var band2 = band2Ctrl.val();
        var band3 = band2Ctrl.val();

        if (band2.length > 0) {
            // unlock band3
            band3Ctrl.removeAttr('disabled');
        }
        else {
            band3Ctrl.val('');
            band3Ctrl.attr('disabled', true);
        }
    }

    function resetDisplay() {
        band1.css('background-color', '');
        band2.css('background-color', '');
        band3.css('background-color', '');
        toleranceBand.css('background-color', '');
        readout.html("------------&#8486");
        minReadout.html("");
        maxReadout.html("");
    }

    function sendCalculationRequest() {
        disableCalculateButton();

        $.ajax({
            type: 'POST',
            url: 'CalculateOhmValue',
            dataType: 'json',
            data: {
                band1Color: band1Ctrl.val(),
                band2Color: band2Ctrl.val(),
                band3Color: band3Ctrl.val(),
                toleranceBandColor: $("select[name='toleranceBandColor']").val()
            },
            success: function (data) {
                console.log("got data:", data);
                var calcSucceeded = data.success;

                if (calcSucceeded) {
                    var result = Math.round(data.result * 1000) / 1000;
                    var min = calculateMin(data.result, data.tolerance);
                    var max = calculateMax(data.result, data.tolerance);
                    updateResultDisplay(result, min, max);

                }
                else {
                    // application error
                    showErrorMessage(data.message);
                }
                enableCalculateButton();
            },
            error: function (error) {
                showErrorMessage(error);
            }
        });
    }

    // setup calcuation handler
    $("button#calculate").click(sendCalculationRequest);
    $("select[name='band2Color']").change(updateControlLocks);
    $("select[name='band3Color']").change(updateControlLocks);
    $("select[name^='band']").change(resetDisplay);
    $("select[name^='toleranceBandColor']").change(resetDisplay);

    // initialize control state
    updateControlLocks();
    clearErrorMessage();
});
