
using Microsoft.AspNetCore.Mvc; // Importing necessary namespace for MVC functionality.

namespace Assignment1n01722360.Controllers
{
    /// <summary>
    /// This controller handles a GET request to provide the current date adjusted by a specified number of days.
    /// </summary>
    
    [Route("api/[controller]")] // Sets the base route as "api/q7", where "q7" refers to the controller name.
    [ApiController] // Declares this class as an API controller that handles HTTP requests.
    public class q7 : Controller
    {
        /// <summary>
        /// Handles a GET request to return the current date adjusted by a specified number of days.
        /// </summary>
        /// <param name="days">The number of days to adjust the current date by. Can be positive or negative.</param>
        /// <returns>
        /// Returns the adjusted date in "yyyy-MM-dd" format.
        /// </returns>
        /// <example> 
        /// 1: GET request to api/q7/timemachine?days=1 -> Response: "2024-09-30" (if today is 2024-09-29)
        /// 2: GET request to api/q7/timemachine?days=-1 -> Response: "2024-09-28" (if today is 2024-09-29)
        /// </example>
        
        [HttpGet(template: "timemachine")] // Maps the GET request to the endpoint "api/q7/timemachine".
        public string timemachine(int days) // Accepts an integer parameter 'days' that specifies how many days to adjust the date by.
        {
        // Gets the current date without the time part.
        DateTime CurrentDate = DateTime.Today;

        // Adds or subtracts the specified number of days to/from the current date.
        DateTime CalculatedDays = CurrentDate.AddDays(days);

        // Returns the adjusted date formatted as "yyyy-MM-dd".
        return CalculatedDays.ToString("yyyy-MM-dd");
        }
    }
}
