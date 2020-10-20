$(function () {
    $("input[type=radio][name=rateMode]").change(function () {
        if (this.value === "0") {
            $("#creditStepContainer").css('display', 'none');
            $("#termInfo").text("в месяцах");
            $("#rateInfo").text("в год");
        }
        else {
            $("#creditStepContainer").css('display', 'flex');
            $("#termInfo").text("в днях");
            $("#rateInfo").text("в день");
        }
    });
});