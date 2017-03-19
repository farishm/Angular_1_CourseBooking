using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseBooking.Models
{
    public class InMemoryCourseRepository : ICourseRepository
    {
        private static List<Course> _db = new List<Course>();

        public InMemoryCourseRepository()
        {
            //If No Records Create some dummies
            if(_db.Count < 1)
            { 
            _db.Add(new Course { Id = 1, Title = "ASP .Net Basics", Description = "ASP .Net Course for beginners", Reference = "ASPNETB001", Duration = 6, Fees = 500, Status = "open", Location = "Net Hall 1", TotalPlaces = 100, AvailablePlaces = 90 });
            _db.Add(new Course { Id = 2, Title = "ASP .Net Advanced", Description = "ASP .Net Course for mIddle level programmers", Reference = "ASPNETA001", Duration = 10, Fees = 1500, Status = "open", Location = "Net Hall 3", TotalPlaces = 100, AvailablePlaces = 60 });
            _db.Add(new Course { Id = 3, Title = "JavaScript with 12 Projects", Description = "JavaScript Course with 12 interactive Project work", Reference = "JSCRM001", Duration = 9, Fees = 1000, Status = "open", Location = "Net Hall 2", TotalPlaces = 100, AvailablePlaces = 50 });
            _db.Add(new Course { Id = 4, Title = "AngularJS", Description = "AngularJS Course for developers with some JavaScript knowledge", Reference = "JSCRM006", Duration = 6, Fees = 1000, Status = "open", Location = "Net Hall 5", TotalPlaces = 100, AvailablePlaces = 30 });
            _db.Add(new Course { Id = 5, Title = "ReactJS", Description = "ReactJS Course for developers with some JavaScript knowledge", Reference = "JSCRM007", Duration = 6, Fees = 1000, Status = "open", Location = "Net Hall 5", TotalPlaces = 100, AvailablePlaces = 90 });
            _db.Add(new Course { Id = 6, Title = "HTML5 Basics", Description = "HTML5 Basics", Reference = "HTMLB001", Duration = 6, Fees = 500, Status = "open", Location = "Net Hall 1", TotalPlaces = 100, AvailablePlaces = 10 });
            _db.Add(new Course { Id = 7, Title = "Bootstrap", Description = "Bootstrap", Reference = "BSTB001", Duration = 6, Fees = 500, Status = "open", Location = "Net Hall 1", TotalPlaces = 100, AvailablePlaces = 0 });
            _db.Add(new Course { Id = 8, Title = "JQuery and Ajax", Description = "JQuery and Ajax", Reference = "JSCRM007", Duration = 6, Fees = 500, Status = "open", Location = "Net Hall 1", TotalPlaces = 100, AvailablePlaces = 0 });
            _db.Add(new Course { Id = 9, Title = "SQL Server Development", Description = "SQL Server Development", Reference = "SQL001", Duration = 15, Fees = 2500, Status = "open", Location = "Net Hall 1", TotalPlaces = 100, AvailablePlaces = 0 });
            _db.Add(new Course { Id = 10, Title = "ASP .Net Web API", Description = "ASP .Net Web API Development with Project work", Reference = "ASPNETB010", Duration = 18, Fees = 2500, Status = "open", Location = "Net Hall 1", TotalPlaces = 100, AvailablePlaces = 0 });
            }
        }

        public void Add(Course course)
        {
            if (course.Id == 0)
                course.Id = _db.Count + 1;
            _db.Add(course);
        }
        public IEnumerable<Course> GetAll()
        {
            return _db.ToList();
        }
        public Course GetByID(int id)
        {
            return _db.FirstOrDefault(d => d.Id == id);

        }
        public void Delete(int id)
        {
            _db.Remove(_db.FirstOrDefault(d => d.Id == id));
        }

        public void Update(Course course)
        {
            foreach (Course c in _db)
            {
                if (c.Id == course.Id)
                {
                    _db.Remove(c);
                    _db.Add(course);
                    break;
                }
            }
        }

    }
}