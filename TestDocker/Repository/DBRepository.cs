namespace TestDocker.Repository;

public class DBRepository :IRepository
{
    private ApplicationDbContext _context;
    
    public DBRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(WeatherForecast[] forecast)
    {
        await _context.AddRangeAsync(forecast);
        
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<WeatherForecast>> GetAllAsync()
    {
        return _context.Weather;
    }
}