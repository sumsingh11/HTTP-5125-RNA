
using Microsoft.AspNetCore.Mvc; // Importing necessary namespace for MVC functionality.

namespace Assignment1n01722360.Controllers
{
    /// <summary>
    /// This controller handles a GET request to calculate the area of a regular hexagon.
    /// </summary>
    [Route("api/[controller]")] // Sets the base route as "api/q6", where "q6" refers to the controller name.
    [ApiController] // Declares this class as an API controller that handles HTTP requests.
    public class q6 : Controller
    {
        /// <summary>
        /// Handles a GET request to calculate the area of a hexagon given its side length.
        /// </summary>
        /// <param name="side">The length of one side of the hexagon.</param>
        /// <returns>
        /// Returns the calculated area of the hexagon as a double value.
        /// </returns>
        /// <example>
        /// 1: GET request to api/q6/hexagone?side=1 -> Response: 2.598076211353316
        /// 2: GET request to api/q6/hexagone?side=1.5 -> Response: 5.845671475544961
        /// 3: GET request to api/q6/hexagone?side=20 -> Response: 1039.2304845413264
        /// </example>
        
        [HttpGet(template: "hexagone")] // Maps the GET request to the endpoint "api/q6/hexagone".
        public double hexagone(double side) // Accepts a double parameter 'side', representing the hexagon's side length.
        {
        
        // Calculates the area of a regular hexagon using the formula: (3√3 / 2) * side².
        double area = (3 * Math.Sqrt(3) / 2) * Math.Pow(side, 2);
           
        // Returns the calculated area as the response.
        return area;
        }
    }
}