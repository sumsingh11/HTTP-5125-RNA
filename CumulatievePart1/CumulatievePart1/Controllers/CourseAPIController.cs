// A WebAPI Controller to access information about courses.

using CumulatievePart1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CumulatievePart1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public CourseAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all the courses from the databases.
        /// </summary>
        /// <returns>A list of all courses available in the database.</returns>
        
        [HttpGet]
        [Route("ListOfCourses")]
        public List<Course> ListOfCourses()
        {
            List<Course> courses = new List<Course>();

            using (MySqlConnection connection = _context.AccessDatabase())
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM courses"; 
// Replace with actual query if necessary.


                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Course course = new Course
                        {
                            CourseId = Convert.ToInt32(reader["CourseId"]),
                            CourseCode = reader["CourseCode"].ToString(),
                            CourseName = reader["CourseName"].ToString(),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            FinishDate = Convert.ToDateTime(reader["FinishDate"]),
                            TeacherId = Convert.ToInt32(reader["TeacherId"])
                        };
                        courses.Add(course);
                    }
                }
            }

            return courses;
        }

        /// <summary>
        /// Get a course by its ID.
        /// </summary>
        /// <param name="id">The ID of the course to retrieve.</param>
        /// <returns>Details of the course with the specified ID.</returns>
        [HttpGet]
        [Route("FindCourseDetail/{id}")]
        public Course FindCourseDetail(int id)
        {
            Course course = null;

            using (MySqlConnection connection = _context.AccessDatabase())
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM courses WHERE CourseId=@id";
                command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        course = new Course
                        {
                            CourseId = Convert.ToInt32(reader["CourseId"]),
                            CourseCode = reader["CourseCode"].ToString(),
                            CourseName = reader["CourseName"].ToString(),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            FinishDate = Convert.ToDateTime(reader["FinishDate"]),
                            TeacherId = Convert.ToInt32(reader["TeacherId"])
                        };
                    }
                }
            }



  // Fix: Return the variable "course" instead of "Course"
            return course; 
          
        }
    }
}
