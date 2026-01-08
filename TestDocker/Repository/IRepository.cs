namespace TestDocker.Repository;

public interface IRepository
{
    Task AddAsync(WeatherForecast[] forecast);
    Task<IEnumerable<WeatherForecast>> GetAllAsync();
}