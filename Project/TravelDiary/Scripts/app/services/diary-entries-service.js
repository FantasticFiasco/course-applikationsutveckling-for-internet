app.factory("diaryEntriesService", ["$http", function($http) {
    var instance = {};

    instance.getDiaryEntries = function () {
        return $http.get("api/diaryentries");
    };

    return instance;
}]);