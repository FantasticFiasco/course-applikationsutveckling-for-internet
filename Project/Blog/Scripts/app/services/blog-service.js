app.factory("blogService", ["$http", function($http) {
    var instance = {};

    instance.getBlogEntries = function () {
        return $http.get("api/blog");
    };

    return instance;
}]);