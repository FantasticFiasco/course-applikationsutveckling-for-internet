app.controller("DiaryEntryController", ["$scope", "diaryEntryService", function ($scope, diaryEntryService) {

    diaryEntryService.getLatestEntry()
        .success(function(data) {
            $scope.entry = data;
        });

    $scope.getEntry = function(id) {
        diaryEntryService.getEntry(id)
            .success(function (data) {
                $scope.entry = data;
        });
    };

}]);