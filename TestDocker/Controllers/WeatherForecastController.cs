using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestDocker.Repository;

namespace TestDocker.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IRepository _repository;
    
    public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet("add")]
    public async Task<IActionResult> Add()
    {
        var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        await _repository.AddAsync(data);
        
        return Ok(data);
    }
    
    [HttpGet("get")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await _repository.GetAllAsync();
    }
}