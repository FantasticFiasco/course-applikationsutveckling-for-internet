﻿$(document).ready(function() {
    // Enable subscriber controls when radio button is selected
    $("#subscriberradio").change(function() {
        $("#subscriptionnumbertext").prop("disabled", false);
        $("#subscriptionnumberbutton").prop("disabled", false);
    });

    // Disable subscriber controls when radio button is unselected
    $("#companyradio").change(function() {
        $("#subscriptionnumbertext").prop("disabled", true);
        $("#subscriptionnumberbutton").prop("disabled", true);
    });
});