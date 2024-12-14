// An MVC Controller to route to dynamic pages.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CumulatievePart1.Models;
using MySql.Data.MySqlClient;
using System;

namespace CumulatievePart1.Controllers
{
    public class TeacherPageController : Controller
    {
        private readonly TeacherAPIController _api;

        public TeacherPageController(TeacherAPIController api)
        {
            _api = api;
        }

        /// <summary>
        /// While clicking on the Teachers button in the Navigation Bar, it returns the web page displaying all the teachers in the Database school.
        /// </summary>
        /// <returns>
        /// List of all the Teachers in the Database school .
        /// </returns>
        /// <example>
        /// GET : api/TeacherPage/List->Gives the list of all Teachers in the Database school.
        /// </example>
        /// 
        [HttpGet]
        public IActionResult List()
        {
            List<Teacher> teachers = _api.ListOfTeachers();
            return View(teachers);
        }

        /// <summary>
        /// When we Select one Teacher from the list, it is returns the web page displaying the information of the Selected Teacher from the database school.
        /// </summary>
        /// <returns>
        /// Information of the Teacher from the database school.
        /// </returns>
        /// <example>
        /// GET :api/TeacherPage/Show/{id}->Gives the information of the Teacher.
        /// </example>
        public IActionResult Show(int id)
        {
            Teacher teacherData = _api.FindTeacherDetail(id);
            return View(teacherData);
        }
        [HttpGet]
        public IActionResult New(int id)
        {
            return View();
        }

        // POST: TeacherPage/Create
        [HttpPost]
        public IActionResult Create(Teacher NewTeacher)
        {
            int TeacherId = _api.AddTeacher(NewTeacher);

            // redirects to "Show" action on "Author" cotroller with id parameter supplied
            return RedirectToAction("Show", new {id = TeacherId});
        }

        // GET : AuthorPage/DeleteConfirm/{id}
        [HttpGet]
        public IActionResult DeleteConfirm(int id)
        {
            Teacher SelectedTeacher = _api.FindTeacherDetail(id);
            return View(SelectedTeacher);
        }

        // POST: AuthorPage/Delete/{id}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            int TeacherId = _api.DeleteTeacher(id);
            // redirects to list actions
            return RedirectToAction("List");
             }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Teacher SelectedTeacher = _api.FindTeacherDetail(id);
            return View(SelectedTeacher);
        }
        // POST action to update teacher details after form submission
        [HttpPost]
        public IActionResult Update(int id, string TeacherFName, string TeacherLName, DateTime TeacherHireDate, string EmployeeNumber, decimal TeacherSalary)
        {

                 // Create a new Teacher object to hold the updated details  
            Teacher UpdatedTeacher = new Teacher();

 // Assign the incoming form data to the new Teacher object
            UpdatedTeacher.TeacherFName = TeacherFName;
            UpdatedTeacher.TeacherLName = TeacherLName;
            UpdatedTeacher.TeacherHireDate = TeacherHireDate;
            UpdatedTeacher.EmployeeNumber = EmployeeNumber;
            UpdatedTeacher.TeacherSalary = TeacherSalary;

    // Call the API method to update the teacher's data in the system
                _api.UpdateTeacher(id, UpdatedTeacher);

    // Redirect to the "Show" action to view the updated teacher details
                return RedirectToAction("Show", new { id = id });
        }

    }
}
