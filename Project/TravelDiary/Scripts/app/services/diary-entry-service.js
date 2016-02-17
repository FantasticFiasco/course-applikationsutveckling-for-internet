app.factory("diaryEntryService", ["$http", function($http) {
    var instance = {};

    instance.getLatestEntry = function () {
        return $http.get("api/diaryentry");
    };

    instance.getEntry = function(id) {
        return $http.get("api/diaryentry/" + id);
    }

    return instance;
}]);