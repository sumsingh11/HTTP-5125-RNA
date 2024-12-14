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
    
    [HttpPost(template:"AddCourse")]
        public int AddCourse([FromBody]Course CourseData)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                // CURRENT_DATE() for the author join date in this context
                // Other contexts the join date may be an input criteria!
                Command.CommandText = "insert into courses (CourseCode, CourseName, StartDate, FinishDate, TeacherId) values (@CourseCode, @CourseName, @StartDate, @FinishDate, @TeacherId)";
                Command.Parameters.AddWithValue("@CourseCode", CourseData.CourseCode);
                Command.Parameters.AddWithValue("@CourseName", CourseData.CourseName);
                Command.Parameters.AddWithValue("@StartDate", CourseData.StartDate);
                Command.Parameters.AddWithValue("@FinishDate", CourseData.FinishDate);
                Command.Parameters.AddWithValue("@TeacherId", CourseData.TeacherId);
                          
                Command.ExecuteNonQuery();

                return Convert.ToInt32(Command.LastInsertedId);

            }
            // if failure
            return 0;
        }
         [HttpDelete(template:"DeleteCourse/{CourseId}")]
        public int DeleteCourse(int CourseId)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                
                Command.CommandText = "delete from courses where courseid=@id";
                Command.Parameters.AddWithValue("@id", CourseId);
                return Command.ExecuteNonQuery();

            }
            // if failure
            return 0;
        }
        /// <summary>
        /// Updates a Course in the database. Data is Course object, request query contains Course ID.
        /// </summary>
        /// <param name="CourseData">Course Object containing updated course details</param>
        /// <param name="CourseId">The Course ID primary key</param>
        /// <example>
        /// PUT: api/Course/UpdateCourse/4
        /// Headers: Content-Type: application/json
        /// Request Body:
        /// {
        ///     "coursecode": "CS101",
        ///     "teacherid": 2,
        ///     "startdate": "2024-01-01",
        ///     "finishdate": "2024-05-01",
        ///     "coursename": "Introduction to Computer Science"
        /// } -> 
        /// {
        ///     "courseid": 4,
        ///     "coursecode": "CS101",
        ///     "teacherid": 2,
        ///     "startdate": "2024-01-01",
        ///     "finishdate": "2024-05-01",
        ///     "coursename": "Introduction to Computer Science"
        /// }
        /// </example>
        /// <returns>
        /// The updated Course object
        /// </returns>

        [HttpPut("UpdateCourse/{CourseId}")]
        public Course UpdateCourse(int CourseId, [FromBody] Course CourseData)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();

                // Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                // Parameterized query to prevent SQL injection
                Command.CommandText = "UPDATE courses SET CourseCode=@CourseCode, TeacherId=@TeacherId, StartDate=@StartDate, FinishDate=@FinishDate, CourseName=@CourseName WHERE CourseId=@id";
                Command.Parameters.AddWithValue("@CourseCode", CourseData.CourseCode);
                Command.Parameters.AddWithValue("@TeacherId", CourseData.TeacherId);
                Command.Parameters.AddWithValue("@StartDate", CourseData.StartDate);
                Command.Parameters.AddWithValue("@FinishDate", CourseData.FinishDate);
                Command.Parameters.AddWithValue("@CourseName", CourseData.CourseName);
                Command.Parameters.AddWithValue("@id", CourseId);

                
                Command.ExecuteNonQuery();

               
               
            }

            // Return the updated course details
            return FindCourseDetail(CourseId); // Return the updated course
        }}
}