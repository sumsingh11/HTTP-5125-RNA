
//A model to represent information about a student.


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CumulatievePart1.Models;
namespace CumulatievePart1.Models
{
         /// <summary>
         /// The unique identifier for the student.
         /// </summary>
         public class Student
    {   
          /// The unique identifier for the student.
         /// </summary>
         public int StudentId { get; set; }

         /// <summary>
         /// The first name of the student.
         /// </summary>
         /// 
         public string StudentFName { get; set; }
         /// <summary>
         /// The last name of the student.
         /// </summary>
         /// 
        public string StudentLName { get; set; }
        public string StudentNumber { get; set; }

        /// <summary>
        /// The date the student was enrolled .
        /// </summary>
         public DateTime EnrolDate { get; set; }
    }
}