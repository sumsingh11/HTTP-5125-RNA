// Importing necessary namespace for HTTP functionality
using Microsoft.AspNetCore.Http;
// Importing necessary namespace for MVC functionality
using Microsoft.AspNetCore.Mvc;
// Importing necessary namespace for collections functionality
using System.Collections.Generic;

namespace CSHARP_ASSIGNMENT2_SUMITSINGH.Controllers
{

[Route("api/[controller]")]
[ApiController]
public class SecretCodeController : ControllerBase
{

/// <summary>
/// This method decodes a series of coded instructions and returns the corresponding directions (LEFT or RIGHT) and number of steps. The decoding process is based on specified rules for interpreting the input.
/// </summary>
/// <param name="encodedInstructions">A comma-separated string where each element represents a 5 digit instruction number.</param>
/// <returns>A string that contains all decoded directions and step counts, formatted line by line.</returns>
        
///  <example>
///  POST: api/SecretCode/DecodeInstructions
///  Headers: Content-Type: application/x-www-form-urlencoded
///  Post data: encodedInstructions=57234,00907,34100,99999
/// ->  right 234
/// ->  right 907
/// ->  left 100
///  </example>
        
[HttpPost("DecodeInstructions")]
        
[Consumes("application/x-www-form-urlencoded")]
public string DecodeInstructions([FromForm] string encodedInstructions)
{
  // Spliting the input string into an array of individual 5 digit instruction strings.
  string[] instructionArray = encodedInstructions.Split(',');

  // String to accomodate the decoded directions and steps.
  string decodedResult = "";

  // Variable to track the last determined direction (LEFT or RIGHT)
  string previousDirection = "";

  
  foreach (var instruction in instructionArray)
  {
  // If the instruction is "99999", break out of the loop as it signifies termination of the loop.
  if (instruction == "99999")
  {
  break;
  }

  // Variables to hold the decoded direction and steps.
  string currentDirection;
  // Extract the first 2 digits of the instruction to calculate the direction.
  int leadingDigits = int.Parse(instruction.Substring(0, 2));
  // Extracting the last 3 digits for the number of steps.
  int trailingDigits = int.Parse(instruction.Substring(2, 3));
  // Calculating sum of the 2 individual digits from the leading pair.
  int sumOfFirstTwoDigits = (leadingDigits / 10) + (leadingDigits % 10);

  // Determining the current direction based on the sum of the leading digits.
  if (sumOfFirstTwoDigits == 0)
   {
    // If the sum is zero, use the last direction.
     currentDirection = previousDirection;
   }
    else if (sumOfFirstTwoDigits % 2 == 0)
    {
    // If the sum is even, the direction is RIGHT.
     currentDirection = "right";
      }
      else
     {
     // If the sum is odd, the direction is LEFT.
       currentDirection = "left";
    }

      // Updating last direction used for the next iterationn.
      previousDirection = currentDirection;
      // Appending current decoded direction and steps to the result string.
     decodedResult += $"{currentDirection} {trailingDigits}\n";
       }

      // Returning the current total result, ensuring there is no newline character.
    return decodedResult.TrimEnd('\n');
        }
    }
}