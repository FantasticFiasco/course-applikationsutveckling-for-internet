app.controller("BlogController", ["$scope", "blogService", function ($scope, blogService) {

    $scope.blogEntries = {};

    blogService.getBlogEntries()
        .success(function(data) {
            $scope.blogEntries = data;
        });
    
}]);