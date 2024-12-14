

//A WebAPI Controller to access information about students.


using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using CumulatievePart1.Models;


namespace CumulatievePart1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public StudentAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all students from the database .
        /// </summary>
        /// <returns>A list of all students in the database</returns>
        [HttpGet]
        [Route("ListOfStudents")]
        public List<Student> ListOfStudents()
        {
            List<Student> students = new List<Student>();

            using (MySqlConnection connection = _context.AccessDatabase())
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM students"; 
                // Replace with actual query if necessary
                Console.WriteLine("here");
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            StudentFName = reader["StudentFName"].ToString(),
                            StudentLName = reader["StudentLName"].ToString(),
                            StudentNumber = reader["StudentNumber"].ToString(),
                            EnrolDate = Convert.ToDateTime(reader["EnrolDate"])
                        };
                        students.Add(student);
                    }
                }
            }
            return students;
        }

        /// <summary>
        /// Get a student name by their ID.
        /// </summary>
        /// <param name="id">The ID of the students to retrieve</param>
        /// <returns>Details of the student</returns>
        /// 
        [HttpGet]
        [Route("FindStudentDetail/{id}")]
        public Student FindStudentDetail(int id)
        {
            Student student = null;

            using (MySqlConnection connection = _context.AccessDatabase())
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM students WHERE StudentId=@id";
                command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        student = new Student
                        {
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            StudentFName = reader["StudentFName"].ToString(),
                            StudentLName = reader["StudentLName"].ToString(),
                            StudentNumber = reader["StudentNumber"].ToString(),
                            EnrolDate = Convert.ToDateTime(reader["EnrolDate"])
                        };
                    }
                }
            }
            

            return student;
        }
        [HttpPost(template:"AddStudent")]
        public int AddStudent([FromBody]Student StudentData)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                // CURRENT_DATE() for the author joining dates in this context
                // Other contexts the joining date may be an input criteria!
                Command.CommandText = "insert into students (studentfname, studentlname, studentnumber, enroldate) values (@studentfname, @studentlname, @studentnumber, @enroldate)";
                Command.Parameters.AddWithValue("@studentfname", StudentData.StudentFName);
                Command.Parameters.AddWithValue("@studentlname", StudentData.StudentLName);
                Command.Parameters.AddWithValue("@studentnumber", StudentData.StudentNumber);
                Command.Parameters.AddWithValue("@enroldate", StudentData.EnrolDate);
             
                          
                Command.ExecuteNonQuery();

                return Convert.ToInt32(Command.LastInsertedId);

            }
            // if failure
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
         [HttpDelete(template:"DeleteStudent/{StudentId}")]
        public int DeleteStudent(int StudentId)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                
                Command.CommandText = "delete from students where studentid=@id";
                Command.Parameters.AddWithValue("@id", StudentId);
                return Command.ExecuteNonQuery();

            }
            // if failure
            return 0;

             }


        /// <summary>
        /// Updates a Student in the database. Data is a Student object, request query contains Student ID.
        /// </summary>
        /// <param name="StudentData">Student Object contains updated student details now</param>
        /// <param name="StudentId"> Student ID primary key</param>
        /// <example>
        /// PUT: api/Student/UpdateStudent/4
        /// Headers: Content-Type: application/json
        /// Request Body:
        /// {
        ///     "StudentFName": "Sumit",
        ///     "StudentLName": "",
        ///     "EnrollDate": "2024-01-01",
        ///     "StudentNumber": "S12345"
        /// } -> 
        /// {
        ///     "StudentId": 4,
        ///     "StudentFName": "Sumit",
        ///     "StudentLName": "Singh",
        ///     "EnrollDate": "2024-01-01",
        ///     "StudentNumber": "S12345"
        /// }
        /// </example>
        /// <returns>
        /// The updated Student object
        /// </returns>

        [HttpPut(template: "UpdateStudent/{StudentId}")]
        public Student UpdateStudent(int StudentId, [FromBody] Student StudentData)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
            //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

            // parameterize query
                Command.CommandText = "UPDATE students SET studentfname=@studentfname, studentlname=@studentlname,enroldate=@enroldate, studentnumber=@studentnum WHERE studentid=@id";
                Command.Parameters.AddWithValue("@studentfname", StudentData.StudentFName);
                Command.Parameters.AddWithValue("@studentlname", StudentData.StudentLName);
                Command.Parameters.AddWithValue("@enroldate", StudentData.EnrolDate);
                Command.Parameters.AddWithValue("@studentnum", StudentData.StudentNumber);

            // Add student ID to specify which student to update
                Command.Parameters.AddWithValue("@id", StudentId);

            // Execute the query to update the student's details
                Command.ExecuteNonQuery();
            }

            // Return the updated student details
            return FindStudentDetail(StudentId);
        
        }
    }
}