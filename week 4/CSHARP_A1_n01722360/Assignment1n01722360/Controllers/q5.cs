using Microsoft.AspNetCore.Mvc; // Importing necessary namespace for MVC functionality.

namespace Assignment1n01722360.Controllers
{
    /// <summary>
    /// This controller handles HTTP POST requests and reveals a "secret" number.
    /// </summary>

    [Route("api/[controller]")] // Sets the base route as "api/q5", where "q5" is based on the controller name.
    [ApiController] // Indicates that this class is an API controller that responds to HTTP requests.
    public class q5 : Controller
    {
        /// <summary>
        /// Handles an HTTP POST request to reveal a secret number.
        /// </summary>
        /// <param name="num">The secret number to be revealed, provided in the request body.</param>
        /// <returns>
        /// Returns a string that includes the secret number, formatted as "Shh.. the secret is {num}.".
        /// </returns>
        /// <example>
        /// 1: POST request to api/q5/secret with the body 5 -> Response: "Shh.. the secret is 5.".
        /// 2: POST request to api/q5/secret with the body -200 -> Response: "Shh.. the secret is -200.".
        /// </example>
        
        [HttpPost(template: "secret")] // Maps the POST request to the endpoint "api/q5/secret".
        public string secret([FromBody] int num) // The secret number is taken from the body of the POST request.
        {
        // Returns the message "Shh.. the secret is {num}", where {num} is the number passed in the request body.
        return $"Shh.. the secret is {num}.";
        }
    }
}