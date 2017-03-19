using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CourseBooking.Models;

namespace CourseBookin.Controllers
{
    public class CourseController : ApiController
    {
        private ICourseRepository courseRepo;

        public CourseController() {
            courseRepo=new InMemoryCourseRepository();
        }

        public CourseController(ICourseRepository _courseRepo)
        {
            courseRepo = _courseRepo;
        }
        

        public IEnumerable<Course> GetAllCourses()
        {
            return courseRepo.GetAll();
        }

        //public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        //{
        //    return await Task.FromResult(GetAllCourses());
        //}

        
        // GET api/Course/id
        public Course Get(int id)
        {
            return courseRepo.GetByID(id);
           
        }

        //public async Task<IHttpActionResult> GetCourseAsync(int id)
        //{
        //    return await Task.FromResult(GetCourse(id));
        //}

        // POST api/Course  
        public HttpResponseMessage Post(Course _course)
        {
            if (ModelState.IsValid)
            {
                courseRepo.Add(_course);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, _course);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        //public IHttpActionResult Create(Course _course)
        //{
        //    courseRepo.Add(_course);
        //    return CreatedAtRoute("DefaultApi", new { id = _course.Id }, _course);
        //}

        // DELETE api/course/Id  
        public HttpResponseMessage Delete(int id)
        {
            var course = courseRepo.GetByID(id);
            if (course == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            courseRepo.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, course);
        }

        // PUT api/Course/id  
        public HttpResponseMessage Put(Course _course)
        {
            if (ModelState.IsValid)
            {
                courseRepo.Update(_course);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, (_course));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        //public IHttpActionResult Update(Course _course)
        //{
        //    courseRepo.Update(_course);
        //    return Content(HttpStatusCode.Accepted, _course);
        //}

    }
}
