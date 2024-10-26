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
public class SpiceCalculatorController : ControllerBase

{
/// <summary>
/// Calculateing the total heat level of spices based on the given spices list.
/// </summary>
/// <param name="spiceList">A comma-separated list of spices names.</param>
/// <returns>The total spiciness level calculated is using the corresponding Scoville Heat Units (SHU) for each spice.</returns>

/// <example>
/// GET api/SpiceCalculator/SpiceLevel=Poblano,Cayenne,Thai,Poblano
/// Returns: 118000
/// GET api/SpiceCalculator/SpiceLevel=Habanero,Habanero,Habanero
/// Returns: 375000
/// GET api/SpiceCalculator/SpiceLevel=Serrano,Mirasol,Poblano
/// Returns: 23000
/// </example>

    [HttpGet(template: "SpiceLevel={spiceList}")]
     public int CalculateSpiceLevel(string spiceList)
    {

    //Dictionary to store spice names and their corresponding Scoville Heat Unit (SHU) values.
    Dictionary<string, int> spiceHeatLevels = new()
    {
        { "Poblano", 1500 },
        { "Mirasol", 6000 },
        { "Serrano", 15500 },
        { "Cayenne", 40000 },
        { "Thai", 75000 },
        { "Habanero", 125000 }
    };

    // Spliting the input string into an array of individual spice names.
    string[] spices = spiceList.Split(',');

    // Initializing the total heat level to zero.
    int totalHeatLevel = 0;

    // Loop through each spice in the input list.
    foreach (var spice in spices)
    {
    // If the spice already exists in the dictionary, and adds its SHU value to the total heat level.
    if (spiceHeatLevels.ContainsKey(spice))
    {totalHeatLevel += spiceHeatLevels[spice];}
    }

   
    return totalHeatLevel;
  }
 }
}