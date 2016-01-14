$(document).ready(function () {

    // Enable subscriber controls when radio button is selected
    $("#subscriberradio").change(function() {
        $("#subscriptionnumbertext").prop("disabled", false);
        $("#subscriptionnumberbutton").prop("disabled", false);
        $("#subscriberinput").show();
        $("#companyinput").hide();
    });

    // Disable subscriber controls when radio button is unselected
    $("#companyradio").change(function() {
        $("#subscriptionnumbertext").prop("disabled", true);
        $("#subscriptionnumberbutton").prop("disabled", true);
        $("#subscriberinput").hide();
        $("#companyinput").show();
    });
});