var app = angular.module('travelDiaryApp', ['ngSanitize', 'ngMap', 'angularGrid'])
    .factory('diaryEntryService', function ($http) {
        var instance = {};

        instance.getLatestEntry = function () {
            return $http.get('api/diaryentry');
        };

        instance.getEntry = function (id) {
            return $http.get('api/diaryentry/' + id);
        }

        return instance;
    })
    .factory('imageService', function ($http) {
        var instance = [];

        instance.searchFor = function (text) {
            return $http.get('api/photosearch/' + text);
        }

        return instance;
    })
    .controller('DiaryEntryController', function ($scope, diaryEntryService, NgMap, imageService) {

        $scope.getEntry = function (id) {
            diaryEntryService.getEntry(id)
                .success(function (data) {
                    $scope.entry = data;
                    $scope.updateMap();
                    $scope.updateImages();
                });
        };

        $scope.updateMap = function () {
            // Remove current marker
            if ($scope.marker != null) {
                $scope.marker.setMap(null);
            }

            // Add new marker
            var latLng = {
                lat: $scope.entry.destination.latitude,
                lng: $scope.entry.destination.longitude
            };

            $scope.map.setZoom(7);
            $scope.map.setCenter(latLng);

            $scope.marker = new google.maps.Marker({
                position: latLng,
                map: $scope.map,
                title: $scope.entry.destination.name
            });
        }

        $scope.updateImages = function() {
            imageService.searchFor($scope.entry.destination.name)
                .success(function (images) {
                    $scope.images = images;
            });
        };

        diaryEntryService.getLatestEntry()
            .success(function (data) {
                $scope.entry = data;
            })
            .then(function () {
                return NgMap.getMap();
            })
            .then(function (map) {
                $scope.map = map;
                $scope.updateMap();
                $scope.updateImages();
            });
    })
    .directive('diaryEntryText', function () {
        return {
            restrict: 'E',
            templateUrl: 'Scripts/app/diary-entry-text.html'
        };
    });