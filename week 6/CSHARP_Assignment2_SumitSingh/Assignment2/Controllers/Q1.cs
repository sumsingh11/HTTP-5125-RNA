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
public class DeliverdroidController : ControllerBase
{
/// <summary>
/// Calculates the total score for the delivery droid based on the number of successful deliveries and collisions.
/// </summary>
/// <param name="successfulDeliveries">The number of successful deliveries made by the droid.</param>
/// <param name="collisionCount">The number of collisions the droid encountered.</param>
/// <returns>The total score, including a bonus if deliveries exceed collisions.</returns>

/// <example>
/// POST: api/DeliveryScore/Calculate
/// Headers: Content-Type: application/x-www-form-urlencoded
/// Post data: crashes=3&packagesDelivered=8
/// ->840
/// POST: api/DeliveryScore/Calculate
/// Headers: Content-Type: application/x-www-form-urlencoded
/// Post data: crashes=5&packagesDelivered=4
/// ->130
/// </example>

[HttpPost(template: "CalculateScore")]

[Consumes("application/x-www-form-urlencoded")]
public int CalculateDroidScore([FromForm] int successfulDeliveries, [FromForm] int collisionCount)
{

// Calculateing the starting total score based on the number of successful deliveries and collisions.
// Each delivery adds 50 points every time, and each collision deducts 10 points everytime.
    int totalScore = (successfulDeliveries * 50) + (collisionCount * -10);

// Adding a bonus of 500 points if the number of successful deliveries is greater than the number of collisions.
    if (successfulDeliveries > collisionCount)
    {
    totalScore += 500;
    }

    
    return totalScore;
  }
 }
}