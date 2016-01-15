$(document).ready(function () {

    function showSubscriber() {
        $("#subscriptionnumbertext").prop("disabled", false);
        $("#subscriptionnumberbutton").prop("disabled", false);
        $("#subscriberinput").show();
        $("#companyinput").hide();
    }

    function showCompany() {
        $("#subscriptionnumbertext").prop("disabled", true);
        $("#subscriptionnumberbutton").prop("disabled", true);
        $("#subscriberinput").hide();
        $("#companyinput").show();
    }

    // Enable subscriber controls when radio button is selected
    $("#subscriberradio").change(showSubscriber);

    // Disable subscriber controls when radio button is unselected
    $("#companyradio").change(showCompany);

    if ($("#subscriberradio").is(":visible") && $("#companyradio").is(":visible")) {
        showSubscriber();
    }
});