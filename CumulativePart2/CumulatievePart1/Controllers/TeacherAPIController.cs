

//A WebAPI Controller to access information about teachers.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CumulatievePart1.Models;
using System;
using MySql.Data.MySqlClient;



namespace CumulatievePart1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {

        // This is dependancy injection for the database connection.
        private readonly SchoolDbContext _context;
        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// WWhile clicking on Teachers tab in Navigation bar on Home page, We are directed to a webpage that lists all teachers in the database school
        /// </summary>
        /// <example>
        /// GET api/Teacher/ListTeachers->[{"TeacherFname":"Sumit", "TeacherLName":"Singh"},{"TeacherFname":"Rohit", "TeacherLName":"Kumar"},.............]
        /// GET api/Teacher/ListTeachers->[{"TeacherFname":"Raj", "TeacherLName":"Shah"},{"TeacherFname":"Urvashi", "TeacherLName":"Patel"},.............]
        /// </example>
        /// <returns>
        /// A list all the teachers in the database school.
        /// </returns>


        [HttpGet]
        [Route(template: "ListOfTeachers")]
        public List<Teacher> ListOfTeachers()
        {

            // Creating an empty list of Teachers.
            List<Teacher> teachers = new List<Teacher>();

            // 'using' keyword is used to close the connection by itself after executing the code given inside the brackets.
            using (MySqlConnection Connection = _context.AccessDatabase())
            {

                // Opening the connection.
                Connection.Open();


                // Establishing a new query for our database.
                MySqlCommand Command = Connection.CreateCommand();


                // Writing the SQL Query to give to database to access information.
                Command.CommandText = "select * from teachers";


                // Storing the Result Set query in a variable.
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {

                    // While loop is used to loop through each row in the ResultSet. 
                    while (ResultSet.Read())
                    {

                        // Accessing the information of Teacher using the Column name as an index.
                        int T_Id = Convert.ToInt32(ResultSet["teacherid"]);
                        string FName = ResultSet["teacherfname"].ToString();
                        string LName = ResultSet["teacherlname"].ToString();
                        string EmpNumber = ResultSet["employeenumber"].ToString();
                        DateTime HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                        decimal Salary = Convert.ToDecimal(ResultSet["salary"]);


                        // Assign the short names for properties of the Teacher.
                        Teacher EachTeacher = new Teacher()
                        {
                            TeacherId = T_Id,
                            TeacherFName = FName,
                            TeacherLName = LName,
                            TeacherHireDate = HireDate,
                            EmployeeNumber = EmpNumber,
                            TeacherSalary = Salary
                        };


                        // Add all the values of properties of EachTeacher in Teachers List.
                        teachers.Add(EachTeacher);

                    }
                }
            }


            //Returning the final list of Teachers. 
            return teachers;
        }


        /// <summary>
        /// When selecting one teacher , it returns information of the selected Teacher in the database by their ID.
        /// </summary>
        /// <example>
        /// GET api/Teacher/FindTeacher/3->{"TeacherId":3,"TeacherFname":"Sam","TeacherLName":"Cooper"}
        /// </example>
        /// <returns>
        /// Information about the Teacher selected
        /// </returns>



        [HttpGet]
        [Route(template: "FindTeacherDetail/{id}")]
        public Teacher FindTeacherDetail(int id)
        {

            // Creating an object using Teacher definition defined as Class in Models
            Teacher TeacherData = new Teacher();


            // 'using' keyword is used that will close the connection by itself after executing the code 
            using (MySqlConnection Connection = _context.AccessDatabase())
            {

                // Opening Connection
                Connection.Open();

                MySqlCommand Command = Connection.CreateCommand();


                // @id is replaced with a 'sanitized'(masked) id so that id can be referenced
               
                Command.CommandText = "select * from teachers where teacherid=@id";
                Command.Parameters.AddWithValue("@id", id);


                // Store the Result Set query 
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {

                    // While loop is used to loop through each row  
                    while (ResultSet.Read())
                    {

                        // Accessing the information of Teachers.  
                        int T_Id = Convert.ToInt32(ResultSet["teacherid"]);
                        string FName = ResultSet["teacherfname"].ToString();
                        string LName = ResultSet["teacherlname"].ToString();
                        string EmpNumber = ResultSet["employeenumber"].ToString();
                        DateTime HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                        decimal Salary = Convert.ToDecimal(ResultSet["salary"]);


                        // Accessing the information of the properties of Teacher .
                        // created above for all properties of the Teacher.
                        TeacherData.TeacherId = T_Id;
                        TeacherData.TeacherFName = FName;
                        TeacherData.TeacherLName = LName;
                        TeacherData.TeacherHireDate = HireDate;
                        TeacherData.EmployeeNumber = EmpNumber;
                        TeacherData.TeacherSalary = Salary;

                    }
                }
            }


            //Returning the Information of the Teacher.
            return TeacherData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TeacherData"></param>
        /// <returns></returns>
        [HttpPost(template:"AddTeacher")]
        public int AddTeacher([FromBody]Teacher TeacherData)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                // CURRENT_DATE() for the author join date in this context
                // Other contexts the join date may be an input criteria!
                Command.CommandText = "insert into teachers (teacherfname, teacherlname, employeenumber, salary, hiredate) values (@teacherfname, @teacherlname, @employeenumber, @salary, @hiredate)";
                Command.Parameters.AddWithValue("@teacherfname", TeacherData.TeacherFName);
                Command.Parameters.AddWithValue("@teacherlname", TeacherData.TeacherLName);
                Command.Parameters.AddWithValue("@employeenumber", TeacherData.EmployeeNumber);
                Command.Parameters.AddWithValue("@salary", TeacherData.TeacherSalary);
                Command.Parameters.AddWithValue("@hiredate", TeacherData.TeacherHireDate);
                          
                Command.ExecuteNonQuery();

                return Convert.ToInt32(Command.LastInsertedId);

            }
            // if failure
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        [HttpDelete(template:"DeleteTeacher/{TeacherId}")]
        public int DeleteTeacher(int TeacherId)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                
                Command.CommandText = "delete from teachers where teacherid=@id";
                Command.Parameters.AddWithValue("@id", TeacherId);
                return Command.ExecuteNonQuery();

            }
            // if failure
            return 0;
        }
    }


}