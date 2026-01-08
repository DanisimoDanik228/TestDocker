namespace TestDocker.Repository;

public class LocalRepository :IRepository
{
    private List<WeatherForecast> _context;
    
    public LocalRepository()
    {
        _context = new();
    }
    
    public async Task AddAsync(WeatherForecast[] forecast)
    {
        _context.AddRange(forecast);
    }

    public async Task<IEnumerable<WeatherForecast>> GetAllAsync()
    {
        return _context;
    }
}