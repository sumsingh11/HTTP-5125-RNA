

//An MVC Controller to route to dynamic pages for courses.


using Microsoft.AspNetCore.Mvc;
using CumulatievePart1.Models;
using System.Linq;

namespace CumulatievePart1.Controllers
{
    public class CoursePageController : Controller
    {
        private readonly CourseAPIController _api;

        public CoursePageController(CourseAPIController api)
        {
            _api = api;
        }

        /// <summary>
        /// Displays a list of all courses.
        /// </summary>
        public IActionResult List()
        {
            List<Course> courses = _api.ListOfCourses();
            return View(courses); 
        // Pass the list of courses to the view
        }

        /// <summary>
        /// Displaying details of a selected course by ID .
        /// </summary>
        /// 
        public IActionResult Show(int id)
        {
            Course course = _api.FindCourseDetail(id);
            return View(course); 
        // Pass the course details to the view
        }

   [HttpGet]
        public IActionResult New(int id)
        {
            return View();
        }

        // POST: TeacherPage/Create
        [HttpPost]
        public IActionResult Create(Course NewCourse)
        {
            int CourseId = _api.AddCourse(NewCourse);

            // redirects to "Show" action on "Author" cotroller with id parameter supplied
            return RedirectToAction("Show", new {id = CourseId});
        }

        // GET : AuthorPage/DeleteConfirm/{id}
        [HttpGet]
        public IActionResult DeleteConfirm(int id)
        {
            Course SelectedCourse = _api.FindCourseDetail(id);
            return View(SelectedCourse);
        }

        // POST: AuthorPage/Delete/{id}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            int CourseId = _api.DeleteCourse(id);
            // redirects to list action
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            
        // Fetch the course using the API
            Course SelectedCourse = _api.FindCourseDetail(id);
            return View(SelectedCourse);
        }

        [HttpPost]
        public IActionResult Update(int id, string CourseCode, int TeacherId, DateTime StartDate, DateTime FinishDate, string CourseName)
        {
            
            Course UpdatedCourse = new Course();

            UpdatedCourse.CourseCode = CourseCode;
            UpdatedCourse.TeacherId = TeacherId;
            UpdatedCourse.StartDate = StartDate;
            UpdatedCourse.FinishDate = FinishDate;
            UpdatedCourse.CourseName = CourseName;
            

        // Update the course using the API (assuming _api.UpdateCourse works similarly to the Teacher example)
            _api.UpdateCourse(id, UpdatedCourse);

        // Redirect to the 'Show' action to display the updated course
            return RedirectToAction("Show", new { id = id });
    }
}
}