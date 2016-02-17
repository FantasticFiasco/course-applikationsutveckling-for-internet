app.controller("DiaryEntryController", ["$scope", "diaryEntryService", function ($scope, diaryEntryService) {

    diaryEntryService.getLatestEntry()
        .success(function(data) {
            $scope.entry = data;
        });
    
}]);