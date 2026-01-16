using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PingController : ControllerBase
{
    public PingController()
    {
        Console.WriteLine("Ping Controller Created");
    }

    [HttpGet]
    public IActionResult Get()
    {
        Console.WriteLine("Ping Action Hit");
        return Ok("pong");
    }
}
