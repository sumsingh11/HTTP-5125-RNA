
//A model to represent information about a teacher.


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CumulatievePart1.Models;

namespace CumulatievePart1.Models
{
     /// <summary>
    /// Representing a teacher in the school.
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Appearing first name of  teacher.
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// The first name of teacher.
        /// </summary>
        public string TeacherFName { get; set; }

        /// <summary>
        /// The last name of teacher.
        /// </summary>
        public string TeacherLName { get; set; }

        /// <summary>
        /// The date teacher was hired.
        /// </summary>
        public DateTime TeacherHireDate { get; set; }

        /// <summary>
        /// A unique employee number assigned to each of the teacher.
        /// </summary>
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// The salary of the teacher, stored as a decimal to accommodate the monetary values.
        /// </summary>
        public decimal TeacherSalary { get; set; }
    }
}