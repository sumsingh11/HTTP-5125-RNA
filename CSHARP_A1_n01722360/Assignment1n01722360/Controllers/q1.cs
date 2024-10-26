
using Microsoft.AspNetCore.Mvc; // Importing necessary namespace for MVC functionality.

namespace Assignment1n01722360.Controllers
{
    /// <summary>
    /// This controller handles two GET requests to provide welcoming and informational messages.
    /// </summary>
    
    [Route("api/[controller]")] // Defines the base route as "api/q1", with "q1" derived from the controller's name.
    [ApiController] // Specifies that this class is an API controller, which automatically handles request validation and response formatting.
    public class q1 : Controller
    {
        /// <summary>
        /// Handles the GET request for a welcoming message.
        /// </summary>
        /// <returns>
        /// Returns an HTTP response with the message "Welcome to 5125!" to the client.
        /// </returns>
        /// <example>
        /// 1: GET api/q1/welcome -> "Welcome to 5125!"
        /// </example>
        [HttpGet(template: "Welcome")]
        public string welcome()
        {
            return "Welcome to 5125!";
        }

        /// <summary>
        /// Handles the GET request for an informational message.
        /// </summary>
        /// <returns>
        /// Returns an HTTP response with the string "Hi! Web Dev class from Humber college." to the client.
        /// </returns>
        /// <example>
        /// GET api/q1/example -> "Hi! Web Dev class from Humber college."
        /// </example>
        [HttpGet(template: "example")]
        public string example()
        {
            return "Hi! Web Dev class from Humber college.";
        }
    }
}