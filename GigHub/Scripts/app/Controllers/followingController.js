var FollowingController = function (followingService) {

    var button;

    var init = function () {
        $(".js-toggle-follow").click(toggleFollow);
    };

    var toggleFollow = function (e) {
        button = $(e.target);
        var followeeId = button.attr("data-user-id");

        if (button.hasClass("btn-info")) {
            followingService.createFollowing(followeeId, toggleButton, failApiCall); 
        }
        else {
            followingService.deleteFollowing(followeeId, toggleButton, failApiCall); 
        }
    };

    var toggleButton = function () {
        var text = (button.text() === "Following") ? "Follow" : "Following";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    }

    var failApiCall = function () {
        alert("stg fl");
    };

    return {
        init: init
    }
}(FollowingService);