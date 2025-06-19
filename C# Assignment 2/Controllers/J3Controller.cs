namespace CCCApi.Controllers;
using Microsoft.AspNetCore.Mvc;
// Reads a list of instruction codes and stops at 99999
// Decides direction based on digit sums: left, right, or straight
[ApiController]
[Route("api/J3")]
public class J3Controller : ControllerBase
{
    [HttpPost("SecretInstructions")]
    public IEnumerable<string> SecretInstructions([FromForm] string Codes)
    {
        var list = Codes.Split(',', System.StringSplitOptions.RemoveEmptyEntries);
        //list to use and update it below 
        var result = new List<string>();
        foreach (var codeStr in list)
        {
            // Skip if it's not a valid number, stop when we hit 99999
            // compare the first and last digits to figure out the direction
            // add the direction and last 3 digits to the list
            if (!int.TryParse(codeStr.Trim(), out var code)) continue;
            if (code == 99999) break;
            var left = code / 10000 + (code / 1000) % 10 + (code / 100) % 10;
            var right = (code / 10) % 10 + code % 10;
            if (left > right) result.Add("left " + (code % 1000).ToString("D3"));
            else if (left < right) result.Add("right " + (code % 1000).ToString("D3"));
            else result.Add("straight " + (code % 1000).ToString("D3"));
        }
        //return the result
        return result;
    }
}
