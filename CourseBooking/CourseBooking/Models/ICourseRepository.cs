using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseBooking.Models
{
    public interface ICourseRepository
    {
        void Add(Course course);
        IEnumerable<Course> GetAll();
        Course GetByID(int id);
        void Delete(int id);
        void Update(Course course);
    }
}