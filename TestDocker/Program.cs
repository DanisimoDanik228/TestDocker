using Microsoft.EntityFrameworkCore;
using TestDocker.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string connectionString = "Host=db;Port=5432;Database=TestDocker;Username=postgres;Password=76127612";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

//builder.Services.AddSingleton<IRepository,LocalRepository>();
builder.Services.AddScoped<IRepository,DBRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    var retries = 10;
    while (retries > 0)
    {
        try
        {
            db.Database.Migrate();
            Console.WriteLine("Database migrated");
            break;
        }
        catch (Exception ex)
        {
            retries--;
            Console.WriteLine("Postgres not ready, retrying...");
            Thread.Sleep(3000);
        }
    }
}


app.MapControllers();

app.Run("http://0.0.0.0:8080");