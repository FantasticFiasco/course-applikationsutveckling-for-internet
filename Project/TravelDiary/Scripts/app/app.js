var app = angular.module('TravelDiaryApp', ['ngSanitize', 'ngMap'])

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

    .controller('DiaryEntryController', function ($scope, diaryEntryService, NgMap) {

        $scope.getEntry = function (id) {
            diaryEntryService.getEntry(id)
                .success(function (data) {
                    $scope.entry = data;
                    $scope.updateMap();
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
            });
    })

    .directive('diaryEntryText', function () {
        return {
            restrict: 'E',
            templateUrl: 'Scripts/app/diary-entry-text.html'
        };
    });