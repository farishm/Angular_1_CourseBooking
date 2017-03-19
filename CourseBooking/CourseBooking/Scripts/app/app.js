var app = angular.module("appBooking", ["ngRoute","ctrlBooking"]);
app.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "Home.html",
        controller: "ctrlHome"
    })    
    .when("/courseList",
    {
        templateUrl: "Course/List.html",
        controller: "ctrlCourseList"
    })
    .when("/courseCreate",
    {
        templateUrl: "Course/Edit.html",
        controller: 'ctrlCourseEdit'
    })
    .when("/edit/:id",
    {
        templateUrl: "Course/Edit.html",
        controller: "ctrlCourseEdit"
    })  
    .when("/book/:id",
    {
        templateUrl: "Course/Book.html",
        controller: "ctrlCourseBook"
    })      
    .otherwise(
    {
        redirectTo: '/'
    });
});

