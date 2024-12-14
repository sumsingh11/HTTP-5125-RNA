

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CumulatievePart1.Models;

namespace CumulatievePart1.Models
{
    public class TeacherCoursesViewModel : Controller
    {
        public Teacher Teacher { get; set; }
        
        public List<string> Courses { get; set; }
    }
}