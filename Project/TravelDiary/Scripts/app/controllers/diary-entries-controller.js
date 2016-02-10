app.controller("DiaryEntriesController", ["$scope", "diaryEntriesService", function ($scope, diaryEntriesService) {

    $scope.diaryEntries = {};

    diaryEntriesService.getDiaryEntries()
        .success(function(data) {
            $scope.diaryEntries = data;
        });
    
}]);