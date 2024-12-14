

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
    
    [HttpGet]
        public IActionResult New(int id)
        {
            return View();
        }

        // POST: TeacherPage/Create
        [HttpPost]
        public IActionResult Create(Student NewStudent)
        {
            int StudentId = _api.AddStudent(NewStudent);

            // redirects to "Show" action on "Author" cotroller with id parameter supplied
            return RedirectToAction("Show", new {id = StudentId});
        }

        // GET : AuthorPage/DeleteConfirm/{id}
        [HttpGet]
        public IActionResult DeleteConfirm(int id)
        {
            Student SelectedStudent = _api.FindStudentDetail(id);
            return View(SelectedStudent);
        }

        // POST: AuthorPage/Delete/{id}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            int StudentId = _api.DeleteStudent(id);
            // redirects to list action
            return RedirectToAction("List");
            }

        // GET method to show the current student's details before editing
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Find the selected student by ID
            Student SelectedStudent = _api.FindStudentDetail(id);
            return View(SelectedStudent);  // Pass the student data to the Edit view
        }

        // POST method to handle the updated student data
        [HttpPost]
        public IActionResult Update(int id, string StudentFName, string StudentLName, DateTime EnrollDate, string StudentNumber)
        {
            // Create a new Student object to store the updated values
            Student UpdatedStudent = new Student();
            UpdatedStudent.StudentFName = StudentFName;
            UpdatedStudent.StudentLName = StudentLName;
            UpdatedStudent.EnrolDate = EnrollDate;
            UpdatedStudent.StudentNumber = StudentNumber;

        // Call the API to update the student in the database
            _api.UpdateStudent(id, UpdatedStudent);

    // Redirect to the Show page to display the updated student details
            return RedirectToAction("Show", new { id = id });
        }
        }
    }
