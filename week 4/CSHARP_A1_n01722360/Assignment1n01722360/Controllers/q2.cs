
using Microsoft.AspNetCore.Mvc; // Importing necessary namespace for MVC functionality.

namespace Assignment1n01722360.Controllers
{
    /// <summary>
    /// This controller handles a GET request that greets the user by their name.
    /// </summary>
    
    [Route("api/[controller]")] // Defines the base route as "api/q2", with "q2" derived from the controller's name.
    [ApiController] // Specifies that this class is an API controller, which automatically handles request validation and response formatting.
    public class q2 : Controller
    {
        /// <summary>
        /// Handles a GET request to provide a personalized greeting message.
        /// </summary>
        /// <param name="name">The name of the person being greeted.</param>
        /// <returns>
        /// Returns a greeting message in the format "Hi [name]!", where [name] is the user-specified name.
        /// </returns>
        /// <example>
        /// 1: GET request to api/q2/greeting?name=Gary -> Response: "Hi Gary!"
        /// 2: GET request to api/q2/greeting?name=Ren%C3%A9e -> Response: "Hi Renée!"
        /// </example>
        /// 
        [HttpGet(template:"greeting")] // Maps the GET request to "api/q2/greeting".
        public string greeting(string name)
        {
            // Returns a personalized greeting using the provided name parameter.
            return ($"Hi {name}!");
        }
    }
}