
using Microsoft.AspNetCore.Mvc; // Importing necessary namespace for MVC functionality.

namespace Assignment1n01722360.Controllers
{
    /// <summary>
    /// This controller handles requests for mathematical operations, specifically calculating the cube of a given number.
    /// </summary>
    
    [Route("api/[controller]")] // Defines the base route as "api/q3", derived from the controller name "q3".
    [ApiController] // Marks this class as an API controller to handle HTTP requests.
    public class q3 : Controller
    {
        /// <summary>
        /// Handles a GET request to calculate the cube of a given number.
        /// </summary>
        /// <param name="num">The number to be cubed.</param>
        /// <returns>
        /// Returns the cube of the specified number as an integer.
        /// </returns>
        /// <example>
        /// 1: GET request to api/q3/cube/4 -> Response: 64
        /// 2: GET request to api/q3/cube/-4 -> Response: -64
        /// 3: GET request to api/q3/cube/10 -> Response: 1000
        /// </example>
        
        [HttpGet(template: "cube/{num}")] // Maps GET requests to the endpoint "api/q3/cube/{num}", where {num} is the number to cube.
        public int cube(int num)
        {
        // Calculates the cube of the provided number by multiplying the number by itself twice.
        int cubenum = num * num * num;
            
        // Returns the calculated cube value.
        return cubenum;
        }
    }
}