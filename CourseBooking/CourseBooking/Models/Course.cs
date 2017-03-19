using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseBooking.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public int Duration { get; set; }
        public int Fees { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public int TotalPlaces { get; set; }
        public int AvailablePlaces { get; set; }
    }
}