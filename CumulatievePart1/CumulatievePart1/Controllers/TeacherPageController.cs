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
        /// When clicking on the Teachers button in the Navigation Bar, it returns the web page displaying all the teachers in the Database school.
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
        /// When we Select one Teacher from the list, it returns the web page displaying the information of the Selected Teacher from the database school.
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
    }
}
