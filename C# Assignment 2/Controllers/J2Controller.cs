namespace CCCApi.Controllers;
using Microsoft.AspNetCore.Mvc;
// Adds up spice level based on the list of peppers
// Tells if the fish is rising, diving, staying flat, or random
[ApiController]
[Route("api/J2")]
public class J2Controller : ControllerBase
{
    [HttpGet("ChiliPeppers")]
    public int ChiliPeppers([FromQuery] string Ingredients)
    {
        //dictionary list hold the value
        var heatMap = new Dictionary<string, int>
        {
            ["Poblano"] = 1500,
            ["Mirasol"] = 6000,
            ["Serrano"] = 15500,
            ["Cayenne"] = 40000,
            ["Thai"] = 75000,
            ["Habanero"] = 125000
        };
        //split them with commas and return them as total
        var peppers = Ingredients.Split(',', System.StringSplitOptions.RemoveEmptyEntries);
        var total = peppers.Sum(p => heatMap[p.Trim()]);
        return total;
    }

    [HttpPost("Fishy")]
    public string Fishy([FromForm] int w1, [FromForm] int w2, [FromForm] int w3, [FromForm] int w4)
    {
        //if the numbers keep going up, say the fish is rising
        //if they go down,say it's diving
        //if all are the same,it's staying same
        //otherwise, it's just no fish
        if (w1 < w2 && w2 < w3 && w3 < w4) return "Fish Rising";
        if (w1 > w2 && w2 > w3 && w3 > w4) return "Fish Diving";
        if (w1 == w2 && w2 == w3 && w3 == w4) return "Fish At Constant Depth";
        return "No Fish";
    }
}
