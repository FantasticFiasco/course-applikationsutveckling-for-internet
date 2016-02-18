var app = angular.module("TravelDiaryApp", ['ngSanitize', 'ngMap'])

    .factory("diaryEntryService", function ($http) {
        var instance = {};

        instance.getLatestEntry = function () {
            return $http.get("api/diaryentry");
        };

        instance.getEntry = function (id) {
            return $http.get("api/diaryentry/" + id);
        }

        return instance;
    })

    .controller("DiaryEntryController", function ($scope, diaryEntryService) {

        diaryEntryService.getLatestEntry()
            .success(function (data) {
                $scope.entry = data;
            });

        $scope.getEntry = function (id) {
            diaryEntryService.getEntry(id)
                .success(function (data) {
                    $scope.entry = data;
                });
        };
    })

    .directive("diaryEntryText", function () {
        return {
            restrict: "E",
            templateUrl: "Scripts/app/diary-entry-text.html"
        };
    });