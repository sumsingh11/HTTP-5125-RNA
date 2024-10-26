// Importing necessary namespace for Http functionality.
using Microsoft.AspNetCore.Http;
// Importing necessary namespace for MVC functionality.
using Microsoft.AspNetCore.Mvc;
// Importing necessary namespace for collections functionality.
using System.Collections.Generic;

namespace CSHARP_ASSIGNMENT2_SUMITSINGH.Controllers
{
[Route("api/[controller]")]

[ApiController]

 public class CupcakesController : ControllerBase
{
/// <summary>
/// Calculating the remaining number of cupcakes after distributing a specified amount.
/// </summary>
/// <param name="largeCupcakes">The number of large cupcakes available, where each large cupcake is worth 8 units.</param>
/// <param name="smallCupcakes">The number of small cupcakes available, where each small cupcake is worth 3 units.</param>
/// <returns>The remaining number of cupcakes units after attempting to complete a target of 28 units.</returns>

/// <example>
/// POST: api/Cupcake/CalculateRemaining
/// Headers: Content-Type: application/x-www-form-urlencoded
/// Post data: largeBoxes=3&smallBoxes=6
/// -> 14
/// POST: api/Cupcake/CalculateRemaining
/// Headers: Content-Type: application/x-www-form-urlencoded
/// Post data: largeBoxes=1&smallBoxes=2
/// -> -14 (meaning not enough cupcakes)
/// </example>

    [HttpPost(template: "CalculateRemaining")]

    [Consumes("application/x-www-form-urlencoded")]
    public int CalculateRemainingCupcakes([FromForm] int largeCupcakes, [FromForm] int smallCupcakes)
    {
    // Calculating the total number of cupcake units based on large and small cupcake combinations.
    int totalCupcakeUnits = (largeCupcakes * 8) + (smallCupcakes * 3);

    // Subtracting 28 units from the total to count the remaining units.
    int remainingUnits = totalCupcakeUnits - 28;

   
    return remainingUnits;
  }
 }
}