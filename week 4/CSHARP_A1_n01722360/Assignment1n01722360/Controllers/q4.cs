using Microsoft.AspNetCore.Mvc; // Importing necessary namespace for MVC functionality.

namespace Assignment1n01722360.Controllers
{
    /// <summary>
    /// This controller handles HTTP POST requests and responds with predefined messages.
    /// </summary>
    
    [Route("api/[controller]")] // Defines the base route as "api/q4", where "q4" matches the controller's name.
    [ApiController] // Marks this class as an API controller to handle HTTP requests and responses.
    public class q4 : Controller
    {
        /// <summary>
        /// Handles HTTP POST requests to provide a "knock knock" response.
        /// </summary>
        /// <returns>
        /// Returns a string message "Who's there?" as the response to the client.
        /// </returns>
        /// <example>
        /// POST request to api/q4/knockknock -> Response: "Who's there?"
        /// </example>
        
        [HttpPost(template:"knockknock")] // Maps the POST request to the endpoint "api/q4/knockknock".
        public string knockknock()
        {
        // Returns the predefined message "Who's there?" to the client.
            return ("Who's there?");
        }

        /// <summary>
        /// Handles HTTP POST requests to provide a different message response.
        /// </summary>
        /// <returns>
        /// Returns a string message "Konichiwa!! Hajememashte." as the response to the client.
        /// </returns>
        /// <example>
        /// 1: POST request to api/q4/example -> Response: "Konichiwa!! Hajememashte."
        /// </example>
        
        [HttpPost(template:"example")] // Maps the POST request to the endpoint "api/q4/example".
        public string example()
        {
        // Returns the predefined message "Konichiwa!! Hajememashte." to the client.
        return ("Konichiwa!! Hajememashte.");
        }
    }
}