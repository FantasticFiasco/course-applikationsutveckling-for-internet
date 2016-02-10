app.factory("diaryEntryService", ["$http", function($http) {
    var instance = {};

    instance.getLatestEntry = function () {
        return $http.get("api/diaryentry");
    };

    return instance;
}]);