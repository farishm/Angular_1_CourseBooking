var ctrlBooking = angular.module("ctrlBooking", []);  

ctrlBooking.controller("ctrlHome", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('api/Course').success(function (data) {
            $scope.courses = data.slice(1, 9);
            //console.log(data);
        });
    }
]);  

ctrlBooking.controller("ctrlCourseList", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {

        $scope.loadList = function () {
            $scope.detailsSelected = false;
            $scope.deleteSelected = false;

            $http.get('api/Course').success(function (data) {
                $scope.courses = data;
                //console.log($scope.courses);
            });
        }

        $scope.loadList();
       

        $scope.onDelete = function (course) {
            $scope.selectedCourse = course;
            $scope.detailsSelected = false;
            $scope.deleteSelected = true;
        }

        $scope.delete = function () {
            $http.delete('/api/Course/' + $scope.selectedCourse.Id).success(function (data) {
                $scope.loadList();
            }).error(function (data) {
                $scope.error = "An Error occured, could not delete Course " + data;
            });
        };  


        $scope.onSelect = function (course) {
            $scope.selectedCourse = course;
            $scope.detailsSelected = true;
            $scope.deleteSelected = false;
        }
      
        $scope.gotoAdd = function () {
            $location.path('/courseCreate');
        }

        $scope.gotoEdit = function (id) {            
            $location.path('/edit/' + id);
        }

        $scope.gotoBook = function () {
            $location.path('/book/' + $scope.selectedCourse.Id);
        }

        $scope.gotoClose = function () {
            $scope.detailsSelected = false;
        }        
    }
    
]);  

ctrlBooking.controller("ctrlCourseEdit", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {        
        if ($routeParams.id) {
            $http.get('/api/Course/' + $routeParams.id).success(function (data) {              
                $scope.Id = data.Id;
                $scope.Title = data.Title;
                $scope.Description = data.Description;
                $scope.Reference = data.Reference;
                $scope.Duration = data.Duration;
                $scope.Fees = data.Fees;
                $scope.Status = data.Status;
                $scope.Location = data.Location;
                $scope.TotalPlaces = data.TotalPlaces;
                $scope.AvailablePlaces = data.AvailablePlaces;

                $scope.titleText = "Edit Course - " + data.Title;
            });
        }
        else {
            $scope.titleText = "Create New Course";
        }

        $scope.goBack = function () {            
            $location.path('/courseList');          
        }

        $scope.save = function () {
            $scope.Id = 0;  
            var course = {
                Id: $scope.Id,
                Title: $scope.Title,
                Reference: $scope.Reference,
                Duration: $scope.Duration,
                Fees: $scope.Fees,
                Status: $scope.Status,
                Location: $scope.Location,
                Totalplaces: $scope.Totalplaces,
                AvailablePlaces: $scope.AvailablePlaces
            };
            if ($scope.Id === 0) {
                $http.post('/api/Course/', course).success(function (data) {
                    $location.path('/courseList');
                }).error(function (data) {
                    $scope.error = "An Error occured, could not add the Course" + data.ExceptionMessage;
                });
            }
            else {
                $http.put('/api/Course/', course).success(function (data) {
                    $location.path('/courseList');
                }).error(function (data) {
                    console.log(data);
                    $scope.error = "An Error occured, could not update the Course! " + data.ExceptionMessage;
                });
            } 
            
        }
               
    }
]); 

ctrlBooking.controller("ctrlCourseBook", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
        if ($routeParams.id) {
            $http.get('/api/Course/' + $routeParams.id).success(function (data) {
                $scope.Id = data.Id;
                $scope.Title = data.Title;
                $scope.Description = data.Description;
                $scope.Reference = data.Reference;
                $scope.Duration = data.Duration;
                $scope.Fees = data.Fees;
                $scope.Status = data.Status;
                $scope.Location = data.Location;
                $scope.TotalPlaces = data.TotalPlaces;
                $scope.AvailablePlaces = data.AvailablePlaces;

               
            });
        }
        else {
            $scope.Title = "Wrong Id";
        }

        $scope.goBack = function () {
            $location.path('/courseList');
        }

        $scope.book = function () {
            $location.path('/courseList');
        }

    }
]); 