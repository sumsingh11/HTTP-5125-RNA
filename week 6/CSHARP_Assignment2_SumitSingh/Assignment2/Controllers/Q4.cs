
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
    
public class EpidemiologyCalculatorController : ControllerBase
    
{
/// <summary>
/// Determining the first day when the total numbers of infected individuals exceeds a expected threshold.
/// </summary>
/// <param name="threshold">The threshold for total numbers of infected individuals.</param>
/// <param name="initialInfected">The starting numbers of infected individuals on day 0.</param>
/// <param name="infectionRate">The rate at which new infections occur every day.</param>
/// <returns>The first day on which the total numbers of infected individuals exceeds the expected threshold.</returns>
       
// <example>
/// POST api/EpidemiologyCalculator/DaysToExceedThreshold
/// Post data: threshold=1000&initialInfected=2&infectionRate=3
/// Returns: 6
/// POST api/EpidemiologyCalculator/DaysToExceedThreshold
/// Post data: threshold=500&initialInfected=1&infectionRate=4
/// Returns: 5
///</example>
       
    [HttpPost(template: "DaysToExceedThreshold")]
        
    [Consumes("application/x-www-form-urlencoded")]
        
    public int CalculateDaysToExceedThreshold([FromForm] int threshold, [FromForm] int initialInfected, [FromForm] int infectionRate)
    {
    // Initializing the total numbers of infected individuals with the initial value.
    int totalInfectedCount = initialInfected;

    // Initializing the number of new infections each day.
    int newInfectionsPerDay = initialInfected;

    // Starting the day counter at 0.
    int dayCount = 0;

    // Continuing incrementing days until the total infected count exceeds.
    while (totalInfectedCount <= threshold)
    {
    dayCount++; 

    // Updating the daily count based on the infection rate.
    newInfectionsPerDay *= infectionRate;

    // Adding the daily infection counts to the total count.
    totalInfectedCount += newInfectionsPerDay;
    }

    return dayCount;
  }
 }
}