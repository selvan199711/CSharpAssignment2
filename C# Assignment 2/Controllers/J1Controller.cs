namespace CCCApi.Controllers;
using Microsoft.AspNetCore.Mvc;
// this Calculates the score based on deliveries and collisions
// Returns quadrant based on x and y coordinates
[ApiController]
[Route("api/J1")]
public class J1Controller : ControllerBase
{
    [HttpPost("Delivedroid")]
    public int Delivedroid([FromForm] int Collisions, [FromForm] int Deliveries)
    {
        var score = Deliveries * 50 - Collisions * 10;
        if (Deliveries > Collisions) score += 500;
        return score;
    }

    [HttpPost("Quadrant")]
    //checks where the point is on the graph
    //return the matching quadrant number from 1 to 4
    public int Quadrant([FromForm] int x, [FromForm] int y)
    {
        if (x > 0 && y > 0) return 1;
        if (x < 0 && y > 0) return 2;
        if (x < 0 && y < 0) return 3;
        //return
        return 4;
    }
}
