

//An MVC Controller to route to dynamic pages for students.


using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CumulatievePart1.Models;


namespace CumulatievePart1.Controllers
{
    public class StudentPageController : Controller
    {
        private readonly StudentAPIController _api;

        public StudentPageController(StudentAPIController api)
        {
            _api = api;
        }

        /// <summary>
        /// Displays a list of all students.
        /// </summary>
        /// <example>
        /// GET : api/StudentPage/List->Gives the list of all Students in the Database.
        /// </example>
        public IActionResult List()
        {
            List<Student> students = _api.ListOfStudents();
            // Pass the list of students to the view.
            return View(students); 
        }

        /// <summary>
        /// Displays details of a selected student by ID.
        /// /// </summary>
        /// /// <example>
        /// GET :api/StudentPage/Show/{id}->Gives the information of the Student
        /// </example>

        public IActionResult Show(int id)
        {
            Student student = _api.FindStudentDetail(id);
            // Pass the student details to the view
            return View(student); 
        }
    }
}