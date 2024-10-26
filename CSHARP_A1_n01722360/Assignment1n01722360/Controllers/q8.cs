using Microsoft.AspNetCore.Mvc; // Importing necessary namespace for MVC functionality.
using System.Globalization; // Importing namespace for culture-specific formatting.
using System.Text.Encodings.Web; // Importing namespace for web encoding (not used here).

namespace Assignment1n01722360.Controllers
{
    /// <summary>
    /// This controller handles the checkout summary for plushie orders via a POST request.
    /// </summary>
    
    [Route("api/[controller]")] // Sets the base route as "api/q8", where "q8" refers to the controller name.
    [ApiController] // Marks this class as an API controller that can handle HTTP requests.
    public class q8 : Controller
    {
        /// <summary>
        /// Processes the order details and provides a summary of the checkout, including item prices, subtotal, tax, and total values.
        /// </summary>
        /// <param name="Small">The number of small plushies ordered.</param>
        /// <param name="Large">The number of large plushies ordered.</param>
        /// <returns>
        /// Returns a string that includes details of the order: prices for small and large plushies, subtotal, tax, and total.
        /// </returns>
        /// <example>
        /// 1: 
        /// POST api/q8/squashfellows 
        /// Content-Type: application/x-www-form-urlencoded
        /// REQUEST BODY: Small=1&Large=1
        /// -> "1 Small @ $25.50 = $25.50; 1 Large @ $45.50 = $45.50; Subtotal = $71.00; Tax = $9.23 HST; Total = $80.23"
        ///
        /// 2: 
        /// POST api/q8/squashfellows
        /// Content-Type: application/x-www-form-urlencoded
        /// REQUEST BODY: Small=2&Large=1
        /// -> "2 Small @ $25.50 = $51.00; 1 Large @ $45.50 = $45.50; Subtotal = $96.50; Tax = $12.54 HST; Total = $109.04"
        ///
        /// 3: 
        /// POST api/q8/squashfellows 
        /// Content-Type: application/x-www-form-urlencoded
        /// REQUEST BODY: Small=100&Large=100
        /// -> "100 Small @ $25.50 = $2,550.00; 100 Large @ $45.50 = $4,550.00; Subtotal = $7,100.00; Tax = $923.00 HST; Total = $8,023.00"
        /// </example>
        
        [HttpPost(template: "squashfellows")] // Maps the POST request to the endpoint "api/q8/squashfellows".
        public string squashfellows([FromForm]int Small, [FromForm]int Large) // Accepts the number of small and large plushies from the request body.
        {
            // Prices for small and large plushies.
            decimal SmallPrice = 25.50m; // Price of one small plushie.
            decimal LargePrice = 45.50m; // Price of one large plushie.
            decimal HSTRate = 0.13m; // HST tax rate (13%).

            // Calculates the total price for small and large plushies based on quantity ordered.
            decimal SmallTotal = Small * SmallPrice; // Total price for small plushies.
            decimal LargeTotal = Large * LargePrice; // Total price for large plushies.

            // Calculates the subtotal for the order.
            decimal SubTotal = SmallTotal + LargeTotal; // Sum of both totals.

            // Calculates the tax based on the subtotal.
            decimal Tax = Math.Round(SubTotal * HSTRate, 2); // HST rounded to 2 decimal places.

            // Calculates the total price including tax.
            decimal Total = Tax + SubTotal; // Final total amount.

            // Constructs the summary string with formatted prices using Canadian currency formatting.
            string Summary = $"{Small} Small @ {SmallPrice.ToString("C2", CultureInfo.CreateSpecificCulture("en-CA"))} = {SmallTotal.ToString("C2", CultureInfo.CreateSpecificCulture("en-CA"))}; " +
                             $"{Large} Large @ {LargePrice.ToString("C2", CultureInfo.CreateSpecificCulture("en-CA"))} = {LargeTotal.ToString("C2", CultureInfo.CreateSpecificCulture("en-CA"))}; " +
                             $"Subtotal = {SubTotal.ToString("C2", CultureInfo.CreateSpecificCulture("en-CA"))}; " +
                             $"Tax = {Tax.ToString("C2", CultureInfo.CreateSpecificCulture("en-CA"))} HST; " +
                             $"Total = {Total.ToString("C2", CultureInfo.CreateSpecificCulture("en-CA"))}";

            // Returns the summary string as the HTTP response.
            return Summary; // Sends back the summary as a response.
        }
    }
}