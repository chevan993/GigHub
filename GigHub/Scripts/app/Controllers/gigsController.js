var GigsController = function (attendanceService) {
    var button;

    var init = function (container) {
        $(container).on("click", ".js-toggle-attendance", toggleAttendance);
    };


    var toggleAttendance = function (e) {
        button = $(e.target);
        var gigId = button.attr("data-gig-id");

        if (button.hasClass("btn-info")) {
            attendanceService.createAttendance(gigId, toggleBtn, failApiCall);
        }
        else {
            attendanceService.deleteAttendance(gigId, toggleBtn, failApiCall);
        }
    };

    var toggleBtn = function () {
        var text = (button.text() == "Going?") ? "Attending" : "Going?";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    var failApiCall = function () {
        alert("Something failed!");
    };

    return {
        init: init
    }

}(AttendanceService);