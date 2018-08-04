var FollowingService = function () {

    var createFollowing = function (followeeId, done, fail) {
        console.log("I'm in post");
        $.post("/api/followings", { followeeId: followeeId })
            .done(done)
            .fail(fail);
    };

    var deleteFollowing = function (followeeId, done, fail) {
        console.log("I'm in delete");
        $.ajax({
            url: "/api/followings/" + followeeId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    return {
        createFollowing: createFollowing,
        deleteFollowing: deleteFollowing
    }

}();