// Importing necessary namespace for HTTP functionality.
using Microsoft.AspNetCore.Http;
// Importing necessary namespace for MVC functionality.
using Microsoft.AspNetCore.Mvc;
// Importing necessary namespace for collections functionality.
using System.Collections.Generic;

namespace CSHARP_ASSIGNMENT2_SUMITSINGH.Controllers

{
[Route("api/[controller]")]

[ApiController]
public class SilentAuctionController : ControllerBase

{
// Static list to store bids
private static List<Bid> Bids = new List<Bid>();

/// <summary>
/// Add a bid to the silent auction.
/// </summary>
/// <param name="name">Name of the bidder</param>
/// <param name="amount">Bid amount</param>
/// <returns>A confirmation message</returns>

/// <example>
/// Example 1:
/// POST: api/SilentAuction/AddBid
/// Headers: Content-Type: application/x-www-form-urlencoded
/// Request Body: Name=Ahmed&Amount=300
/// Response: "Bid added successfully."
///
/// Example 2:
/// POST: api/SilentAuction/AddBid
/// Headers: Content-Type: application/x-www-form-urlencoded
/// Request Body: Name=Suzanne&Amount=500
/// Response: "Bid added successfully."
/// </example>

[HttpPost("AddBid")]
[Consumes("application/x-www-form-urlencoded")]
 public IActionResult AddBid([FromForm] string name, [FromForm] int amount)
 {

// Creating a new bid object and add it to the list
    var newBid = new Bid { Name = name, Amount = amount };
    Bids.Add(newBid);

    // Return a confirmation message
    return Ok("Bid added successfully.");
     }

/// <summary>
/// Determines the winner of the silent auction based on the highest bid.
/// </summary>
/// <returns>The name of the person who won the silent auction.</returns>
/// <example>
/// GET: api/SilentAuction/DetermineWinner
/// Response: "Suzanne"
/// </example>

[HttpGet("DetermineWinner")]
public IActionResult DetermineWinner()
{
// Check if there are any bids
if (Bids == null || Bids.Count == 0)
    {
    return BadRequest("No bids available.");
    }

// Variables to keep track of the highest bid and the winner's name
string winnerName = string.Empty;
int highestBid = -1;

// Loop through each bid to determine the highest bid
foreach (var currentBid in Bids)
    {
    // If the current bid amount is higher than the highest recorded bid, update the winner's details
if (currentBid.Amount > highestBid)
     {
    highestBid = currentBid.Amount;
    winnerName = currentBid.Name;
     }

    // If the current bid ties the highest bid, the earlier bid (in order) should be considered the winner
    // The loop order ensures that ties are handled correctly because the bids are processed in sequence
    }

    // Return the winner's name as the response
    return Ok(winnerName);
     }
    }

/// Represents a bid in the silent auction.
public class Bid
{
 /// Name of the person who placed the bid.
public required string Name { get; set; }

/// The amount of the bid.
public required int Amount { get; set; }
}}
