using Microsoft.AspNetCore.Mvc;

namespace UserTest.Controllers;

[ApiController]
[Route("[controller]")]
public class UserTestController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<UserTestController> _logger;

    public UserTestController(ILogger<UserTestController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUserTest")]
    public IEnumerable<UserTest> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new UserTest
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
