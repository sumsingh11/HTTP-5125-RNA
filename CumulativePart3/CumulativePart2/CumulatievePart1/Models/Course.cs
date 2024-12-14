

//A model to represent information about a course.

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CumulatievePart1.Models;
namespace CumulatievePart1.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
// Foreign key to the Teacher table
        public int TeacherId { get; set; } 

        // Navigation property to the Teacher
      
    }
}